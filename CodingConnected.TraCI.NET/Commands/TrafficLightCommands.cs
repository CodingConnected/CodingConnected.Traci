using System;
using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
	public class TrafficLightCommands : TraCICommandsBase
	{
		#region Public Methods

		public TraCIResponse<List<string>> GetIdList()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.ID_LIST);
		}

		public TraCIResponse<int> GetIdCount()
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					"ignored", 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.ID_COUNT);
		}

		public TraCIResponse<string> GetState(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_RED_YELLOW_GREEN_STATE);
		}

		public TraCIResponse<int> GetPhaseDuration(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_PHASE_DURATION);
		}

		public TraCIResponse<List<string>> GetControlledLanes(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<List<string>>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_CONTROLLED_LANES);
		}

		public TraCIResponse<ControlledLinks> GetControlledLinks(string id)
		{
            var tmp = TraCICommandHelper.ExecuteGetCommand<List<ComposedTypeBase>>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_TL_VARIABLE,
                    TraCIConstants.TL_CONTROLLED_LINKS);

            var controlledLinks = TraCIDataConverter.ConvertToControlledLinks(tmp.Content);

            var ret = new TraCIResponse<ControlledLinks>
            {
                Content = controlledLinks,
                ErrorMessage = tmp.ErrorMessage,
                Identifier = tmp.Identifier,
                ResponseIdentifier = tmp.ResponseIdentifier,
                Result = tmp.Result,
                Variable = tmp.Variable
            };

            return ret;
        }

		public TraCIResponse<int> GetCurrentPhase(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_CURRENT_PHASE);
		}

		public TraCIResponse<string> GetCurrentProgram(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<string>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_CURRENT_PROGRAM);
		}

		public TraCIResponse<object> GetCompleteDefinition(string id)
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
		
		public TraCIResponse<int> GetNextSwitch(string id)
		{
			return 
				TraCICommandHelper.ExecuteGetCommand<int>(
					Client, 
					id, 
					TraCIConstants.CMD_GET_TL_VARIABLE,
					TraCIConstants.TL_NEXT_SWITCH);
		}
		

        public TraCIResponse<object> SetRedYellowGreenState(string id, string state)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                Client,
                id,
                TraCIConstants.CMD_SET_TL_VARIABLE,
                TraCIConstants.TL_RED_YELLOW_GREEN_STATE,
                state);
        }

        public TraCIResponse<object> SetPhase(string id, int phaseIndex)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, int>(
                Client,
                id,
                TraCIConstants.CMD_SET_TL_VARIABLE,
                TraCIConstants.TL_PHASE_INDEX,
                phaseIndex);
        }

        public TraCIResponse<object> SetProgram(string id, string program)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                Client,
                id,
                TraCIConstants.CMD_SET_TL_VARIABLE,
                TraCIConstants.TL_PROGRAM,
                program);
        }

        public TraCIResponse<object> SetDuration(string id, int phaseDuration)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, int>(
                Client,
                id,
                TraCIConstants.CMD_SET_TL_VARIABLE,
                TraCIConstants.TL_PHASE_DURATION,
                phaseDuration);
        }

        public TraCIResponse<object>SetCompleteRedYellowGreenDefinition(string id, TrafficLightProgram program)
        {
            var bytes = new List<byte> { TraCIConstants.TL_COMPLETE_PROGRAM_RYG }; //messageType (0x2c)
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_COMPOUND); //value type compound
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(5 + (program.Phases.Count * 4))); //item number
            bytes.Add(TraCIConstants.TYPE_STRING); //value type string
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(program.ProgramId)); //program ID
            bytes.Add(TraCIConstants.TYPE_INTEGER); //value type integer
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(0)); //Type (always 0)
            bytes.Add(TraCIConstants.TYPE_COMPOUND); //value type compound
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(0));//Compound Length (always 0!)
            bytes.Add(TraCIConstants.TYPE_INTEGER); //value type integer
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(program.PhaseIndex)); //Phase Index
            bytes.Add(TraCIConstants.TYPE_INTEGER); //value type integer
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(program.Phases.Count)); //Phase Number

            foreach (var p in program.Phases)//Phases
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

#warning is the try catch necessary?
            try
            {
                return TraCIDataConverter.ExtractDataFromResponse<object>(response, TraCIConstants.CMD_SET_TL_VARIABLE, TraCIConstants.TL_COMPLETE_PROGRAM_RYG);
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