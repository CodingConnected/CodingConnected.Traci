using System;
using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class MultiEntryExitDetectorCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.ID_LIST);
		}
		
		public TraCIResponse<int> GetIdCount()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.ID_COUNT);
		}
		
		public TraCIResponse<int> GetLastStepVehicleNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
		}

		public TraCIResponse<double> GetLastStepMeanSpeed(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_MEAN_SPEED);
		}

		public TraCIResponse<List<string>> GetLastStepVehicleIds(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}
		
		public TraCIResponse<int> GetLastStepHaltingNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER);
		}
		
		#endregion // Public Methods

		#region Constructor

		public MultiEntryExitDetectorCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}