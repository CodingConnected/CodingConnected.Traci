using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class GuiCommands : TraCICommandsBase
	{
		#region Public Methods

		public double GetZoom(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_GUI_VARIABLE,
					TraCIConstants.VAR_VIEW_ZOOM);
		}

		public Position2D GetOffset(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position2D>(
				Client,
				id,
				TraCIConstants.CMD_GET_GUI_VARIABLE,
				TraCIConstants.VAR_VIEW_OFFSET);
		}

		public string GetSchema(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_GUI_VARIABLE,
					TraCIConstants.VAR_VIEW_SCHEMA);
		}

		public Polygon GetBoundary(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Polygon>(
				Client,
				id,
				TraCIConstants.CMD_GET_GUI_VARIABLE,
				TraCIConstants.VAR_VIEW_BOUNDARY);
		}

		#endregion // Public Methods

		#region Constructor

		public GuiCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

