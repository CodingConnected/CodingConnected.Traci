using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class LaneCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIdList()
		{
			return 
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public int GetIdCount()
		{
			return 
				TraCICommandHelper.ExecuteCommand<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public byte GetLinkNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<byte>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_LINK_NUMBER);
		}

		public string GetEdgeId(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_EDGE_ID);
		}

		public object GetLinks(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<object>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_LINKS);
		}

		public List<string> GetAllowed(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_ALLOWED);
		}

		public List<string> GetDisallowed(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LANE_DISALLOWED);
		}

		public double GetLength(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}

		public double GetMaxSpeed(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED);
		}

		public object GetShape(string id)
		{
			// TODO; handle compound data (see http://sumo.dlr.de/wiki/TraCI/Traffic_Lights_Value_Retrieval)
			// Question here: is it returned as compound data, or as a shape?
			//throw new NotSupportedException("TODO: interpret compound object");
			return 
				TraCICommandHelper.ExecuteCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_SHAPE);
		}

		public double GetWidth(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_WIDTH);
		}

		public double GetCO2Emission(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_CO2EMISSION);
		}

		public double GetCOEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_COEMISSION);
		}

		public double GetHCEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_HCEMISSION);
		}

		public double GetPMxEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_PMXEMISSION);
		}

		public double GetNOxEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_NOXEMISSION);
		}

		public double GetFuelConsumption(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_FUELCONSUMPTION);
		}

		public double GetNoiseEmission(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_NOISEEMISSION);
		}

		public double GetElectricityConsumption(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
		}

		public int GetLastStepVehicleNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_NUMBER);
		}

		public double GetLastStepMeanSpeed(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_MEAN_SPEED);
		}

		public List<string> GetLastStepVehicleIds(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}

		public double GetLastStepOccupancy(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_OCCUPANCY);
		}

		public double GetLastStepLength(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_LENGTH);
		}

		public double GetWaitingTime(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_WAITING_TIME);
		}

		public double GetTravelTime(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<double>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.VAR_CURRENT_TRAVELTIME);
		}

		public int GetLastStepHaltingNumber(string id)
		{
			return 
				TraCICommandHelper.ExecuteCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_LANE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER);
		}
				
		#endregion // Public Methods
		
		#region Constructor

		public LaneCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}