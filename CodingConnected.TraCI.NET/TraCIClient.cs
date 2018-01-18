using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using CodingConnected.TraCI.NET.Commands;
using CodingConnected.TraCI.NET.Helpers;

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

		public ControlCommands Control { get; }
		public InductionLoopCommands InductionLoop { get; }
		public LaneAreaDetectorCommands LaneAreaDetector { get; }
		public MultiEntryExitDetectorCommands MultiEntryExitDetector { get; }
	    public LaneCommands Lane { get; }
		public TrafficLightCommands TrafficLight { get; }
		public VehicleCommands Vehicle { get; }
	    public PersonCommands Person { get; }

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
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(trafficLightId));
            bytes.Add(TraCIConstants.TYPE_STRING);
            bytes.AddRange(BitConverter.GetBytes(state.Length).Reverse());
            bytes.AddRange(Encoding.ASCII.GetBytes(state));

            command.Contents = bytes.ToArray();
            // ReSharper disable once UnusedVariable
            var response = SendMessage(command);
        }

        public void SetSingleTrafficLightState(string trafficLightId, string signalgroup, char singlestate)
        {
            var command = new TraCICommand { Identifier = TraCIConstants.CMD_SET_TL_VARIABLE };
            var bytes = new List<byte> { TraCIConstants.TL_RED_YELLOW_GREEN_SINGLESTATE };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(trafficLightId));
            bytes.Add(TraCIConstants.TYPE_STRING);
            bytes.AddRange(BitConverter.GetBytes((signalgroup + ' ' + singlestate).Length).Reverse());
            bytes.AddRange(Encoding.ASCII.GetBytes(signalgroup + ' ' + singlestate));

            command.Contents = bytes.ToArray();
            // ReSharper disable once UnusedVariable
            var response = SendMessage(command);
        }

		#endregion // Set Variable Methods

		#region Public Methods

	    internal TraCIResult[] SendMessage(TraCICommand command)
	    {
		    if (!_client.Connected)
		    {
			    return null;
		    }

		    var msg = TraCIDataConverter.GetMessageBytes(command);
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
			    var trresponse = TraCIDataConverter.HandleResponse(response);
			    return trresponse?.Length > 0 ? trresponse : null;
		    }
		    catch
		    {
			    return null; // TODO
		    }
	    }

		#endregion // Public Methods

		#region Private Methods

		#endregion // Private Methods

		#region Constructor

		public TraCIClient()
	    {
		    Control = new ControlCommands(this);
			InductionLoop = new InductionLoopCommands(this);
			LaneAreaDetector = new LaneAreaDetectorCommands(this);
			MultiEntryExitDetector = new MultiEntryExitDetectorCommands(this);
		    Lane = new LaneCommands(this);
		    TrafficLight = new TrafficLightCommands(this);
			Vehicle = new VehicleCommands(this);
			Person = new PersonCommands(this);
	    }

	    #endregion // Constructor
    }
}
