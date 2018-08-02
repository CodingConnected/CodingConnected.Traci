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

		#endregion // Public Methods

		#region Constructor

		public PolygonCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

