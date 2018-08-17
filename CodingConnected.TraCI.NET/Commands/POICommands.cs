using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class POICommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public TraCIResponse<int> GetIdCount()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public TraCIResponse<string> GetType(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.VAR_TYPE);
		}

		public TraCIResponse<Color> GetColor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}

		public TraCIResponse<Position2D> GetPosition(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position2D>(
				Client,
				id,
				TraCIConstants.CMD_GET_POI_VARIABLE,
				TraCIConstants.VAR_POSITION);
		}

        public TraCIResponse<object> SetType(string id, string type)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.VAR_TYPE,
                    type
                    );
        }

        public TraCIResponse<object> SetColor(string id, Color color)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, Color>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.VAR_COLOR,
                    color
                    );
        }

        public TraCIResponse<object> SetPosition(string id, Position2D position2D)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, Position2D>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.VAR_POSITION,
                    position2D
                    );
        }

        public TraCIResponse<object> Add(string id, string name, Color color, int layer, Position2D position2D)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIString() { Value = name });
            tmp.Value.Add(color);
            tmp.Value.Add(new TraCIInteger() { Value = layer });
            tmp.Value.Add(position2D);
            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.ADD,
                    tmp
                    );
        }

        public TraCIResponse<object> Remove(string id, int layer)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, int>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POI_VARIABLE,
                    TraCIConstants.REMOVE,
                    layer
                    );
        }

        #endregion // Public Methods

        #region Constructor

        public POICommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

