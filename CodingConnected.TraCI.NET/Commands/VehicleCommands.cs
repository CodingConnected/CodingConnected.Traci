using System;
using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class VehicleCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public TraCIResponse<int> GetIdCount()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}
 
		public TraCIResponse<double> GetSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEED);
		}

		public TraCIResponse<Position2D> GetPosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position2D>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_POSITION);
		}

		public TraCIResponse<Position3D> GetPosition3D(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position3D>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_POSITION3D);
		}

		public TraCIResponse<double> GetAngle(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ANGLE);
		}
 
		public TraCIResponse<string> GetRoadID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROAD_ID);
		}
 
		public TraCIResponse<string> GetLaneID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LANE_ID);
		}
 
		public TraCIResponse<int> GetLaneIndex(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LANE_INDEX);
		}
 
		public TraCIResponse<string> GetTypeID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_TYPE);
		}

		public TraCIResponse<string> GetRouteID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROUTE_ID);
		}
 
		public TraCIResponse<int> GetRouteIndex(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROUTE_ID);
		}
 
		public TraCIResponse<List<string>> GetRoute(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROUTE);
		}

		public TraCIResponse<Color> GetColor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}
 
		public TraCIResponse<double> GetLanePosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LANEPOSITION);
		}

		public TraCIResponse<double> GetDistance(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_DISTANCE);
		}
 
		public TraCIResponse<int> GetSignals(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SIGNALS);
		}
 
		public TraCIResponse<double> GetCO2Emission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_CO2EMISSION);
		}
 
		public TraCIResponse<double> GetCOEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_COEMISSION);
		}
 
		public TraCIResponse<double> GetHCEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_HCEMISSION);
		}
 
		public TraCIResponse<double> GetPMxEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_PMXEMISSION);
		}
 
		public TraCIResponse<double> GetNOxEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_NOXEMISSION);
		}
 
		public TraCIResponse<double> GetFuelConsumption(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_FUELCONSUMPTION);
		}
 
		public TraCIResponse<double> GetNoiseEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_NOISEEMISSION);
		}
 
		public TraCIResponse<double> GetElectricityConsumption(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
		}
 
		public TraCIResponse<object> GetBestLanes(string id)
		{
			// TODO; handle compound data (see http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval)
			throw new NotSupportedException("TODO: interpret compound object");
			//return
			//	TraCICommandHelper.ExecuteCommand<int>(
			//		Client,
			//		id,
			//		TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
			//		TraCIConstants.TL_NEXT_SWITCH);
		}
 
		public TraCIResponse<byte> GetStopState(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<byte>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_STOPSTATE);
		}

		public TraCIResponse<double> GetLength(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}

		public TraCIResponse<double> GetMaxSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED);
		}

		public TraCIResponse<double> GetAccel(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ACCEL);
		}

		public TraCIResponse<double> GetDecel(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_DECEL);
		}
 
		public TraCIResponse<double> GetTau(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_TAU);
		}

		public TraCIResponse<double> GetImperfection(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_IMPERFECTION);
		}

		public TraCIResponse<double> GetSpeedFactor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEED_FACTOR);
		}

		public TraCIResponse<double> GetSpeedDeviation(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEED_DEVIATION);
		}

		public TraCIResponse<string> GetVehicleClass(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_VEHICLECLASS);
		}
 
		public TraCIResponse<string> GetEmissionClass(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_EMISSIONCLASS);
		}
 
		public TraCIResponse<string> GetShapeClass(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SHAPECLASS);
		}
 
		public TraCIResponse<double> GetMinGap(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_MINGAP);
		}
 
		public TraCIResponse<double> GetWidth(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_WIDTH);
		}

		public TraCIResponse<double> GetHeight(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_HEIGHT);
		}

		public TraCIResponse<double> GetWaitingTime(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_WAITING_TIME);
		}

		public TraCIResponse<double> GetAccumulatedWaitingTime(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ACCUMULATED_WAITING_TIME);
		}

		public TraCIResponse<object> GetNextTLS(string id)
		{
			// TODO; handle compound data (see http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval)
			throw new NotSupportedException("TODO: interpret compound object");
			//return
			//	TraCICommandHelper.ExecuteCommand<int>(
			//		Client,
			//		id,
			//		TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
			//		TraCIConstants.TL_NEXT_SWITCH);
		}
 
		public TraCIResponse<int> GetSpeedMode(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEEDSETMODE);
		}

		public TraCIResponse<double> GetSlope(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SLOPE);
		}
 
		public TraCIResponse<double> GetAllowedSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ALLOWED_SPEED);
		}
 
		public TraCIResponse<string> GetLine(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LINE);
		}

		public TraCIResponse<int> GetPersonNumber(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_PERSON_NUMBER);
		}

		public TraCIResponse<List<string>> GetVia(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_VIA);
		}

		public TraCIResponse<double> GetSpeedWithoutTraCI(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEED_WITHOUT_TRACI);
		}
 
		// TODO this returns bool: how does that work?
		public TraCIResponse<int> IsRouteValid(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROUTE_VALID);
		}
 
		public TraCIResponse<double> GetLateralLanePosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LANEPOSITION_LAT);
		}
 
		public TraCIResponse<double> GetMaxSpeedLat(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED_LAT);
		}
 
		public TraCIResponse<double> GetMinGapLat(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_MINGAP_LAT);
		}
 
		public TraCIResponse<string> GetLateralAlignment(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LATALIGNMENT);
		}
 
		public TraCIResponse<string> GetParameter(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_PARAMETER);
		}
 
		public TraCIResponse<double> GetActionStepLength(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					#warning This deviates: constants file is different from website (http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval)
					0x7d);
		}
  
		public TraCIResponse<double> GetLastActionTime(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					#warning see above
					0x7f);
		}

		// TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval

		#endregion // Public Methods

		#region Constructor

		public VehicleCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}