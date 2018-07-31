using System;
using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class VehicleCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIdList()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public int GetIdCount()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}
 
		public double GetSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEED);
		}

		public Position2D GetPosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position2D>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_POSITION);
		}

		public Position3D GetPosition3D(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position3D>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_POSITION3D);
		}

		public double GetAngle(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ANGLE);
		}
 
		public string GetRoadID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROAD_ID);
		}
 
		public string GetLaneID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LANE_ID);
		}
 
		public int GetLaneIndex(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LANE_INDEX);
		}
 
		public string GetTypeID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_TYPE);
		}

		public string GetRouteID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROUTE_ID);
		}
 
		public int GetRouteIndex(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROUTE_ID);
		}
 
		public List<string> GetRoute(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROUTE);
		}

		public Color GetColor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}
 
		public double GetLanePosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LANEPOSITION);
		}

		public double GetDistance(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_DISTANCE);
		}
 
		public int GetSignals(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SIGNALS);
		}
 
		public double GetCO2Emission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_CO2EMISSION);
		}
 
		public double GetCOEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_COEMISSION);
		}
 
		public double GetHCEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_HCEMISSION);
		}
 
		public double GetPMxEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_PMXEMISSION);
		}
 
		public double GetNOxEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_NOXEMISSION);
		}
 
		public double GetFuelConsumption(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_FUELCONSUMPTION);
		}
 
		public double GetNoiseEmission(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_NOISEEMISSION);
		}
 
		public double GetElectricityConsumption(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
		}
 
		public object GetBestLanes(string id)
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
 
		public byte GetStopState(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<byte>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_STOPSTATE);
		}

		public double GetLength(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}

		public double GetMaxSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED);
		}

		public double GetAccel(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ACCEL);
		}

		public double GetDecel(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_DECEL);
		}
 
		public double GetTau(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_TAU);
		}

		public double GetImperfection(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_IMPERFECTION);
		}

		public double GetSpeedFactor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEED_FACTOR);
		}

		public double GetSpeedDeviation(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEED_DEVIATION);
		}

		public string GetVehicleClass(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_VEHICLECLASS);
		}
 
		public string GetEmissionClass(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_EMISSIONCLASS);
		}
 
		public string GetShapeClass(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SHAPECLASS);
		}
 
		public double GetMinGap(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_MINGAP);
		}
 
		public double GetWidth(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_WIDTH);
		}

		public double GetHeight(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_HEIGHT);
		}

		public double GetWaitingTime(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_WAITING_TIME);
		}

		public double GetAccumulatedWaitingTime(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ACCUMULATED_WAITING_TIME);
		}

		public object GetNextTLS(string id)
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
 
		public int GetSpeedMode(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEEDSETMODE);
		}

		public double GetSlope(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SLOPE);
		}
 
		public double GetAllowedSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ALLOWED_SPEED);
		}
 
		public string GetLine(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LINE);
		}

		public int GetPersonNumber(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_PERSON_NUMBER);
		}

		public List<string> GetVia(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_VIA);
		}

		public double GetSpeedWithoutTraCI(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_SPEED_WITHOUT_TRACI);
		}
 
		// TODO this returns bool: how does that work?
		public int IsRouteValid(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_ROUTE_VALID);
		}
 
		public double GetLateralLanePosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LANEPOSITION_LAT);
		}
 
		public double GetMaxSpeedLat(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED_LAT);
		}
 
		public double GetMinGapLat(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_MINGAP_LAT);
		}
 
		public string GetLateralAlignment(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_LATALIGNMENT);
		}
 
		public string GetParameter(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					TraCIConstants.VAR_PARAMETER);
		}
 
		public double GetActionStepLength(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
					#warning This deviates: constants file is different from website (http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval)
					0x7d);
		}
  
		public double GetLastActionTime(string id)
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