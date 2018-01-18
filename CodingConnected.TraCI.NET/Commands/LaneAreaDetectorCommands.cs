using System;
using System.Collections.Generic;
using System.Linq;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class LaneAreaDetectorCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIdList()
		{
			return 
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.ID_LIST);
		}
		
		public int GetIdCount()
		{
			return 
				TraCICommandHelper.ExecuteCommand<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public double GetPosition(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.VAR_POSITION);
		}

		public double GetLength(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}

		public string GetLaneId(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.VAR_LANE_ID);
		}
		
		public int GetLastStepVehicleNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
		}

		public double GetLastStepMeanSpeed(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.LAST_STEP_MEAN_SPEED);
		}

		public List<string> GetLastStepVehicleIds(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}
		
		public double GetLastStepOccupancy(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.LAST_STEP_OCCUPANCY);
		}
		
		public double GetJamLengthMeters(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.JAM_LENGTH_METERS);
		}

		public double GetJamLengthVehicle(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.JAM_LENGTH_VEHICLE);
		}

		#endregion // Public Methods

		#region Constructor

		public LaneAreaDetectorCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}