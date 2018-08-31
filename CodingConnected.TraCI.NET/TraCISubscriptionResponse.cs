using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET
{
    public class TraCISubscriptionResponse
    {
        public string ObjectId;
        public byte ResponseCode;
        public List<object> Responses;

        public TraCISubscriptionResponse()
        {
            Responses = new List<object>();
        }
    }
}
