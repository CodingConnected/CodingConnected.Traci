using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class VehicleTypeCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public TraCIResponse<int> GetIdCount()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public TraCIResponse<double> GetLength(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}

		public TraCIResponse<double> GetMaxSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED);
		}

		public TraCIResponse<double> GetAccel(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_ACCEL);
		}

		public TraCIResponse<double> GetDecel(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_DECEL);
		}

		public TraCIResponse<double> GetTau(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_TAU);
		}

		public TraCIResponse<double> GetImperfection(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_IMPERFECTION);
		}

		public TraCIResponse<double> GetSpeedFactor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_SPEED_FACTOR);
		}

		public TraCIResponse<double> GetSpeedDeviation(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_SPEED_DEVIATION);
		}

		public TraCIResponse<string> GetVehicleClass(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_VEHICLECLASS);
		}

		public TraCIResponse<string> GetEmissionClass(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_EMISSIONCLASS);
		}

		public TraCIResponse<string> GetShapeClass(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_SHAPECLASS);
		}

		public TraCIResponse<double> GetMinGap(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_MINGAP);
		}

		public TraCIResponse<double> GetWidth(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_WIDTH);
		}

		public TraCIResponse<double> GetHeight(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_HEIGHT);
		}

		public TraCIResponse<Color> GetColor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}

		public TraCIResponse<double> GetMaxSpeedLat(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_MAXSPEED_LAT);
		}

		public TraCIResponse<double> GetMinGapLat(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_MINGAP_LAT);
		}

		public TraCIResponse<string> GetLateralAlignment(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
					TraCIConstants.VAR_LATALIGNMENT);
		}

		public TraCIResponse<double> GetActionStepLength(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
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