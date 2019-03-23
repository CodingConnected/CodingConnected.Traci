using System.Collections.Generic;

namespace CodingConnected.TraCI.NET.Types
{
    public class ContextSubscriptionEventArgs : SubscriptionEventArgs
    {
        /// <summary>
        /// Get the variable subscription of the object by the id of the object.
        /// The object was inside the context range of the object this subscription happened under.
        /// </summary>
        public IReadOnlyDictionary<string, TraCIVariableSubscriptionResponse> VariableSubscriptionByObjectId { get; }
        public ContextSubscriptionEventArgs(IReadOnlyDictionary<string, TraCIVariableSubscriptionResponse> variableSubscriptionResponseByObjectId)
        {
            VariableSubscriptionByObjectId = variableSubscriptionResponseByObjectId;
        }
    }
}
