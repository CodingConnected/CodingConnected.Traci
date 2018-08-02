using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class ControlCommands : TraCICommandsBase
	{
		#region Public Methods

		/// <summary>
		/// Gets an identifying version number as described here: http://sumo.dlr.de/wiki/TraCI/Control-related_commands
		/// </summary>
		public int GetVersionId()
		{
			var command = new TraCICommand
			{
				Identifier = TraCIConstants.CMD_GETVERSION, 
				Contents = null
			};
			var response = Client.SendMessage(command);
			if (response?.Length == 2)
			{
				return BitConverter.ToInt32(response[1].Response.Take(4).Reverse().ToArray(), 0);
			}
			return -1;
		}

		/// <summary>
		/// Gets a user friendly string describing the version of SUMO
		/// </summary>
		public string GetVersionString()
		{
			var command = new TraCICommand
			{
				Identifier = TraCIConstants.CMD_GETVERSION,
				Contents = null
			};
			var response = Client.SendMessage(command);
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
		/// <param name="targetTime">If this is not 0, SUMO will run until target time is reached</param>
		public TraCIResponse<object> SimStep(int targetTime = 0)
		{
			var command = new TraCICommand
			{
				Identifier = TraCIConstants.CMD_SIMSTEP,
				Contents = TraCIDataConverter.GetTraCIBytesFromInt32(targetTime)
			};

			var response = Client.SendMessage(command);
            return TraCIDataConverter.ExtractDataFromResponse<object>(response, TraCIConstants.CMD_SIMSTEP);
        }

		
		/// <summary>
		/// Instruct SUMO to stop the simulation and close
		/// </summary>
		public void Close()
		{
			var command = new TraCICommand
			{
				Identifier = TraCIConstants.CMD_CLOSE,
				Contents = null
			};
			// ReSharper disable once UnusedVariable
			var response = Client.SendMessage(command);
		}

		/// <summary>
		/// Tells TraCI to reload the simulation with the given options
		/// <remarks>Loading does not work when using multiple clients, currently</remarks>
		/// </summary>
		/// <param name="options">List of options to pass to SUMO</param>
		public void Load(List<string> options)
		{
			var command = new TraCICommand
			{
				Identifier = TraCIConstants.CMD_LOAD
			};
			var n = new List<byte>();
			n.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(options.Count));
			foreach (var opt in options)
			{
				n.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(opt.Length));
				n.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(opt));
			}
			command.Contents = n.ToArray();
			// ReSharper disable once UnusedVariable
			var response = Client.SendMessage(command);
		}

		/// <summary>
		/// Tells TraCI to reload the simulation with the given options
		/// <remarks>Loading does not work when using multiple clients, currently</remarks>
		/// </summary>
		/// <param name="options">List of options to pass to SUMO</param>
		public void SetOrder(int index)
		{
			var command = new TraCICommand
			{
				Identifier = TraCIConstants.CMD_GETVERSION, 
				Contents = BitConverter.GetBytes(index).Reverse().ToArray()
			};
			var response = Client.SendMessage(command);
		}

		#endregion // Public Methods

		#region Constructor

		public ControlCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}