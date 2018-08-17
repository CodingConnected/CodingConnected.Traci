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


        public TraCIResponse<object> Add(string id, string typeId, string initialEdgeId, int departTime, double departPosition)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIString() { Value = typeId });
            tmp.Value.Add(new TraCIString() { Value = initialEdgeId });
            tmp.Value.Add(new TraCIInteger() { Value = departTime });
            tmp.Value.Add(new TraCIDouble() { Value = departPosition });

            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_PERSON_VARIABLE,
                     TraCIConstants.ADD,
                     tmp
                     );
        }

        public TraCIResponse<object> AppendDrivingStage(string id, string destination, string lines, string stopId )
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIInteger() { Value = 3 });
            tmp.Value.Add(new TraCIString() { Value = destination });
            tmp.Value.Add(new TraCIString() { Value = lines });
            tmp.Value.Add(new TraCIString() { Value = stopId });
            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.APPEND_STAGE,
                tmp
                );
        }

        public TraCIResponse<object> AppendWaitingStage(string id, int duration, string description, string stopId)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIInteger() { Value = 1 });
            tmp.Value.Add(new TraCIInteger() { Value = duration });
            tmp.Value.Add(new TraCIString() { Value = description });
            tmp.Value.Add(new TraCIString() { Value = stopId });
            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.APPEND_STAGE,
                tmp
                );
        }

        public TraCIResponse<object> AppendWalkingStage(string id,List<string> edges, double arrivalPosition, int duration,double speed, string stopId)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIInteger() { Value = 2 });
            tmp.Value.Add(new TraCIStringList() { Value = edges });
            tmp.Value.Add(new TraCIDouble() { Value = arrivalPosition });
            tmp.Value.Add(new TraCIString() { Value = stopId });
            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.APPEND_STAGE,
                tmp
                );
        }

        public TraCIResponse<object> RemoveStage(string id, int stageIndex)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, int>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.ADD,
                stageIndex
                );
        }

        public TraCIResponse<object> RerouteTraveltime(string id)
        {

            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.CMD_REROUTE_TRAVELTIME,
                new CompoundObject()
                );
        }

        public TraCIResponse<object> SetColor(string id, Color color)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, Color>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_COLOR,
                color
                );
        }

        public TraCIResponse<object> SetHeight(string id, double height)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_HEIGHT,
                height
                );
        }

        public TraCIResponse<object> SetLength(string id, double length)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.ADD,
                length
                );
        }

        public TraCIResponse<object> SetMinGap(string id, double minGap)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_MINGAP,
                minGap
                );
        }

        public TraCIResponse<object> SetSpeed(string id, double speed)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_SPEED_FACTOR,
                speed
                );
        }

        public TraCIResponse<object> SetType(string id, string typeId)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_TYPE,
                typeId
                );
        }

        public TraCIResponse<object> SetWidth(string id, double width)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                Client,
                id,
                TraCIConstants.CMD_SET_PERSON_VARIABLE,
                TraCIConstants.VAR_WIDTH,
                width
                );
        }
        
            
            
            
            
        #endregion // Public Methods

        #region Constructor

        public PersonCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}