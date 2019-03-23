using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET
{
    public class TraCIVariableSubscriptionResponse : TraCISubscriptionResponse
    {
        internal Dictionary<byte, IResponseInfo> responseByVariableCode { get; }

        public TraCIVariableSubscriptionResponse(string objectId, byte responseCode)
            : base(objectId, responseCode) => responseByVariableCode = new Dictionary<byte, IResponseInfo>();

        public IReadOnlyDictionary<byte, IResponseInfo> ResponseByVariableCode { get => responseByVariableCode; }

        public override IEnumerable<object> Responses { get => ResponseByVariableCode.Values; }
    }
}
