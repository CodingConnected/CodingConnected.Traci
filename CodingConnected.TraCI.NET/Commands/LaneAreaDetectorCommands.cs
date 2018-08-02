using System;
using System.Collections.Generic;
using System.Linq;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class LaneAreaDetectorCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.ID_LIST);
		}
		
		public TraCIResponse<int> GetIdCount()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public TraCIResponse<double> GetPosition(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.VAR_POSITION);
		}

		public TraCIResponse<double> GetLength(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}

		public TraCIResponse<string> GetLaneId(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.VAR_LANE_ID);
		}
		
		public TraCIResponse<int> GetLastStepVehicleNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
		}

		public TraCIResponse<double> GetLastStepMeanSpeed(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.LAST_STEP_MEAN_SPEED);
		}

		public TraCIResponse<List<string>> GetLastStepVehicleIds(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}
		
		public TraCIResponse<double> GetLastStepOccupancy(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.LAST_STEP_OCCUPANCY);
		}
		
		public TraCIResponse<double> GetJamLengthMeters(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANEAREA_VARIABLE,
					TraCIConstants.JAM_LENGTH_METERS);
		}

		public TraCIResponse<double> GetJamLengthVehicle(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
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