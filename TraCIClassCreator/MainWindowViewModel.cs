using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using CodingConnected.TraCI.NET;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace TraCIClassCreator
{
	public class MainWindowViewModel : ViewModelBase
	{
		#region Fields

		private RelayCommand _processTextCommand;
		private string _inputText;
		private string _outputText;
		private string _commandText;
		private string _className;

		#endregion // Fields

		#region Properties

		public string ClassName
		{
			get => _className;
			set
			{
				_className = value; 
				RaisePropertyChanged();
			}
		}

		public string CommandText
		{
			get => _commandText;
			set
			{
				_commandText = value; 
				RaisePropertyChanged();
			}
		}

		public string InputText
		{
			get => _inputText;
			set
			{
				_inputText = value; 
				RaisePropertyChanged();
			}
		}

		public string OutputText
		{
			get => _outputText;
			set
			{
				_outputText = value; 
				RaisePropertyChanged();
			}
		}

		#endregion // Properties

		#region Commands

		public ICommand ProcessTextCommand => _processTextCommand ?? (_processTextCommand = new RelayCommand(ProcessTextCommand_executed));

		#endregion // Commands

		#region Command Functionality

		private void ProcessTextCommand_executed()
		{
			if (string.IsNullOrWhiteSpace(InputText)) return;

			var sb = new StringBuilder();

			sb.AppendLine("using System.Collections.Generic;");
			sb.AppendLine("using CodingConnected.TraCI.NET.Helpers;");
			sb.AppendLine();
			sb.AppendLine("namespace CodingConnected.TraCI.NET.Commands");
			sb.AppendLine("{");
			sb.AppendLine($"\tpublic class {ClassName} : TraCICommandsBase");
			sb.AppendLine("\t{");
			sb.AppendLine("\t\t#region Public Methods");
			sb.AppendLine();

			foreach (var l in InputText.Replace("\r", "").Split('\n'))
			{
				var fields = l.Split(new[]{';'}, StringSplitOptions.RemoveEmptyEntries);
				if (fields.Length == 3)
				{
					var imessage = Convert.ToInt32(Regex.Replace(fields[0], @".*[0-9]x([a-z0-9][a-z0-9]).*", "$1"), 16);
					var message = FindConstantName(typeof(Constants), (byte)imessage);
					var type = fields[1];
					if (type == "stringList") type = "List<string>";
					var function = FirstCharToUpper(fields[2]);

					sb.AppendLine($"\t\tpublic {type} {function}(string id)");
					sb.AppendLine("\t\t{");
					sb.AppendLine("\t\t\treturn");
					sb.AppendLine($"\t\t\t\tTraCICommandHelper.ExecuteCommand<{type}>(");
					sb.AppendLine("\t\t\t\t\tClient,");
					sb.AppendLine("\t\t\t\t\tid,");
					sb.AppendLine($"\t\t\t\t\tTraCIConstants.{CommandText},");
					sb.AppendLine($"\t\t\t\t\tTraCIConstants.{message});");
					sb.AppendLine("\t\t}");
					sb.AppendLine();
				}
			}

			sb.AppendLine("\t\t#endregion // Public Methods");
			sb.AppendLine();
			sb.AppendLine("\t\t#region Constructor");
			sb.AppendLine();
			sb.AppendLine($"\t\tpublic {ClassName}(TraCIClient client) : base(client)");
			sb.AppendLine("\t\t{");
			sb.AppendLine("\t\t}");
			sb.AppendLine();
			sb.AppendLine("\t\t#endregion // Constructor");
			sb.AppendLine("\t}");
			sb.AppendLine("}");
			sb.AppendLine();

			OutputText = sb.ToString();
		}

		#endregion // Command Functionality

		#region Private Methods

		private string FindConstantName<T>(Type containingType, T value)
		{
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;

			foreach (var field in containingType.GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				if (field.FieldType == typeof(T) &&
				    comparer.Equals(value, (T) field.GetValue(null)))
				{
					return field.Name; // There could be others, of course...
				}
			}
			return null; // Or throw an exception
		}

		private string FirstCharToUpper(string input)
		{
			switch (input)
			{
				case null: throw new ArgumentNullException(nameof(input));
				case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
				default: return input.First().ToString().ToUpper() + input.Substring(1);
			}
		}

		#endregion // Private Methods
	}

	internal class Constants
	{
		// ****************************************
        // POSITION REPRESENTATIONS
        // ****************************************
        // Position in geo-coordinates
        public const byte POSITION_LON_LAT = 0x00;
        // 2D cartesian coordinates
        public const byte POSITION_2D = 0x01;
        // Position in geo-coordinates with altitude
        public const byte POSITION_LON_LAT_ALT = 0x02;
        // 3D cartesian coordinates
        public const byte POSITION_3D = 0x03;
        // Position on road map
        public const byte POSITION_ROADMAP = 0x04;


        // ****************************************
        // DATA TYPES
        // ****************************************
        // Boundary Box (4 doubles)
        public const byte TYPE_BOUNDINGBOX = 0x05;
        // Polygon (2*n doubles)
        public const byte TYPE_POLYGON = 0x06;
        // unsigned byte
        public const byte TYPE_UBYTE = 0x07;
        // signed byte
        public const byte TYPE_BYTE = 0x08;
        // 32 bit signed integer
        public const byte TYPE_INTEGER = 0x09;
        // float
        public const byte TYPE_FLOAT = 0x0A;
        // double
        public const byte TYPE_DOUBLE = 0x0B;
        // 8 bit ASCII string
        public const byte TYPE_STRING = 0x0C;
        // list of traffic light phases
        public const byte TYPE_TLPHASELIST = 0x0D;
        // list of strings
        public const byte TYPE_STRINGLIST = 0x0E;
        // compound object
        public const byte TYPE_COMPOUND = 0x0F;
        // color (four ubytes)
        public const byte TYPE_COLOR = 0x11;


        // ****************************************
        // RESULT TYPES
        // ****************************************
        // result type: Ok
        public const byte RTYPE_OK = 0x00;
        // result type: not implemented
        public const byte RTYPE_NOTIMPLEMENTED = 0x01;
        // result type: error
        public const byte RTYPE_ERR = 0xFF;

        // return value for invalid queries (especially vehicle is not on the road)
        public const double INVALID_DOUBLE_VALUE = -1001.0;
        // return value for invalid queries (especially vehicle is not on the road)
        public const short INVALID_INT_VALUE = -1;
        // maximum value for client ordering (2 ^ 30 - 1)
        public const uint MAX_ORDER = 1073741823;

        // ****************************************
        // TRAFFIC LIGHT PHASES
        // ****************************************
        // red phase
        public const byte TLPHASE_RED = 0x01;
        // yellow phase
        public const byte TLPHASE_YELLOW = 0x02;
        // green phase
        public const byte TLPHASE_GREEN = 0x03;
        // tl is blinking
        public const byte TLPHASE_BLINKING = 0x04;
        // tl is off and not blinking
        public const byte TLPHASE_NOSIGNAL = 0x05;


        // ****************************************
        // DIFFERENT DISTANCE REQUESTS
        // ****************************************
        // air distance
        public const byte REQUEST_AIRDIST = 0x00;
        // driving distance
        public const byte REQUEST_DRIVINGDIST = 0x01;


        // ****************************************
        // VEHICLE REMOVAL REASONS
        // ****************************************
        // vehicle started teleport
        public const byte REMOVE_TELEPORT = 0x00;
        // vehicle removed while parking
        public const byte REMOVE_PARKING = 0x01;
        // vehicle arrived
        public const byte REMOVE_ARRIVED = 0x02;
        // vehicle was vaporized
        public const byte REMOVE_VAPORIZED = 0x03;
        // vehicle finished route during teleport
        public const byte REMOVE_TELEPORT_ARRIVED = 0x04;

        // ****************************************
        // PERSON/CONTAINER STAGES
        // ****************************************
        // person / container stopping
        public const byte STAGE_WAITING_FOR_DEPART = 0x00;
        // person / container stopping
        public const byte STAGE_WAITING = 0x01;
        // person walking / container transhiping
        public const byte STAGE_WALKING = 0x02;
        // person riding / container being transported
        public const byte STAGE_DRIVING = 0x03;

        // ****************************************
        // Stop Flags
        // ****************************************
        public const byte STOP_DEFAULT = 0x00;
        public const byte STOP_PARKING = 0x01;
        public const byte STOP_TRIGGERED = 0x02;
        public const byte STOP_CONTAINER_TRIGGERED = 0x04;
        public const byte STOP_BUS_STOP = 0x08;
        public const byte STOP_CONTAINER_STOP = 0x10;
        public const byte STOP_CHARGING_STATION = 0x20;
        public const byte STOP_PARKING_AREA = 0x40;

        // ****************************************
        // Departure Flags
        // ****************************************
        public const short DEPARTFLAG_TRIGGERED = -0x01;
        public const short DEPARTFLAG_CONTAINER_TRIGGERED = -0x02;
        public const short DEPARTFLAG_NOW = -0x03;
        public const short DEPARTFLAG_SPEED_RANDOM = -0x02;
        public const short DEPARTFLAG_SPEED_MAX = -0x03;
        public const short DEPARTFLAG_LANE_RANDOM = -0x02;
        public const short DEPARTFLAG_LANE_FREE = -0x03;
        public const short DEPARTFLAG_LANE_ALLOWED_FREE = -0x04;
        public const short DEPARTFLAG_LANE_BEST_FREE = -0x05;
        public const short DEPARTFLAG_LANE_FIRST_ALLOWED = -0x06;

        // ****************************************
        // VARIABLE TYPES (for CMD_GET_*_VARIABLE)
        // ****************************************
        // list of instances' ids (get: all)
        public const byte ID_LIST = 0x00;

        // count of instances (get: all)
        public const byte ID_COUNT = 0x01;

        // subscribe object variables (get: all)
        public const byte AUTOMATIC_VARIABLES_SUBSCRIPTION = 0x02;

        // subscribe context variables (get: all)
        public const byte AUTOMATIC_CONTEXT_SUBSCRIPTION = 0x03;

        // generic attributes (get/set: all)
        public const byte GENERIC_ATTRIBUTE = 0x03;

        // last step vehicle number (get: induction loops, multi-entry/multi-exit detector, lanes, edges)
        public const byte LAST_STEP_VEHICLE_NUMBER = 0x10;

        // last step vehicle number (get: induction loops, multi-entry/multi-exit detector, lanes, edges)
        public const byte LAST_STEP_MEAN_SPEED = 0x11;

        // last step vehicle list (get: induction loops, multi-entry/multi-exit detector, lanes, edges)
        public const byte LAST_STEP_VEHICLE_ID_LIST = 0x12;

        // last step occupancy (get: induction loops, lanes, edges)
        public const byte LAST_STEP_OCCUPANCY = 0x13;

        // last step vehicle halting number (get: multi-entry/multi-exit detector, lanes, edges)
        public const byte LAST_STEP_VEHICLE_HALTING_NUMBER = 0x14;

        // last step mean vehicle length (get: induction loops, lanes, edges)
        public const byte LAST_STEP_LENGTH = 0x15;

        // last step time since last detection (get: induction loops)
        public const byte LAST_STEP_TIME_SINCE_DETECTION = 0x16;

        // entry times
        public const byte LAST_STEP_VEHICLE_DATA = 0x17;

        // last step jam length in vehicles
        public const byte JAM_LENGTH_VEHICLE = 0x18;

        // last step jam length in meters
        public const byte JAM_LENGTH_METERS = 0x19;

        // last step person list (get: edges)
        public const byte LAST_STEP_PERSON_ID_LIST = 0x1a;


        // traffic light states, encoded as rRgGyYoO tuple (get: traffic lights)
        public const byte TL_RED_YELLOW_GREEN_STATE = 0x20;

        public const byte TL_RED_YELLOW_GREEN_SINGLESTATE = 0x21;

        // index of the phase (set: traffic lights)
        public const byte TL_PHASE_INDEX = 0x22;

        // traffic light program (set: traffic lights)
        public const byte TL_PROGRAM = 0x23;

        // phase duration (set: traffic lights)
        public const byte TL_PHASE_DURATION = 0x24;

        // controlled lanes (get: traffic lights)
        public const byte TL_CONTROLLED_LANES = 0x26;

        // controlled links (get: traffic lights)
        public const byte TL_CONTROLLED_LINKS = 0x27;

        // index of the current phase (get: traffic lights)
        public const byte TL_CURRENT_PHASE = 0x28;

        // name of the current program (get: traffic lights)
        public const byte TL_CURRENT_PROGRAM = 0x29;

        // controlled junctions (get: traffic lights)
        public const byte TL_CONTROLLED_JUNCTIONS = 0x2a;

        // complete definition (get: traffic lights)
        public const byte TL_COMPLETE_DEFINITION_RYG = 0x2b;

        // complete program (set: traffic lights)
        public const byte TL_COMPLETE_PROGRAM_RYG = 0x2c;

        // assumed time to next switch (get: traffic lights)
        public const byte TL_NEXT_SWITCH = 0x2d;

        // current state, using external signal names (get: traffic lights)
        public const byte TL_EXTERNAL_STATE = 0x2e;

        // outgoing link number (get: lanes)
        public const byte LANE_LINK_NUMBER = 0x30;

        // id of parent edge (get: lanes)
        public const byte LANE_EDGE_ID = 0x31;

        // outgoing link definitions (get: lanes)
        public const byte LANE_LINKS = 0x33;

        // list of allowed vehicle classes (get&set: lanes)
        public const byte LANE_ALLOWED = 0x34;

        // list of not allowed vehicle classes (get&set: lanes)
        public const byte LANE_DISALLOWED = 0x35;

        // slope (get: edge, lane, vehicle, person)
        public const byte VAR_SLOPE = 0x36;

        // speed (get: vehicle)
        public const byte VAR_SPEED = 0x40;

        // maximum allowed/possible speed (get: vehicle types, lanes, set: edges, lanes)
        public const byte VAR_MAXSPEED = 0x41;

        // position (2D) (get: vehicle, poi, inductionloop, areadetector; set: poi)
        public const byte VAR_POSITION = 0x42;

        // position (3D) (get: vehicle, poi, set: poi)
        public const byte VAR_POSITION3D = 0x39;

        // angle (get: vehicle)
        public const byte VAR_ANGLE = 0x43;

        // angle (get: vehicle types, lanes, arealdetector, set: lanes)
        public const byte VAR_LENGTH = 0x44;

        // color (get: vehicles, vehicle types, polygons, pois)
        public const byte VAR_COLOR = 0x45;

        // max. acceleration (get: vehicles, vehicle types)
        public const byte VAR_ACCEL = 0x46;

        // max. comfortable deceleration (get: vehicles, vehicle types)
        public const byte VAR_DECEL = 0x47;

        // max. (physically possible) deceleration (get: vehicles, vehicle types)
        public const byte VAR_EMERGENCY_DECEL = 0x7b;

        // apparent deceleration (get: vehicles, vehicle types)
        public const byte VAR_APPARENT_DECEL = 0x7c;

        // driver's desired headway (get: vehicle types)
        public const byte VAR_TAU = 0x48;

        // vehicle class (get: vehicle types)
        public const byte VAR_VEHICLECLASS = 0x49;

        // emission class (get: vehicle types)
        public const byte VAR_EMISSIONCLASS = 0x4a;

        // shape class (get: vehicle types)
        public const byte VAR_SHAPECLASS = 0x4b;

        // minimum gap (get: vehicle types)
        public const byte VAR_MINGAP = 0x4c;

        // width (get: vehicle types, lanes)
        public const byte VAR_WIDTH = 0x4d;

        // shape (get: polygons)
        public const byte VAR_SHAPE = 0x4e;

        // type id (get: vehicles, polygons, pois)
        public const byte VAR_TYPE = 0x4f;

        // road id (get: vehicles)
        public const byte VAR_ROAD_ID = 0x50;

        // lane id (get: vehicles, inductionloop, arealdetector)
        public const byte VAR_LANE_ID = 0x51;

        // lane index (get: vehicles)
        public const byte VAR_LANE_INDEX = 0x52;

        // route id (get & set: vehicles)
        public const byte VAR_ROUTE_ID = 0x53;

        // edges (get: routes, vehicles)
        public const byte VAR_EDGES = 0x54;

        // filled? (get: polygons)
        public const byte VAR_FILL = 0x55;

        // position (1D along lane) (get: vehicle)
        public const byte VAR_LANEPOSITION = 0x56;

        // route (set: vehicles)
        public const byte VAR_ROUTE = 0x57;

        // travel time information (get&set: vehicle)
        public const byte VAR_EDGE_TRAVELTIME = 0x58;

        // effort information (get&set: vehicle)
        public const byte VAR_EDGE_EFFORT = 0x59;

        // last step travel time (get: edge, lane)
        public const byte VAR_CURRENT_TRAVELTIME = 0x5a;

        // signals state (get/set: vehicle)
        public const byte VAR_SIGNALS = 0x5b;

        // new lane/position along (set: vehicle)
        public const byte VAR_MOVE_TO = 0x5c;

        // driver imperfection (set: vehicle)
        public const byte VAR_IMPERFECTION = 0x5d;

        // speed factor (set: vehicle)
        public const byte VAR_SPEED_FACTOR = 0x5e;

        // speed deviation (set: vehicle)
        public const byte VAR_SPEED_DEVIATION = 0x5f;


        // speed without TraCI influence (get: vehicle)
        public const byte VAR_SPEED_WITHOUT_TRACI = 0xb1;

        // best lanes (get: vehicle)
        public const byte VAR_BEST_LANES = 0xb2;

        // how speed is set (set: vehicle)
        public const byte VAR_SPEEDSETMODE = 0xb3;

        // move vehicle, VTD version (set: vehicle)
        public const byte MOVE_TO_XY = 0xb4;

        // is the vehicle stopped, and if so parked and/or triggered?
        // value = stopped + 2 * parking + 4 * triggered
        public const byte VAR_STOPSTATE = 0xb5;

        // how lane changing is performed (set: vehicle)
        public const byte VAR_LANECHANGE_MODE = 0xb6;

        // maximum speed regarding max speed on the current lane and speed factor (get: vehicle)
        public const byte VAR_ALLOWED_SPEED = 0xb7;

        // position (1D lateral position relative to center of the current lane) (get: vehicle)
        public const byte VAR_LANEPOSITION_LAT = 0xb8;

        // get/set prefered lateral alignment within the lane (vehicle)
        public const byte VAR_LATALIGNMENT = 0xb9;

        // get/set maximum lateral speed (vehicle, vtypes)
        public const byte VAR_MAXSPEED_LAT = 0xba;

        // get/set minimum lateral gap (vehicle, vtypes)
        public const byte VAR_MINGAP_LAT = 0xbb;

        // get/set vehicle height (vehicle, vtypes)
        public const byte VAR_HEIGHT = 0xbc;

        // get/set vehicle line
        public const byte VAR_LINE = 0xbd;

        // get/set vehicle via
        public const byte VAR_VIA = 0xbe;

        // current CO2 emission of a node (get: vehicle, lane, edge)
        public const byte VAR_CO2EMISSION = 0x60;

        // current CO emission of a node (get: vehicle, lane, edge)
        public const byte VAR_COEMISSION = 0x61;

        // current HC emission of a node (get: vehicle, lane, edge)
        public const byte VAR_HCEMISSION = 0x62;

        // current PMx emission of a node (get: vehicle, lane, edge)
        public const byte VAR_PMXEMISSION = 0x63;

        // current NOx emission of a node (get: vehicle, lane, edge)
        public const byte VAR_NOXEMISSION = 0x64;

        // current fuel consumption of a node (get: vehicle, lane, edge)
        public const byte VAR_FUELCONSUMPTION = 0x65;

        // current noise emission of a node (get: vehicle, lane, edge)
        public const byte VAR_NOISEEMISSION = 0x66;

        // current person number (get: vehicle)
        public const byte VAR_PERSON_NUMBER = 0x67;

        // number of persons waiting at a defined bus stop (get: simulation)
        public const byte VAR_BUS_STOP_WAITING = 0x67;

        // current leader together with gap (get: vehicle)
        public const byte VAR_LEADER = 0x68;

        // edge index in current route (get: vehicle)
        public const byte VAR_ROUTE_INDEX = 0x69;

        // current waiting time (get: vehicle, lane)
        public const byte VAR_WAITING_TIME = 0x7a;

        // current waiting time (get: vehicle)
        public const byte VAR_ACCUMULATED_WAITING_TIME = 0x87;

        // upcoming traffic lights (get: vehicle)
        public const byte VAR_NEXT_TLS = 0x70;

        // current time step (get: simulation)
        public const byte VAR_TIME_STEP = 0x70;

        // current electricity consumption of a node (get: vehicle, lane, edge)
        public const byte VAR_ELECTRICITYCONSUMPTION = 0x71;

        // number of loaded vehicles (get: simulation)
        public const byte VAR_LOADED_VEHICLES_NUMBER = 0x71;

        // loaded vehicle ids (get: simulation)
        public const byte VAR_LOADED_VEHICLES_IDS = 0x72;

        // number of departed vehicle (get: simulation)
        public const byte VAR_DEPARTED_VEHICLES_NUMBER = 0x73;

        // departed vehicle ids (get: simulation)
        public const byte VAR_DEPARTED_VEHICLES_IDS = 0x74;

        // number of vehicles starting to teleport (get: simulation)
        public const byte VAR_TELEPORT_STARTING_VEHICLES_NUMBER = 0x75;

        // ids of vehicles starting to teleport (get: simulation)
        public const byte VAR_TELEPORT_STARTING_VEHICLES_IDS = 0x76;

        // number of vehicles ending to teleport (get: simulation)
        public const byte VAR_TELEPORT_ENDING_VEHICLES_NUMBER = 0x77;

        // ids of vehicles ending to teleport (get: simulation)
        public const byte VAR_TELEPORT_ENDING_VEHICLES_IDS = 0x78;

        // number of arrived vehicles (get: simulation)
        public const byte VAR_ARRIVED_VEHICLES_NUMBER = 0x79;

        // ids of arrived vehicles (get: simulation)
        public const byte VAR_ARRIVED_VEHICLES_IDS = 0x7a;

        // delta t (get: simulation)
        public const byte VAR_DELTA_T = 0x7b;

        // bounding box (get: simulation)
        public const byte VAR_NET_BOUNDING_BOX = 0x7c;

        // minimum number of expected vehicles (get: simulation)
        public const byte VAR_MIN_EXPECTED_VEHICLES = 0x7d;

        // number of vehicles starting to park (get: simulation)
        public const byte VAR_STOP_STARTING_VEHICLES_NUMBER = 0x68;

        // ids of vehicles starting to park (get: simulation)
        public const byte VAR_STOP_STARTING_VEHICLES_IDS = 0x69;

        // number of vehicles ending to park (get: simulation)
        public const byte VAR_STOP_ENDING_VEHICLES_NUMBER = 0x6a;

        // ids of vehicles ending to park (get: simulation)
        public const byte VAR_STOP_ENDING_VEHICLES_IDS = 0x6b;

        // number of vehicles starting to park (get: simulation)
        public const byte VAR_PARKING_STARTING_VEHICLES_NUMBER = 0x6c;

        // ids of vehicles starting to park (get: simulation)
        public const byte VAR_PARKING_STARTING_VEHICLES_IDS = 0x6d;

        // number of vehicles ending to park (get: simulation)
        public const byte VAR_PARKING_ENDING_VEHICLES_NUMBER = 0x6e;

        // ids of vehicles ending to park (get: simulation)
        public const byte VAR_PARKING_ENDING_VEHICLES_IDS = 0x6f;

        // clears the simulation of all not inserted vehicles (set: simulation)
        public const byte CMD_CLEAR_PENDING_VEHICLES = 0x94;

        // triggers saving simulation state (set: simulation)
        public const byte CMD_SAVE_SIMSTATE = 0x95;

        // sets/retrieves abstract parameter
        public const byte VAR_PARAMETER = 0x7e;


        // add an instance (poi, polygon, vehicle, person, route)
        public const byte ADD = 0x80;

        // remove an instance (poi, polygon, vehicle, person)
        public const byte REMOVE = 0x81;

        // copy an instance (vehicle type, other TBD.)
        public const byte COPY = 0x88;

        // convert coordinates
        public const byte POSITION_CONVERSION = 0x82;

        // distance between points or vehicles
        public const byte DISTANCE_REQUEST = 0x83;

        // the current driving distance
        public const byte VAR_DISTANCE = 0x84;

        // add a fully specified instance (vehicle)
        public const byte ADD_FULL = 0x85;

        // force rerouting based on travel time (vehicles)
        public const byte CMD_REROUTE_TRAVELTIME = 0x90;

        // force rerouting based on effort (vehicles)
        public const byte CMD_REROUTE_EFFORT = 0x91;

        // validates current route (vehicles)
        public const byte VAR_ROUTE_VALID = 0x92;

        // retrieve information regarding the current person/container stage
        public const byte VAR_STAGE = 0xc0;

        // retrieve information regarding the next edge including crossings and walkingAreas (pedestrians only)
        public const byte VAR_NEXT_EDGE = 0xc1;

        // retrieve information regarding the number of remaining stages
        public const byte VAR_STAGES_REMAINING = 0xc2;

        // retrieve the current vehicle id for the driving stage (person, container)
        public const byte VAR_VEHICLE = 0xc3;

        // append a person stage (person)
        public const byte APPEND_STAGE = 0xc4;

        // append a person stage (person)
        public const byte REMOVE_STAGE = 0xc5;

        // zoom
        public const byte VAR_VIEW_ZOOM = 0xa0;

        // view position
        public const byte VAR_VIEW_OFFSET = 0xa1;

        // view schema
        public const byte VAR_VIEW_SCHEMA = 0xa2;

        // view by boundary
        public const byte VAR_VIEW_BOUNDARY = 0xa3;

        // screenshot
        public const byte VAR_SCREENSHOT = 0xa5;

        // track vehicle
        public const byte VAR_TRACK_VEHICLE = 0xa6;

	}
}