using System;
using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;

namespace CodingConnected.TraCI.NET.Commands
{
	public class TrafficLightCommands : TraCICommandsBase
	{
		#region Public Methods

		public List<string> GetIdList()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public int GetIdCount()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public string GetState(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_RED_YELLOW_GREEN_STATE);
		}

		public int GetPhaseDuration(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_PHASE_DURATION);
		}

		public List<string> GetControlledLanes(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_CONTROLLED_LANES);
		}

		public object GetControlledLinks(string id)
		{
			// TODO; handle compound data (see http://sumo.dlr.de/wiki/TraCI/Traffic_Lights_Value_Retrieval)
			throw new NotSupportedException("TODO: interpret compound object");
			//return 
			//	TraCICommandHelper.ExecuteCommand<List<string>>(
			//		Client, 
			//		id, 
			//		TraCIConstants.CMD_GET_TL_VARIABLE,
			//		TraCIConstants.TL_CONTROLLED_LINKS);
		}

		public int GetCurrentPhase(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_CURRENT_PHASE);
		}

		public string GetCurrentProgram(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_CURRENT_PROGRAM);
		}

		public object GetCompleteDefinition(string id)
		{
			// TODO; handle compound data (see http://sumo.dlr.de/wiki/TraCI/Traffic_Lights_Value_Retrieval)
			throw new NotSupportedException("TODO: interpret compound object");
			//return 
			//	TraCICommandHelper.ExecuteCommand<string>(
			//		Client, 
			//		id, 
			//		TraCIConstants.CMD_GET_TL_VARIABLE,
			//		TraCIConstants.TL_COMPLETE_DEFINITION_RYG);
		}
		
		public int GetNextSwitch(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_NEXT_SWITCH);
		}
		

        public void SetRedYellowGreenState(string id, string state)
        {
            TraCICommandHelper.ExecuteSetCommand<object, string>(
                Client,
                id,
                TraCIConstants.CMD_SET_TL_VARIABLE,
                TraCIConstants.TL_RED_YELLOW_GREEN_STATE,
                state);
        }

        public void SetPhase(string id, int phaseIndex)
        {
            TraCICommandHelper.ExecuteSetCommand<object, int>(
                Client,
                id,
                TraCIConstants.CMD_SET_TL_VARIABLE,
                TraCIConstants.TL_PHASE_INDEX,
                phaseIndex);
        }

        public void SetProgram(string id, string program)
        {
            TraCICommandHelper.ExecuteSetCommand<object, string>(
                Client,
                id,
                TraCIConstants.CMD_SET_TL_VARIABLE,
                TraCIConstants.TL_PROGRAM,
                program);
        }

        public void SetDuration(string id, int phaseDuration)
        {
            TraCICommandHelper.ExecuteSetCommand<object, int>(
                Client,
                id,
                TraCIConstants.CMD_SET_TL_VARIABLE,
                TraCIConstants.TL_PHASE_DURATION,
                phaseDuration);
        }

        public void SetCompleteRedYellowGreenDefinition()
        {
            throw new NotImplementedException();
        }
        #endregion // Public Methods

        #region Constructor

        public TrafficLightCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}