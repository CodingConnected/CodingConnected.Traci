using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
#if NLOG
using NLog;
#endif

namespace CodingConnected.TraCI.NET
{
    /// <summary>
    /// A simple )and yet incomplete) client-side implementation of TraCI, for using SUMO
    /// with .NET applications.
    /// </summary>
    public class TraCIClient
    {

        #if NLOG
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        #endif

        #region Fields

        private TcpClient _client;
        private NetworkStream _stream;
        private readonly byte[] _receiveBuffer = new byte[32768];

        #endregion // Fields

        #region Properties

        #endregion // Properties

        #region Public Methods

        /// <summary>
        /// Connects to the SUMO server instance
        /// </summary>
        /// <param name="hostname">Hostname or ip address where SUMO is running</param>
        /// <param name="port">Port at which SUMO exposes the API</param>
        public async Task ConnectAsync(string hostname, int port)
        {
            _client = new TcpClient
            {
                ReceiveBufferSize = 32768,
                SendBufferSize = 32768
            };
            await _client.ConnectAsync(hostname, port);
            _stream = _client.GetStream();
        }

        #endregion // Public Methods

        #region Control Methods

        /// <summary>
        /// Gets an identifying version number as described here: http://sumo.dlr.de/wiki/TraCI/Control-related_commands
        /// </summary>
        public int ControlGetVersionId()
        {
            var command = new TraCICommand
            {
                Identifier = TraCIConstants.CMD_GETVERSION,
                Contents = null
            };
            var response = SendMessage(command);
            if (response?.Length == 2)
            {
                return BitConverter.ToInt32(response[1].Response.Take(4).Reverse().ToArray(), 0);
            }
            return -1;
        }

        /// <summary>
        /// Gets a user friendly string describing the version of SUMO
        /// </summary>
        public string ControlGetVersionString()
        {
            var command = new TraCICommand
            {
                Identifier = TraCIConstants.CMD_GETVERSION,
                Contents = null
            };
            var response = SendMessage(command);
            if (response?.Length == 2)
            {
                var strlen = response[1].Response.Skip(4).Take(4).Reverse().ToArray();
                var idl = BitConverter.ToInt32(strlen, 0);
                var ver = Encoding.ASCII.GetString(response[1].Response, 8, idl);
                return ver;
            }
            return null;

        }

        /// <summary>
        /// Instruct SUMO to execute a single simulation step
        /// Note: the size of the step is set via the relevant .sumcfg file
        /// </summary>
        public void ControlSimStep()
        {
            var command = new TraCICommand
            {
                Identifier = TraCIConstants.CMD_SIMSTEP,
                Contents = BitConverter.GetBytes(0)
            };
            // ReSharper disable once UnusedVariable
            var response = SendMessage(command);
            // TODO: handle response
        }

        /// <summary>
        /// Instruct SUMO to stop the simulation and close
        /// </summary>
        public void ControlClose()
        {
            var command = new TraCICommand
            {
                Identifier = TraCIConstants.CMD_CLOSE,
                Contents = null
            };
            // ReSharper disable once UnusedVariable
            var response = SendMessage(command);
        }

        /// <summary>
        /// Note: this is not implemented in SUMO
        /// </summary>
        /// <param name="options">List of options to pass to SUMO</param>
        public void ControlLoad(List<string> options)
        {
            var command = new TraCICommand
            {
                Identifier = TraCIConstants.CMD_LOAD
            };
            var n = new List<byte>();
            n.AddRange(GetTraCIBytesFromInt32(options.Count));
            foreach (var opt in options)
            {
                n.AddRange(GetTraCIBytesFromInt32(opt.Length));
                n.AddRange(GetTraCIBytesFromASCIIString(opt));
            }
            command.Contents = n.ToArray();
            // ReSharper disable once UnusedVariable
            var response = SendMessage(command);
        }

        #endregion // Control Methods

        #region Get Variable Methods

        /// <summary>
        /// Gets the occupancy percentage for a lane area detector over the last simulation step
        /// </summary>
        /// <param name="id">The id of the lane area detector as set in SUMO</param>
        public double GetLaneAreaLastStepOccupancy(string id)
        {
            var command = new TraCICommand { Identifier = TraCIConstants.CMD_GET_LANEAREA_VARIABLE };

            var bytes = new List<byte> { TraCIConstants.LAST_STEP_OCCUPANCY };
            bytes.AddRange(GetTraCIBytesFromASCIIString(id));
            command.Contents = bytes.ToArray();

            var response = SendMessage(command);

            if (response?.Length > 0)
            {
                var r = response.FirstOrDefault(x => x.Identifier == TraCIConstants.RESPONSE_GET_LANEAREA_VARIABLE);
                if (r?.Response[0] == TraCIConstants.LAST_STEP_OCCUPANCY)
                {
                    var t = r.Response.Skip(1).Take(4).Reverse().ToArray();
                    var idl = BitConverter.ToInt32(t, 0);
                    //var ids = BitConverter.ToString(r.Response, 5, idl);
                    var type = r.Response[5 + idl];
                    var varval = GetValueFromTypeAndArray(type, r.Response.Skip(6 + idl).ToArray());

                    return (double)varval;
                }
            }
            return -1;
        }

        #endregion // Get Variable Methods

        #region Set Variable Methods

        /// <summary>
        /// Sets the state of all lights of a controlled junction
        /// </summary>
        /// <param name="trafficLightId">The id of the traffic light as set in SUMO</param>
        /// <param name="state">The state to set the traffic lights to, parsed as a string, as is 
        /// described here: http://sumo.dlr.de/wiki/TraCI/Change_Traffic_Lights_State </param>
        public void SetTrafficLightState(string trafficLightId, string state)
        {
            var command = new TraCICommand { Identifier = TraCIConstants.CMD_SET_TL_VARIABLE };
            var bytes = new List<byte> { TraCIConstants.TL_RED_YELLOW_GREEN_STATE };
            bytes.AddRange(GetTraCIBytesFromASCIIString(trafficLightId));
            bytes.Add(TraCIConstants.TYPE_STRING);
            bytes.AddRange(BitConverter.GetBytes(state.Length).Reverse());
            bytes.AddRange(Encoding.ASCII.GetBytes(state));

            command.Contents = bytes.ToArray();
            // ReSharper disable once UnusedVariable
            var response = SendMessage(command);
        }

        #endregion // Set Variable Methods

        #region Private Methods

        private byte[] GetTraCIBytesFromInt32(int i)
        {
            return BitConverter.GetBytes(i).Reverse().ToArray();
        }

        private byte[] GetTraCIBytesFromASCIIString(string s)
        {
            var bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(s.Length).Reverse());
            bytes.AddRange(Encoding.ASCII.GetBytes(s));
            return bytes.ToArray();
        }

        private object GetValueFromTypeAndArray(byte type, byte[] array)
        {
            switch (type)
            {
                case 0x07:
                    return array[0];
                case 0x08:
                    return BitConverter.ToChar(array, 0);
                case 0x09:
                    var t1 = array.Take(4).Reverse().ToArray();
                    return BitConverter.ToInt32(t1, 0);
                case 0x0A:
                    var t2 = array.Take(4).Reverse().ToArray();
                    return BitConverter.ToSingle(t2, 0);
                case 0x0B:
                    var t3 = array.Take(8).Reverse().ToArray();
                    return BitConverter.ToDouble(t3, 0);
                // TODO: strings, etc... (see http://sumo.dlr.de/wiki/TraCI/Protocol#Data_types)
                default:
                    throw new NotImplementedException();
            }
        }

        private TraCIResult[] SendMessage(TraCICommand command)
        {
            if (!_client.Connected)
            {
                return null;
            }

            var msg = GetMessageBytes(command);
            _client.Client.Send(msg);
            try
            {
                var bytesRead = _stream.Read(_receiveBuffer, 0, 32768);
                if (bytesRead < 0)
                {
                    // Read returns 0 if the client closes the connection
                    throw new IOException();
                }
                var response = _receiveBuffer.Take(bytesRead).ToArray();
                #if NLOG
                _logger.Trace(" << {0}", BitConverter.ToString(response));
                #endif
                var trresponse = HandleResponse(response);
                return trresponse?.Length > 0 ? trresponse : null;
            }
            catch
            {
                return null; // TODO
            }
        }

        private byte[] GetMessageBytes(TraCICommand command)
        {
            return GetMessagesBytes(new[] {command});
        }

        private byte[] GetMessagesBytes(IEnumerable<TraCICommand> commands)
        {
            var cmessages = new List<List<byte>>();
            foreach (var c in commands)
            {
                var cmessage = new List<byte>();
                if (c.Contents == null)
                {
                    cmessage.Add(2); // no contents: only length self and id => 2
                }
                else if ((c.Contents.Length + 2) <= 255)
                {
                    cmessage.Add((byte)(c.Contents.Length + 2));
                }
                else
                {
                    cmessage.Add(0);
                    cmessage.AddRange(BitConverter.GetBytes(c.Contents.Length + 6).Reverse());
                }
                cmessage.Add(c.Identifier);
                if (c.Contents != null)
                {
                    cmessage.AddRange(c.Contents);
                }
                cmessages.Add(cmessage);
            }
            var totlength = cmessages.Select(x => x.Count).Sum() + 4;
            var totmessage = new List<byte>();
            totmessage.AddRange(BitConverter.GetBytes(totlength).Reverse());
            cmessages.ForEach(x => totmessage.AddRange(x));
            //totmessage.AddRange(BitConverter.GetBytes('\n'));
            return totmessage.ToArray();
        }

        private TraCIResult[] HandleResponse(byte[] response)
        {
            try
            {
                var revLength = response.Take(4).Reverse().ToArray();
                var totlength = BitConverter.ToInt32(revLength, 0);
                var i = 4;
                var results = new List<TraCIResult>();
                while (i < totlength)
                {
                    var trresult = new TraCIResult();
                    var j = 0;
                    int len = response[i + j++];
                    trresult.Length = len - 2; // bytes lenght will be: msg - length - id
                    if (len == 0)
                    {
                        if (j + 3 < len)
                        {
                            revLength = new byte[4];
                            revLength[0] = response[i + j + 3];
                            revLength[1] = response[i + j + 2];
                            revLength[2] = response[i + j + 1];
                            revLength[3] = response[i + j + 0];
                            len = BitConverter.ToInt32(revLength, 0);
                            trresult.Length = len - 6; // bytes lenght will be: msg - length - int32len - id
                            j += 4;
                        }
                        else
                        {
                            break;
                        }
                    }
                    trresult.Identifier = response[i + j++];
                    var cmd = new List<byte>();
                    while (j < len)
                    {
                        cmd.Add(response[i + j++]);
                    }
                    trresult.Response = cmd.ToArray();
                    i += j;
                    results.Add(trresult);
                }
                return results.ToArray();
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }
        
#endregion // Private Methods
    }
}
