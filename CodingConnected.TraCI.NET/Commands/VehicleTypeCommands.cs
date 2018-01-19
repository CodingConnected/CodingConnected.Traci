using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class VehicleTypeCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIdList()
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public int GetIdCount()
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public double GetLength(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}

		public double GetMaxSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED);
		}

		public double GetAccel(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_ACCEL);
		}

		public double GetDecel(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_DECEL);
		}

		public double GetTau(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_TAU);
		}

		public double GetImperfection(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_IMPERFECTION);
		}

		public double GetSpeedFactor(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_SPEED_FACTOR);
		}

		public double GetSpeedDeviation(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_SPEED_DEVIATION);
		}

		public string GetVehicleClass(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_VEHICLECLASS);
		}

		public string GetEmissionClass(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_EMISSIONCLASS);
		}

		public string GetShapeClass(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_SHAPECLASS);
		}

		public double GetMinGap(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_MINGAP);
		}

		public double GetWidth(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_WIDTH);
		}

		public double GetHeight(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_HEIGHT);
		}

		public Color GetColor(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}

		public double GetMaxSpeedLat(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED_LAT);
		}

		public double GetMinGapLat(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_MINGAP_LAT);
		}

		public string GetLateralAlignment(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_LATALIGNMENT);
		}

		public double GetActionStepLength(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					#warning Check this
					TraCIConstants.VAR_MIN_EXPECTED_VEHICLES);
		}

		#endregion // Public Methods

		#region Constructor

		public VehicleTypeCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}