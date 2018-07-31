using System;
using System.Collections.Generic;

namespace CodingConnected.TraCI.NET.Helpers
{
	internal static class TraCICommandHelper
	{
        internal static Tres ExecuteSetCommand<Tres, Tvalue>(TraCIClient client, string id, byte commandType, byte messageType, Tvalue value)
        {
            TraCICommand command = null;

            switch (value)
            {
                case int i:
                    command = GetCommand(id, commandType, messageType, i);
                    break;
                case double d:
                    command = GetCommand(id, commandType, messageType, d);
                    break;
                case string s:
                    command = GetCommand(id, commandType, messageType, s);
                    break;
                case List<string> los:
                    command = GetCommand(id, commandType, messageType, los);
                    break;
                default:
                    {
                        throw new InvalidCastException($"Type {value.GetType().Name} is not implemented in method TraCICommandHelper.ExecuteSetCommand().");
                    }
            }

            if (command != null)
            {
                var response = client.SendMessage(command);

                try
                {
                    return (Tres)TraCIDataConverter.ExtractDataFromResponse(response, commandType, messageType);
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                return default(Tres);
            }
        }

        internal static T ExecuteGetCommand<T>(TraCIClient client, string id, byte commandType, byte messageType)
        {
            var command = GetCommand(id, commandType, messageType);
            var response = client.SendMessage(command);

            try
            {

                return (T)TraCIDataConverter.ExtractDataFromResponse(response, commandType, messageType);
            }
            catch
            {
                throw;
            }
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType)
		{
			var bytes = new List<byte> { messageType };
			bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
			var command = new TraCICommand
			{
				Identifier = commandType,
				Contents = bytes.ToArray()
			};
			return command;
		}

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, List<string> values)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            
            if (values != null && values.Count > 0)
            {
                bytes.Add(TraCIConstants.TYPE_STRINGLIST);
                bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(values.Count));
                foreach (var parameter in values)
                {
                    bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(parameter));
                }
            }
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, string value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_STRING);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, double value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_DOUBLE);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromDouble(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        internal static TraCICommand GetCommand(string id, byte commandType, byte messageType, int value)
        {
            var bytes = new List<byte> { messageType };
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromASCIIString(id));
            bytes.Add(TraCIConstants.TYPE_INTEGER);
            bytes.AddRange(TraCIDataConverter.GetTraCIBytesFromInt32(value));
            var command = new TraCICommand
            {
                Identifier = commandType,
                Contents = bytes.ToArray()
            };
            return command;
        }

        
    }
}

