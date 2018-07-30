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

        public void SetCompleteRedYellowGreenDefinition(string id, string programId, int phaseIndex, List<TraCITrafficLightPhase> phases)
        {
            var bytes = new List<byte> { TraCIConstants.TL_COMPLETE_PROGRAM_RYG }; //messageType (0x2c)
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_COMPOUND); //value type compound
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(5 + (phases.Count * 4))); //item number
            bytes.Add(TraCIConstants.TYPE_STRING); //value type string
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(programId)); //program ID
            bytes.Add(TraCIConstants.TYPE_INTEGER); //value type integer
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(0)); //Type (always 0)
            bytes.Add(TraCIConstants.TYPE_COMPOUND); //value type compound
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(0));//Compound Length (always 0!)
            bytes.Add(TraCIConstants.TYPE_INTEGER); //value type integer
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(phaseIndex)); //Phase Index
            bytes.Add(TraCIConstants.TYPE_INTEGER); //value type integer
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(phases.Count)); //Phase Number

            foreach (var p in phases)//Phases
            {
                bytes.Add(TraCIConstants.TYPE_INTEGER); //value type integer
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(p.Duration)); //Duration[ms]
                bytes.Add(TraCIConstants.TYPE_INTEGER); //value type integer
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(0)); //unused
                bytes.Add(TraCIConstants.TYPE_INTEGER); //value type integer
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(0)); //unused
                bytes.Add(TraCIConstants.TYPE_STRING); //value type string
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(p.State)); //State (light/priority-tuple)
            }

            var command = new TraCICommand
            {
                Identifier = TraCIConstants.CMD_SET_TL_VARIABLE,
                Contents = bytes.ToArray()
            };

            var response = Client.SendMessage(command);

            try
            {
                TraCIDataConverter.ExtractDataFromResponse(response, TraCIConstants.CMD_SET_TL_VARIABLE, TraCIConstants.TL_COMPLETE_PROGRAM_RYG);
            }
            catch
            {
                throw;
            }
        }

    
    #endregion // Public Methods

    #region Constructor

    public TrafficLightCommands(TraCIClient client) : base(client)
		{
		}

		#endregion // Constructor
	}
}