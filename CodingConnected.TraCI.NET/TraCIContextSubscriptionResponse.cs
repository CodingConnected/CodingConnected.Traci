using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET
{
    public class TraCIContextSubscriptionResponse : TraCISubscriptionResponse
    {
        public override IEnumerable<object> Responses => VariableSubscriptionByObjectId.Values;

        internal Dictionary<string, TraCIVariableSubscriptionResponse> VariableSubscriptionByObjectId { get; }

        public TraCIContextSubscriptionResponse(string objectId, byte responseCode)
            : base(objectId, responseCode) { VariableSubscriptionByObjectId = new Dictionary<string, TraCIVariableSubscriptionResponse>(); }
    }
}
