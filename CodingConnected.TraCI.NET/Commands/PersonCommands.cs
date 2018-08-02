using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class PersonCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.ID_LIST);
		}
 
		public TraCIResponse<int> GetIdCount()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.ID_COUNT);
		}
 
		public TraCIResponse<double> GetSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_SPEED);
		}
 
		public TraCIResponse<Position2D> GetPosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position2D>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_POSITION);
		}
 
		public TraCIResponse<Position3D> GetPosition3D(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position3D>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_POSITION3D);
		}
 
		public TraCIResponse<double> GetAngle(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_ANGLE);
		}
 
		public TraCIResponse<string> GetRoadID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_ROAD_ID);
		}
 
		public TraCIResponse<string> GetTypeID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_TYPE);
		}
 
		public TraCIResponse<Color> GetColor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}
 
		public TraCIResponse<double> GetLanePosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_LANEPOSITION);
		}
 
		public TraCIResponse<double> GetLength(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}
 
		public TraCIResponse<double> GetMinGap(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_MINGAP);
		}
 
		public TraCIResponse<double> GetWidth(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_WIDTH);
		}
 
		public TraCIResponse<double> GetWaitingTime(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_WAITING_TIME);
		}
 
		public TraCIResponse<string> GetNextEdge(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_NEXT_EDGE);
		}
 
		public TraCIResponse<int> GetRemainingStages(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_STAGES_REMAINING);
		}
 
		public TraCIResponse<string> GetVehicle(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_VEHICLE);
		}

		// TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Person_Value_Retrieval

		#endregion // Public Methods

		#region Constructor

		public PersonCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}