using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class LaneCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public TraCIResponse<int> GetIdCount()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public TraCIResponse<byte> GetLinkNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<byte>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_LINK_NUMBER);
		}

		public TraCIResponse<string> GetEdgeId(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_EDGE_ID);
		}

		public TraCIResponse<object> GetLinks(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<object>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_LINKS);
		}

		public TraCIResponse<List<string>> GetAllowed(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_ALLOWED);
		}

		public TraCIResponse<List<string>> GetDisallowed(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_DISALLOWED);
		}

		public TraCIResponse<double> GetLength(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}

		public TraCIResponse<double> GetMaxSpeed(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED);
		}

		public TraCIResponse<Polygon> GetShape(string id)
		{
            return 
				TraCICommandHelper.ExecuteGetCommand<Polygon>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_SHAPE);
		}

		public TraCIResponse<double> GetWidth(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_WIDTH);
		}

		public TraCIResponse<double> GetCO2Emission(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_CO2EMISSION);
		}

		public TraCIResponse<double> GetCOEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_COEMISSION);
		}

		public TraCIResponse<double> GetHCEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_HCEMISSION);
		}

		public TraCIResponse<double> GetPMxEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_PMXEMISSION);
		}

		public TraCIResponse<double> GetNOxEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_NOXEMISSION);
		}

		public TraCIResponse<double> GetFuelConsumption(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_FUELCONSUMPTION);
		}

		public TraCIResponse<double> GetNoiseEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_NOISEEMISSION);
		}

		public TraCIResponse<double> GetElectricityConsumption(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
		}

		public TraCIResponse<int> GetLastStepVehicleNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
		}

		public TraCIResponse<double> GetLastStepMeanSpeed(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_MEAN_SPEED);
		}

		public TraCIResponse<List<string>> GetLastStepVehicleIds(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}

		public TraCIResponse<double> GetLastStepOccupancy(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_OCCUPANCY);
		}

		public TraCIResponse<double> GetLastStepLength(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_LENGTH);
		}

		public TraCIResponse<double> GetWaitingTime(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_WAITING_TIME);
		}

		public TraCIResponse<double> GetTravelTime(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_CURRENT_TRAVELTIME);
		}

		public TraCIResponse<int> GetLastStepHaltingNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER);
		}

        /// <summary>
        /// Sets a list of allowed vehicle classes.
        /// </summary>
        public TraCIResponse<object> SetAllowed(string laneId, List<string> allowedVehicleClasses)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, List<string>>(
                Client,
                laneId,
                TraCIConstants.CMD_SET_LANE_VARIABLE,
                TraCIConstants.LANE_ALLOWED,
                allowedVehicleClasses);
        }

        /// <summary>
        /// Sets a list of disallowed vehicle classes.
        /// </summary>
        public TraCIResponse<object> SetDisallowed(string laneId, List<string> disallowedVehicleClasses)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, List<string>>(
                Client,
                laneId,
                TraCIConstants.CMD_SET_LANE_VARIABLE,
                TraCIConstants.LANE_DISALLOWED,
                disallowedVehicleClasses);
        }

        /// <summary>
        /// Sets the length of the lane in m
        /// </summary>
        public TraCIResponse<object> SetLength(string laneId, double length)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                Client,
                laneId,
                TraCIConstants.CMD_SET_LANE_VARIABLE,
                TraCIConstants.VAR_LENGTH,
                length);
        }

        /// <summary>
        /// Sets a new maximum allowed speed on the lane in m/s.
        /// </summary>
        public TraCIResponse<object> SetMaxSpeed(string laneId, double maxSpeed)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                Client,
                laneId,
                TraCIConstants.CMD_SET_LANE_VARIABLE,
                TraCIConstants.VAR_MAXSPEED,
                maxSpeed);
        }
        #endregion // Public Methods

        #region Constructor

        public LaneCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}