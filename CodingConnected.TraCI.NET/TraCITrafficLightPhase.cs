using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET
{
    /// <summary>
    /// see http://sumo.dlr.de/wiki/Simulation/Traffic_Lights#Defining_New_TLS-Programs
    /// </summary>
    public class TraCITrafficLightPhase
    {
        /// <summary>
        /// Duration in ms
        /// </summary>
        public int Duration;

        public string State;
    }
}
