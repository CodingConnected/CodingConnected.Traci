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

		internal static TraCIResponse<T> ExtractDataFromResponse<T>(TraCIResult[] response, byte commandType, byte messageType = 0)
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
						var contentAsObject = GetValueFromTypeAndArray(type, r2.Response.Skip(6 + idl).ToArray());

                        return new TraCIResponse<T>
                        {
                            Identifier = r1.Identifier,
                            ResponseIdentifier = r2.Identifier,
                            Variable = r2.Response[0],
                            Result = ResultCode.Success,
                            Content = (T)contentAsObject
                        };
                    }
                    else
                    {
                        // for state changing methods without response content
                        return new TraCIResponse<T>
                        {
                            Identifier = r1.Identifier,
                            ResponseIdentifier = null,
                            Variable = null,
                            Result = ResultCode.Success,
                            Content = default
                        };
                    }
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

                    return new TraCIResponse<T>
                    {
                        Identifier = r1.Identifier,
                        ResponseIdentifier = null,
                        Variable = null,
                        Result = ResultCode.Failed,
                        Content = default,
                        ErrorMessage = "TraCI reports command failure: " + sb
                    };
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

                    return new TraCIResponse<T>
                    {
                        Identifier = r1.Identifier,
                        ResponseIdentifier = null,
                        Variable = null,
                        Result = ResultCode.NotImplemented,
                        Content = default,
                        ErrorMessage = "TraCI reports command not implemented: " + sb
                    };
				}
			}
			return null;
		}

        internal static ControlledLinks ConvertToControlledLinks(List<ComposedTypeBase> content)
        {
            var ret = new ControlledLinks();

            ret.NumberOfSignals = (content[0] as TraCIInteger).Value;

            for (int i = 2; i < content.Count; i+=2)
            {
                ret.Links.Add((content[i] as TraCIStringList).Value);
            }

            return ret;
        }

        internal static byte[] GetTraCIBytesFromInt32(int i)
        {
            return BitConverter.GetBytes(i).Reverse().ToArray();
        }

        internal static byte[] GetTraCIBytesFromDouble(double d)
        {
            return BitConverter.GetBytes(d).Reverse().ToArray();
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
            switch (type)
            {
                case TraCIConstants.POSITION_LON_LAT:
                    {
                        GetPositionLonLat(array, 0, out LonLatPosition lonLatPosition);
                        return lonLatPosition;
                    }
                case TraCIConstants.POSITION_2D:
                    {
                        Get2DPosition(array, 0, out Position2D position2D);
                        return position2D;
                    }
                case TraCIConstants.POSITION_LON_LAT_ALT:
                    {
                        GetPositionLonLatAlt(array, 0, out LonLatAltPosition lonLatAltPosition);
                        return lonLatAltPosition;
                    }
                case TraCIConstants.POSITION_3D:
                    {
                        GetPostion3D(array, 0, out Position3D position3D);
                        return position3D;
                    }
                case TraCIConstants.POSITION_ROADMAP:
                    {
                        GetPositionRoadmap(array, 0, out RoadMapPosition roadMapPosition);
                        return roadMapPosition;
                    }
                case TraCIConstants.TYPE_BOUNDINGBOX:
                    {
                        GetBoundaryBox(array, 0, out BoundaryBox boundaryBox);
                        return boundaryBox;
                    }
                case TraCIConstants.TYPE_POLYGON:
                    {
                        GetPolygon(array, 0, out Polygon polygon);
                        return polygon;
                    }
                case TraCIConstants.TYPE_UBYTE:
                    {
                        GetUByte(array, 0, out TraCIUByte UByte);
                        return UByte.Value;
                    }
                case TraCIConstants.TYPE_BYTE:
                    {
                        GetByte(array, 0, out TraCIByte sByte);
                        return sByte.Value;
                    }
                case TraCIConstants.TYPE_INTEGER:
                    {
                        GetInteger(array, 0, out TraCIInteger integer);
                        return integer.Value;
                    }
                case TraCIConstants.TYPE_FLOAT:
                    {
                        GetFloat(array, 0, out TraCIFloat Float);
                        return Float.Value;
                    }
                case TraCIConstants.TYPE_DOUBLE:
                    {
                        GetDouble(array, 0, out TraCIDouble Double);
                        return Double.Value;
                    }
                case TraCIConstants.TYPE_STRING:
                    {
                        GetString(array, 0, out TraCIString String);
                        return String.Value;
                    }
                case TraCIConstants.TYPE_STRINGLIST:
                    {
                        GetStringList(array, 0, out TraCIStringList StringList);
                        return StringList.Value;
                    }
                case TraCIConstants.TYPE_COLOR:
                    {
                        GetColor(array, 0, out Color color);
                        return color;
                    }
                case TraCIConstants.TYPE_TLPHASELIST:
                    {
                        throw new NotImplementedException("There is no handler for Traffic Light Phase List (ubyte identifier: 0x0D). Unclear definition of this datatyp. See http://sumo.dlr.de/wiki/TraCI/Protocol#Data_types");
                    }
                case TraCIConstants.TYPE_COMPOUND:
                    {
                        var take = array.Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
                        var count = BitConverter.ToInt32(take, 0);
                        var ctlist = new List<ComposedTypeBase>();
                        int offset = TraCIConstants.INTEGER_SIZE;
                        for (var i = 0; i <= count; ++i)
                        {
                            var ctype = array[offset];
                            ++offset;
                            switch (ctype)
                            {
                                case TraCIConstants.POSITION_LON_LAT:
                                    {
                                        offset = GetPositionLonLat(array, offset, out LonLatPosition lonLatPosition);
                                        ctlist.Add(lonLatPosition);
                                        break;
                                    }
                                case TraCIConstants.POSITION_2D:
                                    {
                                        offset = Get2DPosition(array, offset, out Position2D position2D);
                                        ctlist.Add(position2D);
                                        break;
                                    }
                                case TraCIConstants.POSITION_LON_LAT_ALT:
                                    {
                                        offset = GetPositionLonLatAlt(array, offset, out LonLatAltPosition lonLatAltPosition);
                                        ctlist.Add(lonLatAltPosition);
                                        break;
                                    }
                                case TraCIConstants.POSITION_3D:
                                    {
                                        offset = GetPostion3D(array, offset,out Position3D position3D);
                                        ctlist.Add(position3D);
                                        break;
                                    }
                                case TraCIConstants.POSITION_ROADMAP:
                                    {
                                        offset = GetPositionRoadmap(array, offset, out RoadMapPosition roadMapPosition);
                                        ctlist.Add(roadMapPosition);
                                        break;
                                    }
                                case TraCIConstants.TYPE_BOUNDINGBOX:
                                    {
                                        offset = GetBoundaryBox(array, offset, out BoundaryBox boundaryBox);
                                        ctlist.Add(boundaryBox);
                                        break;
                                    }
                                case TraCIConstants.TYPE_POLYGON:
                                    {
                                        offset = GetPolygon(array, offset, out Polygon polygon);
                                        ctlist.Add(polygon);
                                        break;
                                    }
                                case TraCIConstants.TYPE_UBYTE:
                                    {
                                        offset = GetUByte(array, offset, out TraCIUByte UByte);
                                        ctlist.Add(UByte);
                                        break;
                                    }
                                case TraCIConstants.TYPE_BYTE:
                                    {
                                        offset = GetByte(array, offset, out TraCIByte Byte);
                                        ctlist.Add(Byte);
                                        break;
                                    }
                                case TraCIConstants.TYPE_INTEGER:
                                    {
                                        offset = GetInteger(array, offset, out TraCIInteger integer);
                                        ctlist.Add(integer);
                                        break;
                                    }
                                case TraCIConstants.TYPE_FLOAT:
                                    {
                                        offset = GetFloat(array, offset, out TraCIFloat Float);
                                        ctlist.Add(Float);
                                        break;
                                    }
                                case TraCIConstants.TYPE_DOUBLE:
                                    {
                                        offset = GetDouble(array, offset, out TraCIDouble Double);
                                        ctlist.Add(Double);
                                        break;
                                    }
                                case TraCIConstants.TYPE_STRING:
                                    {
                                        offset = GetString(array, offset, out TraCIString String);
                                        ctlist.Add(String);
                                        break;
                                    }
                                case TraCIConstants.TYPE_TLPHASELIST:
                                    {
                                        throw new NotImplementedException("There is no handler for Traffic Light Phase List (ubyte identifier: 0x0D). Unclear definition of this datatyp. See http://sumo.dlr.de/wiki/TraCI/Protocol#Data_types");
                                    }
                                case TraCIConstants.TYPE_COLOR:
                                    {
                                        offset = GetColor(array, offset, out Color color);
                                        ctlist.Add(color);
                                        break;
                                    }
                                case TraCIConstants.TYPE_STRINGLIST:
                                    {
                                        offset = GetStringList(array, offset, out TraCIStringList StringList);
                                        ctlist.Add(StringList);
                                        break;
                                    }
                            }
                        }
                        return ctlist;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
        }

        private static int GetColor(byte[] array, int offset, out Color color)
        {
            color = new Color();
            color.R = array[offset++];
            color.G = array[offset++];
            color.B = array[offset++];
            color.A = array[offset++];

            return offset;
        }

        private static int GetBoundaryBox(byte[] array, int offset, out BoundaryBox boundaryBox)
        {
            var bb = new BoundaryBox();
            var take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            bb.LowerLeftX = BitConverter.ToDouble(take, 0);
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            bb.LowerLeftY = BitConverter.ToDouble(take, 0);
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            bb.UpperRightX = BitConverter.ToDouble(take, 0);
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            bb.UpperRightY = BitConverter.ToDouble(take, 0);
            boundaryBox = bb;
            return offset;
        }

        private static int GetPositionRoadmap(byte[] array, int offset, out RoadMapPosition roadMapPosition)
        {
            var rmp = new RoadMapPosition();
            var sb = new StringBuilder();
            var take = array.Skip(offset).Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
            offset += TraCIConstants.INTEGER_SIZE;
            var length = BitConverter.ToInt32(take, 0);
            for (var j = 0; j < length; ++j)
            {
                sb.Append((char)array[j + TraCIConstants.INTEGER_SIZE]);
                ++offset;
            }
            rmp.RoadId = sb.ToString();
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            rmp.Pos = BitConverter.ToDouble(take, 0);
            rmp.LaneId = array[offset];
            roadMapPosition = rmp;
            return offset;
        }

        private static int GetPostion3D(byte[] array, int offset, out Position3D position3D)
        {
            var pos3d = new Position3D();
            var take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            pos3d.X = BitConverter.ToDouble(take, 0);
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            pos3d.Y = BitConverter.ToDouble(take, 0);
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            pos3d.Z = BitConverter.ToDouble(take, 0);
            position3D = pos3d;
            return offset;
        }

        private static int GetPositionLonLatAlt(byte[] array, int offset, out LonLatAltPosition lonLatAltPosition)
        {
            var lonlatalt = new LonLatAltPosition();
            var take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            lonlatalt.Longitude = BitConverter.ToDouble(take, 0);
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            lonlatalt.Latitude = BitConverter.ToDouble(take, 0);
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            lonlatalt.Altitude = BitConverter.ToDouble(take, 0);
            lonLatAltPosition = lonlatalt;
            return offset;
        }

        private static int Get2DPosition(byte[] array, int offset, out Position2D position2D)
        {
            var pos2d = new Position2D();
            var take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            pos2d.X = BitConverter.ToDouble(take, 0);
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            pos2d.Y = BitConverter.ToDouble(take, 0);
            position2D = pos2d;

            return offset;
        }

        private static int GetPositionLonLat(byte[] array, int offset, out LonLatPosition lonLatPosition)
        {
            byte[] take;
            var lonlat = new LonLatPosition();
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            lonlat.Longitude = BitConverter.ToDouble(take, 0);
            take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            offset += TraCIConstants.DOUBLE_SIZE;
            lonlat.Latitude = BitConverter.ToDouble(take, 0);
            lonLatPosition = lonlat;
            return offset;
        }

        private static int GetStringList(byte[] array, int offset, out TraCIStringList StringList)
        {
            StringList = new TraCIStringList();

            var sb = new StringBuilder();
            var take = array.Skip(offset).Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
            var count = BitConverter.ToInt32(take, 0);
            var list = new List<string>();
            offset += TraCIConstants.INTEGER_SIZE;
            for (var i1 = 0; i1 < count; ++i1)
            {
                sb.Clear();
                take = array.Skip(offset).Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
                offset += TraCIConstants.INTEGER_SIZE;
                var length = BitConverter.ToInt32(take, 0);
                for (var j = 0; j < length; ++j)
                {
                    sb.Append((char)array[offset]);
                    ++offset;
                }
                list.Add(sb.ToString());
            }
            StringList.Value = list;
            return offset;
        }

        private static int GetString(byte[] array, int offset, out TraCIString String)
        {
            String = new TraCIString();
            var sb = new StringBuilder();
            var take = array.Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
            var length = BitConverter.ToInt32(take, 0);
            offset += TraCIConstants.INTEGER_SIZE;
            for (var i = 0; i < length; ++i)
            {
                sb.Append((char)array[offset]);
                offset++;
            }
            String.Value = sb.ToString();

            return offset; 
        }

        private static int GetDouble(byte[] array, int offset, out TraCIDouble Double)
        {
            Double = new TraCIDouble();
            var take = array.Skip(offset).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
            Double.Value =  BitConverter.ToDouble(take, 0);
            return offset + TraCIConstants.DOUBLE_SIZE;
        }

        private static int GetFloat(byte[] array, int offset, out TraCIFloat Float)
        {
            Float = new TraCIFloat();
            var take = array.Skip(offset).Take(TraCIConstants.FLOAT_SIZE).Reverse().ToArray();
            Float.Value =  BitConverter.ToSingle(take, 0);
            return offset + TraCIConstants.FLOAT_SIZE;
        }

        private static int GetInteger(byte[] array, int offset, out TraCIInteger integer)
        {
            integer = new TraCIInteger();
            var take = array.Skip(offset).Take(TraCIConstants.INTEGER_SIZE).Reverse().ToArray();
            integer.Value = BitConverter.ToInt32(take, 0);
            return offset + TraCIConstants.INTEGER_SIZE;
        }

        private static int GetByte(byte[] array, int offset, out TraCIByte Byte)
        {
            Byte = new TraCIByte
            {
                Value = Convert.ToSByte(array[offset])
            };
            return offset + TraCIConstants.BYTE_SIZE;
        }

        private static int GetUByte(byte[] array, int offset, out TraCIUByte Byte)
        {
            Byte = new TraCIUByte
            {
                Value = array[offset]
            };
            return offset + TraCIConstants.UBYTE_SIZE;
        }

        private static int GetPolygon(byte[] array, int offset, out Polygon pol)
        {
            byte[] take;
            var length = array[offset];
            int skip = offset+1; // first byte is length of data

            pol = new Polygon();

            for (var j = 1; j <= length; j++)
            {
                var p = new Position2D();
                take = array.Skip(skip).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
                skip += TraCIConstants.DOUBLE_SIZE;
                p.X = BitConverter.ToDouble(take, 0);
                take = array.Skip(skip).Take(TraCIConstants.DOUBLE_SIZE).Reverse().ToArray();
                skip += TraCIConstants.DOUBLE_SIZE;
                p.Y = BitConverter.ToDouble(take, 0);
                pol.Points.Add(p);
            }
            return skip;
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
                        if (j + i + 3 < totlength)
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