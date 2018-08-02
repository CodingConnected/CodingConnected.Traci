using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class EdgeCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList ()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public TraCIResponse<int> GetIdCount ()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public TraCIResponse<int> GetLaneNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_LANE_INDEX);
		}

		public TraCIResponse<double> GetTraveltime (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_CURRENT_TRAVELTIME);
		}

		public TraCIResponse<double> GetCO2Emission (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_CO2EMISSION);
		}

		public TraCIResponse<double> GetCOEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_COEMISSION);
		}

		public TraCIResponse<double> GetHCEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_HCEMISSION);
		}

		public TraCIResponse<double> GetPMxEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_PMXEMISSION);
		}

		public TraCIResponse<double> GetNOxEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_NOXEMISSION);
		}

		public TraCIResponse<double> GetFuelConsumption (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_FUELCONSUMPTION);
		}

		public TraCIResponse<double> GetNoiseEmission (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_NOISEEMISSION);
		}

		public TraCIResponse<double> GetElectricityConsumption (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
		}

		public TraCIResponse<int> GetLastStepVehicleNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.STOP_CONTAINER_STOP);
		}

		public TraCIResponse<double> GetLastStepMeanSpeed (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.TYPE_COLOR);
		}

		public TraCIResponse<List<string>> GetLastStepVehicleIDs (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.LAST_STEP_VEHICLE_ID_LIST);
		}

		public TraCIResponse<double> GetLastStepOccupancy (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.LAST_STEP_OCCUPANCY);
		}

		public TraCIResponse<double> GetLastStepLength (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.LAST_STEP_LENGTH);
		}

		public TraCIResponse<double> GetWaitingTime (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.VAR_WAITING_TIME);
		}

		public TraCIResponse<List<string>> GetLastStepPersonIDs (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_EDGE_VARIABLE,
					TraCIConstants.LAST_STEP_PERSON_ID_LIST);
		}

		public TraCIResponse<int> GetLastStepHaltingNumber(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
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

