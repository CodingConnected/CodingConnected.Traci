using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class POICommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIDList ()
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public int GetIDCount ()
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public string GetType (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.VAR_TYPE);
		}

		public Color GetColor (string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<Color>(
					Client,
					id,
					TraCIConstants.CMD_GET_POI_VARIABLE,
					TraCIConstants.VAR_COLOR);
		}

		public Position2D GetPosition(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<Position2D>(
				Client,
				id,
				TraCIConstants.CMD_GET_POI_VARIABLE,
				TraCIConstants.VAR_POSITION);
		}

		#endregion // Public Methods

		#region Constructor

		public POICommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

