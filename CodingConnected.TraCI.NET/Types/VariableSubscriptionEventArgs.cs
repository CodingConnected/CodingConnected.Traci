using System.Collections.Generic;

namespace CodingConnected.TraCI.NET.Types
{
    public class VariableSubscriptionEventArgs : SubscriptionEventArgs
    {
        public IReadOnlyDictionary<byte, IResponseInfo> ResponseByVariableCode { get; }
        public VariableSubscriptionEventArgs(IReadOnlyDictionary<byte, IResponseInfo> responseByVariableCode)
        {
            ResponseByVariableCode = responseByVariableCode;
        }
    }
}
