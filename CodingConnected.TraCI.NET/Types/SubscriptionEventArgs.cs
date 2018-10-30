using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET.Types
{
    public class SubscriptionEventArgs : EventArgs
    {
        public string ObjecId;

        public List<object> Responses;

        public int Length
        {
            get
            {
                if (Responses != null)
                {
                    return Responses.Count();
                }
                else
                {
                    return 0;
                }
            }
        }
        public SubscriptionEventArgs()
        {

        }
    }
}
