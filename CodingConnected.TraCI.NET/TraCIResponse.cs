using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConnected.TraCI.NET
{
    public enum ResultCode
    {
        Success,
        Failed,
        NotImplemented
    }

    public class TraCIResponse<T>
    {
        public byte Identifier { get; set; }

        public byte? ResponseIdentifier { get; set; }

        public ResultCode Result { get; set; }

        public T Content { get; set; }

        public string ErrorMessage { get; set; }

        public byte? Variable { get; set; }
    }
}
