using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class EdgeCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIDList ()
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public int GetIDCount ()
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public int GetLaneNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_LANE_INDEX);
		}

		public double GetTraveltime (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_CURRENT_TRAVELTIME);
		}

		public double GetCO2Emission (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_CO2EMISSION);
		}

		public double GetCOEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_COEMISSION);
		}

		public double GetHCEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_HCEMISSION);
		}

		public double GetPMxEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_PMXEMISSION);
		}

		public double GetNOxEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_NOXEMISSION);
		}

		public double GetFuelConsumption (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_FUELCONSUMPTION);
		}

		public double GetNoiseEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_NOISEEMISSION);
		}

		public double GetElectricityConsumption (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
		}

		public int GetLastStepVehicleNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.STOP_CONTAINER_STOP);
		}

		public double GetLastStepMeanSpeed (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.TYPE_COLOR);
		}

		public List<string> GetLastStepVehicleIDs (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}

		public double GetLastStepOccupancy (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.LAST_STEP_OCCUPANCY);
		}

		public double GetLastStepLength (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.LAST_STEP_LENGTH);
		}

		public double GetWaitingTime (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_WAITING_TIME);
		}

		public List<string> GetLastStepPersonIDs (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.LAST_STEP_PERSON_ID_LIST);
		}

		public int GetLastStepHaltingNumber(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_HALTING_NUMBER);
		}

		// TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Edge_Value_Retrieval

		#endregion // Public Methods

		#region Constructor

		public EdgeCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

