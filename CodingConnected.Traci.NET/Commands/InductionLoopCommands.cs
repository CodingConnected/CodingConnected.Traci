using System;
using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class InductionLoopCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIdList()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public int GetIdCount()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public double GetPosition(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.VAR_POSITION);
		}

		public string GetLaneId(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.VAR_LANE_ID);
		}

		public int GetLastStepVehicleNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
		}

		public double GetLastStepMeanSpeed(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.LAST_STEP_MEAN_SPEED);
		}

		public List<string> GetLastStepVehicleIds(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}

		public double GetLastStepOccupancy(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.LAST_STEP_OCCUPANCY);
		}

		public double GetLastStepMeanLength(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.LAST_STEP_LENGTH);
		}

		public double GetTimeSinceDetection(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_INDUCTIONLOOP_VARIABLE,
					TraCIConstants.LAST_STEP_TIME_SINCE_DETECTION);
		}

		public List<object> GetVehicleData(string id)
		{
			// TODO: implement reading this data (http://sumo.dlr.de/wiki/TraCI/Induction_Loop_Value_Retrieval#Response_to_.22last_step.27s_vehicle_data.22_.280x17.29)
			throw new NotSupportedException("This method return complex data; TODO");
		}
		#endregion // Public Methods

		#region Constructor

		public InductionLoopCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}