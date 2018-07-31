using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET.Types
{

    /// <summary>
    /// see http://sumo.dlr.de/wiki/Simulation/Traffic_Lights#Defining_New_TLS-Programs
    /// </summary>
    public class TrafficLightProgram : ComposedTypeBase
    {
        /// <summary>
        /// Name of the program
        /// </summary>
        public string ProgramId;

        /// <summary>
        /// Number of phase to start with
        /// </summary>
        public int PhaseIndex;

        /// <summary>
        /// List of phases
        /// </summary>
        public List<TrafficLightProgramPhase> Phases;

        public TrafficLightProgram()
        {
            Phases = new List<TrafficLightProgramPhase>();
        }

    }

    public class TrafficLightProgramPhase
    {
        /// <summary>
        /// Duration in ms
        /// </summary>
        public int Duration;

        public string State;
    }
}
