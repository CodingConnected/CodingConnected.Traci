using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class SimulationCommands : TraCICommandsBase
	{
		#region Public Methods

		public int GetCurrentTime (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TIME_STEP);
		}

		public int GetLoadedNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_LOADED_VEHICLES_NUMBER);
		}

		public List<string> GetLoadedIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_LOADED_VEHICLES_IDS);
		}

		public int GetDepartedNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_DEPARTED_VEHICLES_NUMBER);
		}

		public List<string> GetDepartedIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_DEPARTED_VEHICLES_IDS);
		}

		public int GetStartingTeleportNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TELEPORT_STARTING_VEHICLES_NUMBER);
		}

		public List<string> GetStartingTeleportIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TELEPORT_STARTING_VEHICLES_IDS);
		}

		public int GetEndingTeleportNumber(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TELEPORT_ENDING_VEHICLES_NUMBER);
		}

		public List<string> GetEndingTeleportIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_TELEPORT_ENDING_VEHICLES_IDS);
		}

		public int GetArrivedNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_ARRIVED_VEHICLES_NUMBER);
		}

		public List<string> GetArrivedIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_ARRIVED_VEHICLES_IDS);
		}

		public BoundaryBox GetNetBoundary (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<BoundaryBox>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_NET_BOUNDING_BOX);
		}

		public int GetMinExpectedNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_MIN_EXPECTED_VEHICLES);
		}

		public int GetStopStartingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_STOP_STARTING_VEHICLES_NUMBER);
		}

		public List<string> GetStopStartingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_STOP_STARTING_VEHICLES_IDS);
		}

		public int GetStopEndingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_STOP_ENDING_VEHICLES_NUMBER);
		}

		public List<string> GetStopEndingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_STOP_ENDING_VEHICLES_IDS);
		}

		public int GetCollidingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					// TODO Check
					TraCIConstants.ADD);
		}

		public List<string> GetCollidingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					// TODO Check
					TraCIConstants.REMOVE);
		}

		public int GetParkingStartingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARKING_STARTING_VEHICLES_NUMBER);
		}

		public List<string> GetParkingStartingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARKING_STARTING_VEHICLES_IDS);
		}

		public int GetParkingEndingVehiclesNumber (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARKING_ENDING_VEHICLES_NUMBER);
		}

		public List<string> GetParkingEndingVehiclesIDList (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARKING_ENDING_VEHICLES_IDS);
		}

		public int GetBusStopWaiting (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_BUS_STOP_WAITING);
		}

		public int GetDeltaT (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_DELTA_T);
		}

		public string GetParameter(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_SIM_VARIABLE,
					TraCIConstants.VAR_PARAMETER);
		}

		// TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Simulation_Value_Retrieval

		#endregion // Public Methods

		#region Constructor

		public SimulationCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

