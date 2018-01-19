using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class JunctionCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIDList ()
		{
			return
				TraCICommandHelper.ExecuteCommand<List<string>>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_JUNCTION_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public int GetIDCount ()
		{
			return
				TraCICommandHelper.ExecuteCommand<int>(
					Client,
					"ignored",
					TraCIConstants.CMD_GET_JUNCTION_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public Position2D GetPosition(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<Position2D>(
					Client,
					id,
					TraCIConstants.CMD_GET_JUNCTION_VARIABLE,
					TraCIConstants.VAR_POSITION);
		}

		public Polygon GetShape(string id)
		{
			return
				TraCICommandHelper.ExecuteCommand<Polygon>(
				Client,
				id,
				TraCIConstants.CMD_GET_JUNCTION_VARIABLE,
				TraCIConstants.VAR_SHAPE);
		}

		#endregion // Public Methods

		#region Constructor

		public JunctionCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

