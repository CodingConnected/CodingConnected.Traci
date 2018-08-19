using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class GuiCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<double> GetZoom(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<double>(
					Client,
					id,
					TraCIConstants.CMD_GET_GUI_VARIABLE,
					TraCIConstants.VAR_VIEW_ZOOM);
		}

		public TraCIResponse<Position2D> GetOffset(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Position2D>(
				Client,
				id,
				TraCIConstants.CMD_GET_GUI_VARIABLE,
				TraCIConstants.VAR_VIEW_OFFSET);
		}

		public TraCIResponse<string> GetSchema(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client,
					id,
					TraCIConstants.CMD_GET_GUI_VARIABLE,
					TraCIConstants.VAR_VIEW_SCHEMA);
		}

		public TraCIResponse<Polygon> GetBoundary(string id)
		{
			return
				TraCICommandHelper.ExecuteGetCommand<Polygon>(
				Client,
				id,
				TraCIConstants.CMD_GET_GUI_VARIABLE,
				TraCIConstants.VAR_VIEW_BOUNDARY);
		}


        public TraCIResponse<object> SetZoom(string id, double zoom)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_ZOOM,
                    zoom
                    );
        }

        public TraCIResponse<object> SetOffset(string id, Position2D position)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, Position2D>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_OFFSET,
                    position
                    );
        }

        public TraCIResponse<object> SetSchema(string id, string schema)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_SCHEMA,
                    schema
                    );
        }

        public TraCIResponse<object> SetBoundary(string id, BoundaryBox boundaryBox)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, BoundaryBox>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_VIEW_BOUNDARY,
                    boundaryBox
                    );
        }

        public TraCIResponse<object> screenshot(string id, string filename)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_SCREENSHOT,
                    filename
                    );
        }

        public TraCIResponse<object> TrackVehicle(string id, string vehicleId)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_GUI_VARIABLE,
                    TraCIConstants.VAR_TRACK_VEHICLE,
                    vehicleId
                    );
        }
        #endregion // Public Methods

        #region Constructor

        public GuiCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}

