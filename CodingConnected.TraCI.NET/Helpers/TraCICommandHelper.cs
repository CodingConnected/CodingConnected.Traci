using System.Collections.Generic;

namespace CodingConnected.TraCI.NET.Helpers
{
	internal static class TraCICommandHelper
	{
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

		internal static T ExecuteCommand<T>(TraCIClient client, string id, byte commandType, byte messageType)
		{
			var command = GetCommand(id, commandType, messageType);
			var response = client.SendMessage(command);
			
			if (TraCIDataConverter.ExtractDataFromResponse(response, commandType, messageType, out var data))
			{
				return (T) data;
			}

			throw new TraCICommandException(commandType, messageType);
		}
	}
}