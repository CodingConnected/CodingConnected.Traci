using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class RouteCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_ROUTE_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public TraCIResponse<int> GetIdCount()
		{
			return
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_ROUTE_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public TraCIResponse<List<string>> GetEdges(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client,
					id,
					TraCIConstants.CMD_GET_ROUTE_VARIABLE,
					TraCIConstants.VAR_EDGES);
		}

		#endregion // Public Methods

		#region Constructor

		public RouteCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

