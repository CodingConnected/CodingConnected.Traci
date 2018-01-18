using System;
using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class MultiEntryExitDetectorCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIdList()
		{
			return 
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.ID_LIST);
		}
		
		public int GetIdCount()
		{
			return 
				TraCICommandHelper.ExecuteCommand<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.ID_COUNT);
		}
		
		public int GetLastStepVehicleNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
		}

		public double GetLastStepMeanSpeed(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_MEAN_SPEED);
		}

		public List<string> GetLastStepVehicleIds(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_MULTIENTRYEXIT_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}
		
		public int GetLastStepHaltingNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<int>(
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