using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Helpers
{
	internal static class TraCIDataConverter
	{
		#region Static Methods

		internal static object ExtractDataFromResponse(TraCIResult[] response, byte commandType, byte messageType)
		{
			if (response?.Length > 0)
			{
				var r1 = response.FirstOrDefault(x => x.Identifier == commandType);
				if (r1?.Response[0] == 0x00) // Success
				{
					// check if first byte is as requested (it gives the type of data requested)
					var r2 = response.FirstOrDefault(x => x.Identifier == commandType + 0x10);
					if (r2?.Response[0] == messageType)
					{
						// after the type of data, there is the length of the id (a string that we will skip)
						var take = r2.Response.Skip(1).Take(4).Reverse().ToArray();
						var idl = BitConverter.ToInt32(take, 0);
						// after the string is the type of data returned
						var type = r2.Response[5 + idl];
						// now read and translate the data
						return GetValueFromTypeAndArray(type, r2.Response.Skip(6 + idl).ToArray());
					}

					throw new TraCICommandException(commandType, messageType, "No TraCI response was found in the data");
				}

				if (r1?.Response[0] == 0xFF) // Failed
				{
					var take = r1.Response.Skip(1).Take(4).Reverse().ToArray();
					var dlen = BitConverter.ToInt32(take, 0);
					var sb = new StringBuilder();
					var k1 = 5;
					for (var j = 0; j < dlen; ++j)
					{
						sb.Append((char)r1.Response[k1]);
						++k1;
					}
					throw new TraCICommandException(commandType, messageType, "TraCI reports command failure: " + sb);
				}

				if (r1?.Response[0] == 0x01) // Not implemented
				{
					var take = r1.Response.Skip(1).Take(4).Reverse().ToArray();
					var dlen = BitConverter.ToInt32(take, 0);
					var sb = new StringBuilder();
					var k1 = 5;
					for (var j = 0; j < dlen; ++j)
					{
						sb.Append((char)r1.Response[k1]);
						++k1;
					}
					throw new TraCICommandException(commandType, messageType, "TraCI reports command not implemented: " + sb);
				}
			}
			return null;
		}

		internal static byte[] GetTraCIBytesFromInt32(int i)
        {
            return BitConverter.GetBytes(i).Reverse().ToArray();
        }

        internal static byte[] GetTraCIBytesFromASCIIString(string s)
        {
            var bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(s.Length).Reverse());
            bytes.AddRange(Encoding.ASCII.GetBytes(s));
            return bytes.ToArray();
        }

        internal static object GetValueFromTypeAndArray(byte type, byte[] array)
        {
	        byte[] take;
	        int length, count;
	        var sb = new StringBuilder();

            switch (type)
            {
                case 0x07:
                    return array[0];
                case 0x08:
                    return BitConverter.ToChar(array, 0);
                case 0x09:
	                take = array.Take(4).Reverse().ToArray();
                    return BitConverter.ToInt32(take, 0);
                case 0x0A:
	                take = array.Take(4).Reverse().ToArray();
                    return BitConverter.ToSingle(take, 0);
                case 0x0B:
	                take = array.Take(8).Reverse().ToArray();
                    return BitConverter.ToDouble(take, 0);
				case 0x0C:
					sb = new StringBuilder();
	                take = array.Take(4).Reverse().ToArray();
					length = BitConverter.ToInt32(take, 0);
					for (var i = 0; i < length; ++i)
					{
						sb.Append((char)array[i + 4]);
					}
					return sb.ToString();
				case 0x0E:
					sb = new StringBuilder();
					take = array.Take(4).Reverse().ToArray();
					count = BitConverter.ToInt32(take, 0);
					var list = new List<string>();
					var k1 = 4;
					for (var i1 = 0; i1 < count; ++i1)
					{
						sb.Clear();
						take = array.Skip(k1).Take(4).Reverse().ToArray();
						k1 += 4;
						length = BitConverter.ToInt32(take, 0);
						for (var j = 0; j < length; ++j)
						{
							sb.Append((char)array[k1]);
							++k1;
						}
						list.Add(sb.ToString());
					}
					return list;
				case 0x0F:
					take = array.Take(4).Reverse().ToArray();
					count = BitConverter.ToInt32(take, 0);
					var ctlist = new List<ComposedTypeBase>();
					var k2 = 4;
					for (var i = 0; i < count; ++i)
					{
						var ctype = array[k2];
						++k2;
						switch (ctype)
						{
							case 0x00:
								var lonlat = new LonLatPosition();
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								lonlat.Longitude = BitConverter.ToDouble(take, 0);
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								lonlat.Latitude = BitConverter.ToDouble(take, 0);
								ctlist.Add(lonlat);
								break;
							case 0x01:
								var pos2d = new Position2D();
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								pos2d.X = BitConverter.ToDouble(take, 0);
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								pos2d.Y = BitConverter.ToDouble(take, 0);
								ctlist.Add(pos2d);
								break;
							case 0x02:
								var lonlatalt = new LonLatAltPosition();
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								lonlatalt.Longitude = BitConverter.ToDouble(take, 0);
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								lonlatalt.Latitude = BitConverter.ToDouble(take, 0);
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								lonlatalt.Altitude = BitConverter.ToDouble(take, 0);
								ctlist.Add(lonlatalt);
								break;
							case 0x03:
								var pos3d = new Position3D();
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								pos3d.X = BitConverter.ToDouble(take, 0);
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								pos3d.Y = BitConverter.ToDouble(take, 0);
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								pos3d.Z = BitConverter.ToDouble(take, 0);
								ctlist.Add(pos3d);
								break;
							case 0x04:
								var rmp = new RoadMapPosition();
								sb = new StringBuilder();
								take = array.Skip(k2).Take(4).Reverse().ToArray();
								k2 += 4;
								length = BitConverter.ToInt32(take, 0);
								for (var j = 0; j < length; ++j)
								{
									sb.Append((char)array[j + 4]);
									++k2;
								}
								rmp.RoadId = sb.ToString();
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								rmp.Pos = BitConverter.ToDouble(take, 0);
								rmp.LaneId = array[k2];
								ctlist.Add(rmp);
								break;
							case 0x05:
								var bb = new BoundaryBox();
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								bb.LowerLeftX = BitConverter.ToDouble(take, 0);
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								bb.LowerLeftY = BitConverter.ToDouble(take, 0);
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								bb.UpperRightX = BitConverter.ToDouble(take, 0);
								take = array.Skip(k2).Take(8).Reverse().ToArray();
								k2 += 8;
								bb.UpperRightY = BitConverter.ToDouble(take, 0);
								ctlist.Add(bb);
								break;
							case 0x06:
								var pol = new Polygon();
								var plen = array[k2];
								++k2;
								for (var j = 0; j < plen; j++)
								{
									var p = new Position2D();
									take = array.Skip(k2).Take(8).Reverse().ToArray();
									k2 += 8;
									p.X = BitConverter.ToDouble(take, 0);
									take = array.Skip(k2).Take(8).Reverse().ToArray();
									k2 += 8;
									p.Y = BitConverter.ToDouble(take, 0);
									pol.Points.Add(p);
								}
								ctlist.Add(pol);
								break;
							case 0x0D:
								break;
							case 0x11:
								var c = new Color();
								c.R = array[k2++];
								c.G = array[k2++];
								c.B = array[k2++];
								c.A = array[k2++];
								ctlist.Add(c);
								break;
						}
					}
					return ctlist;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static byte[] GetMessageBytes(TraCICommand command)
        {
            return GetMessagesBytes(new[] {command});
        }

        internal static byte[] GetMessagesBytes(IEnumerable<TraCICommand> commands)
        {
            var cmessages = new List<List<byte>>();
            foreach (var c in commands)
            {
                var cmessage = new List<byte>();
                if (c.Contents == null)
                {
                    cmessage.Add(2); // no contents: only length self and id => 2
                }
                else if ((c.Contents.Length + 2) <= 255)
                {
                    cmessage.Add((byte)(c.Contents.Length + 2));
                }
                else
                {
                    cmessage.Add(0);
                    cmessage.AddRange(BitConverter.GetBytes(c.Contents.Length + 6).Reverse());
                }
                cmessage.Add(c.Identifier);
                if (c.Contents != null)
                {
                    cmessage.AddRange(c.Contents);
                }
                cmessages.Add(cmessage);
            }
            var totlength = cmessages.Select(x => x.Count).Sum() + 4;
            var totmessage = new List<byte>();
            totmessage.AddRange(BitConverter.GetBytes(totlength).Reverse());
            cmessages.ForEach(x => totmessage.AddRange(x));
            //totmessage.AddRange(BitConverter.GetBytes('\n'));
            return totmessage.ToArray();
        }

        internal static TraCIResult[] HandleResponse(byte[] response)
        {
            try
            {
                var revLength = response.Take(4).Reverse().ToArray();
                var totlength = BitConverter.ToInt32(revLength, 0);
                var i = 4;
                var results = new List<TraCIResult>();
                while (i < totlength)
                {
                    var trresult = new TraCIResult();
                    var j = 0;
                    int len = response[i + j++];
                    trresult.Length = len - 2; // bytes lenght will be: msg - length - id
                    if (len == 0)
                    {
                        if (j + 3 < len)
                        {
                            revLength = new byte[4];
                            revLength[0] = response[i + j + 3];
                            revLength[1] = response[i + j + 2];
                            revLength[2] = response[i + j + 1];
                            revLength[3] = response[i + j + 0];
                            len = BitConverter.ToInt32(revLength, 0);
                            trresult.Length = len - 6; // bytes lenght will be: msg - length - int32len - id
                            j += 4;
                        }
                        else
                        {
                            break;
                        }
                    }
                    trresult.Identifier = response[i + j++];
                    var cmd = new List<byte>();
                    while (j < len)
                    {
                        cmd.Add(response[i + j++]);
                    }
                    trresult.Response = cmd.ToArray();
                    i += j;
                    results.Add(trresult);
                }
                return results.ToArray();
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

		#endregion // Static Methods
	}
}