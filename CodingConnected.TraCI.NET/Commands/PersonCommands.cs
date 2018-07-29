using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class PersonCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIdList()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.ID_LIST);
		}
 
		public int GetIdCount()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.ID_COUNT);
		}
 
		public double GetSpeed(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_SPEED);
		}
 
		public Position2D GetPosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position2D>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_POSITION);
		}
 
		public Position3D GetPosition3D(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position3D>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_POSITION3D);
		}
 
		public double GetAngle(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_ANGLE);
		}
 
		public string GetRoadID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_ROAD_ID);
		}
 
		public string GetTypeID(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_TYPE);
		}
 
		public Color GetColor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}
 
		public double GetLanePosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_LANEPOSITION);
		}
 
		public double GetLength(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_LENGTH);
		}
 
		public double GetMinGap(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_MINGAP);
		}
 
		public double GetWidth(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_WIDTH);
		}
 
		public double GetWaitingTime(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_WAITING_TIME);
		}
 
		public string GetNextEdge(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_NEXT_EDGE);
		}
 
		public int GetRemainingStages(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					id,
					TraCIConstants.CMD_GET_PERSON_VARIABLE,
					TraCIConstants.VAR_STAGES_REMAINING);
		}
 
		public string GetVehicle(string id)
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