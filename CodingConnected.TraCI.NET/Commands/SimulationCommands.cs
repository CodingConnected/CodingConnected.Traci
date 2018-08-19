using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class SimulationCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<int> GetCurrentTime (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TIME_STEP);
		}

		public TraCIResponse<int> GetLoadedNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_LOADED_VEHICLES_NUMBER);
		}

		public TraCIResponse<List<string>> GetLoadedIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_LOADED_VEHICLES_IDS);
		}

		public TraCIResponse<int> GetDepartedNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_DEPARTED_VEHICLES_NUMBER);
		}

		public TraCIResponse<List<string>> GetDepartedIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_DEPARTED_VEHICLES_IDS);
		}

		public TraCIResponse<int> GetStartingTeleportNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TELEPORT_STARTING_VEHICLES_NUMBER);
		}

		public TraCIResponse<List<string>> GetStartingTeleportIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TELEPORT_STARTING_VEHICLES_IDS);
		}

		public TraCIResponse<int> GetEndingTeleportNumber(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TELEPORT_ENDING_VEHICLES_NUMBER);
		}

		public TraCIResponse<List<string>> GetEndingTeleportIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TELEPORT_ENDING_VEHICLES_IDS);
		}

		public TraCIResponse<int> GetArrivedNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_ARRIVED_VEHICLES_NUMBER);
		}

		public TraCIResponse<List<string>> GetArrivedIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_ARRIVED_VEHICLES_IDS);
		}

		public TraCIResponse<BoundaryBox> GetNetBoundary (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<BoundaryBox>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_NET_BOUNDING_BOX);
		}

		public TraCIResponse<int> GetMinExpectedNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_MIN_EXPECTED_VEHICLES);
		}

		public TraCIResponse<int> GetStopStartingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_STOP_STARTING_VEHICLES_NUMBER);
		}

		public TraCIResponse<List<string>> GetStopStartingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_STOP_STARTING_VEHICLES_IDS);
		}

		public TraCIResponse<int> GetStopEndingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_STOP_ENDING_VEHICLES_NUMBER);
		}

		public TraCIResponse<List<string>> GetStopEndingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_STOP_ENDING_VEHICLES_IDS);
		}

		public TraCIResponse<int> GetCollidingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					// TODO Check
					TraCIConstants.ADD);
		}

		public TraCIResponse<List<string>> GetCollidingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					// TODO Check
					TraCIConstants.REMOVE);
		}

		public TraCIResponse<int> GetParkingStartingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARKING_STARTING_VEHICLES_NUMBER);
		}

		public TraCIResponse<List<string>> GetParkingStartingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARKING_STARTING_VEHICLES_IDS);
		}

		public TraCIResponse<int> GetParkingEndingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARKING_ENDING_VEHICLES_NUMBER);
		}

		public TraCIResponse<List<string>> GetParkingEndingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARKING_ENDING_VEHICLES_IDS);
		}

		public TraCIResponse<int> GetBusStopWaiting (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_BUS_STOP_WAITING);
		}

		public TraCIResponse<int> GetDeltaT (string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_DELTA_T);
		}

		public TraCIResponse<string> GetParameter(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARAMETER);
		}

        // TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Simulation_Value_Retrieval

        public TraCIResponse<object> ClearPending(string id, string routeId)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_SIM_VARIABLE,
                    TraCIConstants.CMD_CLEAR_PENDING_VEHICLES,
                    routeId
                    );
        }

        public TraCIResponse<object> SaveState(string id, string filename)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_SIM_VARIABLE,
                    TraCIConstants.CMD_SAVE_SIMSTATE,
                    filename
                    );
        }
        #endregion // Public Methods

        #region Constructor

        public SimulationCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

