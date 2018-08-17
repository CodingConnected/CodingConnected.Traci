using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class PolygonCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_POLYGON_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public TraCIResponse<int> GetIdCount()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_POLYGON_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public TraCIResponse<string> GetType(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_POLYGON_VARIABLE,
					TraCIConstants.VAR_TYPE);
		}

		public TraCIResponse<Color> GetColor(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_POLYGON_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}

		public TraCIResponse<Polygon> GetShape(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Polygon>(
					Client,
					id,
					TraCIConstants.CMD_GET_POLYGON_VARIABLE,
					TraCIConstants.VAR_SHAPE);
		}

		public TraCIResponse<byte> GetFilled(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<byte>(
					Client,
					id,
					TraCIConstants.CMD_GET_POLYGON_VARIABLE,
					TraCIConstants.VAR_FILL);
		}

        public TraCIResponse<object> SetType(string id, string typeId)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                    TraCIConstants.VAR_TYPE,
                    typeId
                    );
        }

        public TraCIResponse<object> SetColor(string id, Color color)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, Color>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                    TraCIConstants.VAR_COLOR,
                    color
                    );
        }

        public TraCIResponse<object> SetShape(string id, Polygon polygon)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, Polygon>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                    TraCIConstants.VAR_SHAPE,
                    polygon
                    );
        }

        public TraCIResponse<object> SetFilled(string id, byte filled)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, byte>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                    TraCIConstants.VAR_FILL,
                    filled
                    );
        }

        public TraCIResponse<object> Add(string id, string name,Color color, bool filled, int layer, Polygon shape)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIString() { Value = name });
            tmp.Value.Add(color);
            tmp.Value.Add(new TraCIUByte() { Value = filled == false ? (byte)0: (byte)1 });
            tmp.Value.Add(shape);

            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                    TraCIConstants.ADD,
                    tmp
                    );
        }

        public TraCIResponse<object> Remove(string id, int layer)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, int>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_POLYGON_VARIABLE,
                    TraCIConstants.REMOVE,
                    layer
                    );
        }

        #endregion // Public Methods

        #region Constructor

        public PolygonCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

