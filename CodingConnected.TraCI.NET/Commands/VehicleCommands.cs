using System;
using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;

namespace CodingConnected.TraCI.NET.Commands
{
    public class VehicleCommands : TraCICommandsBase
    {
        #region Public Methods

        public TraCIResponse<List<string>> GetIdList()
        {
            return
                TraCICommandHelper.ExecuteGetCommand<List<string>>(
                    Client,
                    "ignored",
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.ID_LIST);
        }

        public TraCIResponse<int> GetIdCount()
        {
            return
                TraCICommandHelper.ExecuteGetCommand<int>(
                    Client,
                    "ignored",
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.ID_COUNT);
        }

        public TraCIResponse<double> GetSpeed(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SPEED);
        }

        public TraCIResponse<Position2D> GetPosition(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<Position2D>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_POSITION);
        }

        public TraCIResponse<Position3D> GetPosition3D(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<Position3D>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_POSITION3D);
        }

        public TraCIResponse<double> GetAngle(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ANGLE);
        }

        public TraCIResponse<string> GetRoadID(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ROAD_ID);
        }

        public TraCIResponse<string> GetLaneID(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_LANE_ID);
        }

        public TraCIResponse<int> GetLaneIndex(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<int>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_LANE_INDEX);
        }

        public TraCIResponse<string> GetTypeID(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_TYPE);
        }

        public TraCIResponse<string> GetRouteID(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ROUTE_ID);
        }

        public TraCIResponse<int> GetRouteIndex(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<int>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ROUTE_ID);
        }

        public TraCIResponse<List<string>> GetRoute(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<List<string>>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ROUTE);
        }

        public TraCIResponse<Color> GetColor(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<Color>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_COLOR);
        }

        public TraCIResponse<double> GetLanePosition(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_LANEPOSITION);
        }

        public TraCIResponse<double> GetDistance(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_DISTANCE);
        }

        public TraCIResponse<int> GetSignals(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<int>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SIGNALS);
        }

        public TraCIResponse<double> GetCO2Emission(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_CO2EMISSION);
        }

        public TraCIResponse<double> GetCOEmission(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_COEMISSION);
        }

        public TraCIResponse<double> GetHCEmission(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_HCEMISSION);
        }

        public TraCIResponse<double> GetPMxEmission(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_PMXEMISSION);
        }

        public TraCIResponse<double> GetNOxEmission(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_NOXEMISSION);
        }

        public TraCIResponse<double> GetFuelConsumption(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_FUELCONSUMPTION);
        }

        public TraCIResponse<double> GetNoiseEmission(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_NOISEEMISSION);
        }

        public TraCIResponse<double> GetElectricityConsumption(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ELECTRICITYCONSUMPTION);
        }

        public TraCIResponse<List<EdgeInformation>> GetBestLanes(string id)
        {
            var tmp = TraCICommandHelper.ExecuteGetCommand<CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_BEST_LANES);

            var edgeInformation = TraCIDataConverter.ConvertToListOfEdgeInformation(tmp.Content);

            return new TraCIResponse<List<EdgeInformation>>
            {
                Content = edgeInformation,
                ErrorMessage = tmp.ErrorMessage,
                Identifier = tmp.Identifier,
                ResponseIdentifier = tmp.ResponseIdentifier,
                Result = tmp.Result,
                Variable = tmp.Variable
            };
        }

        public TraCIResponse<byte> GetStopState(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<byte>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_STOPSTATE);
        }

        public TraCIResponse<double> GetLength(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_LENGTH);
        }

        public TraCIResponse<double> GetMaxSpeed(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MAXSPEED);
        }

        public TraCIResponse<double> GetAccel(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ACCEL);
        }

        public TraCIResponse<double> GetDecel(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_DECEL);
        }

        public TraCIResponse<double> GetTau(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_TAU);
        }

        public TraCIResponse<double> GetImperfection(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_IMPERFECTION);
        }

        public TraCIResponse<double> GetSpeedFactor(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SPEED_FACTOR);
        }

        public TraCIResponse<double> GetSpeedDeviation(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SPEED_DEVIATION);
        }

        public TraCIResponse<string> GetVehicleClass(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_VEHICLECLASS);
        }

        public TraCIResponse<string> GetEmissionClass(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_EMISSIONCLASS);
        }

        public TraCIResponse<string> GetShapeClass(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SHAPECLASS);
        }

        public TraCIResponse<double> GetMinGap(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MINGAP);
        }

        public TraCIResponse<double> GetWidth(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_WIDTH);
        }

        public TraCIResponse<double> GetHeight(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_HEIGHT);
        }

        public TraCIResponse<double> GetWaitingTime(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_WAITING_TIME);
        }

        public TraCIResponse<double> GetAccumulatedWaitingTime(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ACCUMULATED_WAITING_TIME);
        }

        public TraCIResponse<List<TrafficLightSystem>> GetNextTLS(string id)
        {
            var tmp = TraCICommandHelper.ExecuteGetCommand<CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_NEXT_TLS);

            var tls = TraCIDataConverter.ConvertToListOfTrafficLightSystem(tmp.Content);

            return new TraCIResponse<List<TrafficLightSystem>>
            {
                Content = tls,
                ErrorMessage = tmp.ErrorMessage,
                Identifier = tmp.Identifier,
                ResponseIdentifier = tmp.ResponseIdentifier,
                Result = tmp.Result,
                Variable = tmp.Variable
            };
        }

        public TraCIResponse<int> GetSpeedMode(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<int>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SPEEDSETMODE);
        }

        public TraCIResponse<double> GetSlope(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SLOPE);
        }

        public TraCIResponse<double> GetAllowedSpeed(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ALLOWED_SPEED);
        }

        public TraCIResponse<string> GetLine(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_LINE);
        }

        public TraCIResponse<int> GetPersonNumber(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<int>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_PERSON_NUMBER);
        }

        public TraCIResponse<List<string>> GetVia(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<List<string>>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_VIA);
        }

        public TraCIResponse<double> GetSpeedWithoutTraCI(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SPEED_WITHOUT_TRACI);
        }

        // TODO this returns bool: how does that work?
        public TraCIResponse<int> IsRouteValid(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<int>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ROUTE_VALID);
        }

        public TraCIResponse<double> GetLateralLanePosition(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_LANEPOSITION_LAT);
        }

        public TraCIResponse<double> GetMaxSpeedLat(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MAXSPEED_LAT);
        }

        public TraCIResponse<double> GetMinGapLat(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MINGAP_LAT);
        }

        public TraCIResponse<string> GetLateralAlignment(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_LATALIGNMENT);
        }

        public TraCIResponse<string> GetParameter(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_PARAMETER);
        }

        public TraCIResponse<double> GetActionStepLength(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
#warning This deviates: constants file is different from website (http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval)
                    0x7d);
        }

        public TraCIResponse<double> GetLastActionTime(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLE_VARIABLE,
#warning see above
                    0x7f);
        }

        // TODO: 'extended retrieval', see: http://sumo.dlr.de/wiki/TraCI/Vehicle_Value_Retrieval


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="edgeId"></param>
        /// <param name="endPosition"></param>
        /// <param name="laneIndex"></param>
        /// <param name="Duration">in ms</param>
        /// <param name="stopFlag"></param>
        /// <param name="startPosition"></param>
        /// <param name="until"></param>
        /// <returns></returns>
        public TraCIResponse<object> SetStop(string id, string edgeId, double endPosition, byte laneIndex, int Duration, StopFlag stopFlag = StopFlag.STOP_DEFAULT, double startPosition = 0d, int until = 0)
        {
            var tmp = new CompoundObject();
            //tmp.Value.Add(new TraCIInteger() { Value = itemNumber });
            tmp.Value.Add(new TraCIString() { Value = edgeId });
            tmp.Value.Add(new TraCIDouble() { Value = endPosition });
            tmp.Value.Add(new TraCIByte() { Value = laneIndex });
            tmp.Value.Add(new TraCIInteger() { Value = Duration });
            tmp.Value.Add(new TraCIByte() { Value = (byte)stopFlag });
            tmp.Value.Add(new TraCIDouble() { Value = startPosition });
            tmp.Value.Add(new TraCIInteger() { Value = until });


            return
                TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.CMD_STOP,
                    tmp
                    );
        }

        public TraCIResponse<object> ChangeLane(string id, byte laneIndex, int duration)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIByte() { Value = laneIndex });
            tmp.Value.Add(new TraCIInteger() { Value = duration });


            return
                TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.CMD_CHANGELANE,
                    tmp
                    );
        }

        public TraCIResponse<object> ChangeSublane(string id, double lateralDistance)
        {
            return
                TraCICommandHelper.ExecuteSetCommand<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.CMD_CHANGESUBLANE,
                    lateralDistance
                    );
        }

        public TraCIResponse<object> SlowDown(string id, double speed, int duration)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIDouble() { Value = speed });
            tmp.Value.Add(new TraCIInteger() { Value = duration });


            return
                TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.CMD_SLOWDOWN,
                    tmp
                    );
        }

        public TraCIResponse<object> Resume(string id)
        {
            var tmp = new CompoundObject();

            return
                TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.CMD_RESUME,
                    tmp
                    );
        }

        public TraCIResponse<object> ChangeTarget(string id, string desitinationEdgeId)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.CMD_CHANGETARGET,
                    desitinationEdgeId
                    );
        }

        public TraCIResponse<object> SetSpeed(string id, double speed)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SPEED,
                    speed
                    );
        }

        public TraCIResponse<object> SetColor(string id, Color color)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, Color>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_COLOR,
                     color
                     );
        }

        public TraCIResponse<object> SetRoutID(string id, string routeId)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ROUTE_ID,
                    routeId
                    );
        }

        public TraCIResponse<object> SetRoute(string id, List<string> edges)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, List<string>>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ROUTE,
                    edges
                    );
        }

        public TraCIResponse<object> SetEffort(string id, int numberOfElements, string edgeId, int beginTime = 0, int endTime = 0, double effortValue = 0)
        {
            CompoundObject co;
            switch (numberOfElements)
            {
                case 4:
                    co = new CompoundObject();
                    co.Value.Add(new TraCIInteger() { Value = beginTime });
                    co.Value.Add(new TraCIInteger() { Value = endTime });
                    co.Value.Add(new TraCIString() { Value = edgeId });
                    co.Value.Add(new TraCIDouble() { Value = effortValue });
                    break;
                case 2:

                    co = new CompoundObject();
                    co.Value.Add(new TraCIString() { Value = edgeId });
                    co.Value.Add(new TraCIDouble() { Value = effortValue });
                    break;
                case 1:
                    co = new CompoundObject();
                    co.Value.Add(new TraCIString() { Value = edgeId });
                    break;
                default:
                    throw new ArgumentOutOfRangeException("numberOfElements", "Only 1, 2 or 4, is allowed as value for numberOfElements");
            }
            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_EDGE_EFFORT,
                    co
                    );
        }


        public TraCIResponse<object> SetAdaptedTraveltime(string id, int numberOfElements, int beginTime, int endTime, string edgeId, double travelTimeValue)
        {
            CompoundObject co;
            switch (numberOfElements)
            {
                case 4:
                    co = new CompoundObject();
                    co.Value.Add(new TraCIInteger() { Value = beginTime });
                    co.Value.Add(new TraCIInteger() { Value = endTime });
                    co.Value.Add(new TraCIString() { Value = edgeId });
                    co.Value.Add(new TraCIDouble() { Value = travelTimeValue });
                    break;
                case 2:

                    co = new CompoundObject();
                    co.Value.Add(new TraCIString() { Value = edgeId });
                    co.Value.Add(new TraCIDouble() { Value = travelTimeValue });
                    break;
                case 1:
                    co = new CompoundObject();
                    co.Value.Add(new TraCIString() { Value = edgeId });
                    break;
                default:
                    throw new ArgumentOutOfRangeException("numberOfElements", "Only 1, 2 or 4, is allowed as value for numberOfElements");
            }
            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_EDGE_TRAVELTIME,
                    co
                    );
        }
        public TraCIResponse<object> SetSignals(string id, VehicleSignalling signal)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, int>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_ROUTE,
                    (int)signal
                    );
        }
        public TraCIResponse<object> SetRoutingMode(string id, RoutingMode routingMode)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, int>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     0x89,//missing constant!
                     (int)routingMode
                     );
        }
        public TraCIResponse<object> MoveTo(string id, string laneId, double position)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIString() { Value = laneId });
            tmp.Value.Add(new TraCIDouble() { Value = position });

            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_MOVE_TO,
                     tmp
                     );
        }
        public TraCIResponse<object> MoveToXY(string id, int itemNumber, string edgeId, int laneIndex, double xPosition, double yPosition, double angle, int keepRoute = -1)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIString() { Value = edgeId });
            tmp.Value.Add(new TraCIInteger() { Value = laneIndex });
            tmp.Value.Add(new TraCIDouble() { Value = xPosition });
            tmp.Value.Add(new TraCIDouble() { Value = angle });
            if (keepRoute == 0 || keepRoute == 1 || keepRoute == 2)
            {
                tmp.Value.Add(new TraCIByte() { Value = (byte)keepRoute });
            }

            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.MOVE_TO_XY,
                     tmp
                     );
        }
        public TraCIResponse<object> RerouteTraveltime(string id)
        {
            var tmp = new CompoundObject();
            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.CMD_REROUTE_TRAVELTIME,
                     tmp
                     );
        }
        public TraCIResponse<object> RerouteEffort(string id)
        {
            var tmp = new CompoundObject();
            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.CMD_REROUTE_EFFORT,
                     tmp
                     );
        }
        public TraCIResponse<object> SetSpeedMode(string id, SpeedMode mode)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, int>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_SPEEDSETMODE,
                     (int)mode
                     );
        }
        public TraCIResponse<object> SetSpeedFactor(string id, double speedFactor)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_SPEED_FACTOR,
                     speedFactor
                     );
        }
        public TraCIResponse<object> SetMaxSpeed(string id, double maxSpeed)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_MAXSPEED,
                     maxSpeed
                     );
        }
        public TraCIResponse<object> SetLaneChangeMode(string id, LaneChangeStrategicMode stragic, LaneChangeCooperativeMode cooperative, LaneChangeSpeedMode speed, LaneChangeRightMode right, LaneChangeRespectMode respect, LaneChangeSublaneMode sublane)
        {
            int tmp;

            tmp = (int)stragic * 1 + (int)cooperative * 4 + (int)speed * 16 + (int)right * 32 + (int)respect * 64 + (int)sublane * 128;
            return TraCICommandHelper.ExecuteSetCommand<object, int>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_LANECHANGE_MODE,
                     tmp
                     );
        }
        public TraCIResponse<object> Add(string id, string vehicleTypeId, string routeId, int departTime, double departPosition, double departSpeed, byte departLane)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIString() { Value = vehicleTypeId });
            tmp.Value.Add(new TraCIString() { Value = routeId });
            tmp.Value.Add(new TraCIInteger() { Value = departTime });
            tmp.Value.Add(new TraCIDouble() { Value = departPosition });
            tmp.Value.Add(new TraCIDouble() { Value = departSpeed });
            tmp.Value.Add(new TraCIByte() { Value = departLane });
            
            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.ADD,
                     tmp
                     );
        }
        public TraCIResponse<object> AddFull(string id, string routeId, string vehicleTypeId, string departTime, string departLane, string departPosition,string departSpeed, string arrivalPosition, string arrivalSpeed, string fromTaz, string toTaz, string line, int personCapacity, int personNumber)
        {
            var tmp = new CompoundObject();
            tmp.Value.Add(new TraCIString() { Value = routeId });
            tmp.Value.Add(new TraCIString() { Value = vehicleTypeId });
            tmp.Value.Add(new TraCIString() { Value = departTime });
            tmp.Value.Add(new TraCIString() { Value = departLane });
            tmp.Value.Add(new TraCIString() { Value = departPosition });
            tmp.Value.Add(new TraCIString() { Value = departSpeed });
            tmp.Value.Add(new TraCIString() { Value = arrivalPosition });
            tmp.Value.Add(new TraCIString() { Value = arrivalSpeed });
            tmp.Value.Add(new TraCIString() { Value = fromTaz });
            tmp.Value.Add(new TraCIString() { Value = toTaz });
            tmp.Value.Add(new TraCIString() { Value = line });
            tmp.Value.Add(new TraCIInteger() { Value = personCapacity });
            tmp.Value.Add(new TraCIInteger() { Value = personNumber });

            return TraCICommandHelper.ExecuteSetCommand<object, CompoundObject>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.ADD_FULL,
                     tmp
                     );
        }
        public TraCIResponse<object> Remove(string id, byte reason)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, byte>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.REMOVE,
                     reason
                     );
        }
        public TraCIResponse<object> SetLength(string id, double length)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_LENGTH,
                     length
                     );
        }
        public TraCIResponse<object> SetVehicleClass(string id, string vehicleClass)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_VEHICLECLASS,
                     vehicleClass
                     );
        }
        public TraCIResponse<object> SetEmissionClass(string id, string emissionClass)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_EMISSIONCLASS,
                     emissionClass
                     ); 
        }
        public TraCIResponse<object> SetWidth(string id, double width)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                      Client,
                      id,
                      TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                      TraCIConstants.VAR_WIDTH,
                      width
                      );
        }
        public TraCIResponse<object> SetHeight(string id, double height)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_HEIGHT,
                     height
                     );
        }
        public TraCIResponse<object> SetMinGap(string id, double minGap)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_MINGAP,
                     minGap
                     );
        }
        public TraCIResponse<object> SetShapeClass(string id, string shapeClass)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_SHAPECLASS,
                     shapeClass
                     );
        }
        public TraCIResponse<object> SetAccel(string id, double acceleration)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_ACCEL,
                     acceleration
                     );
        }
        public TraCIResponse<object> SetDecel(string id, double deceleration)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_DECEL,
                     deceleration
                     );
        }
        public TraCIResponse<object> SetImperfection(string id, double imperfection)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_IMPERFECTION,
                     imperfection
                     );
        }
        public TraCIResponse<object> SetTau(string id, double tau)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_TAU,
                     tau
                     );
        }
        public TraCIResponse<object> SetType(string id, string type)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_IMPERFECTION,
                     type
                     );
        }
        public TraCIResponse<object> SetVia(string id, List<string> via)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, List<string>>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_VIA,
                     via
                     );
        }

        public TraCIResponse<object> SetMaxSpeedLat(string id, double maxSpeed)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_MAXSPEED_LAT,
                     maxSpeed
                     );
        }
        public TraCIResponse<object> SetMinGapLat(string id, double gap)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_MINGAP_LAT,
                     gap
                     );
        }
        public TraCIResponse<object> SetLateralAlignment(string id, string alignment)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                     Client,
                     id,
                     TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                     TraCIConstants.VAR_LATALIGNMENT,
                     alignment
                     );
        }
        public TraCIResponse<object> SetParamater(string id)
        {
            throw new NotImplementedException();
        }
        public TraCIResponse<object> SetActionStepLength(string id)
        {
            throw new NotImplementedException();
        }


        #endregion // Public Methods

        #region Constructor

        public VehicleCommands(TraCIClient client) : base(client)
        {
        }

        #endregion // Constructor
    }

    public enum StopFlag : Byte
    {
        STOP_DEFAULT = 0x00,
        STOP_PARKING = 0x01,
        STOP_TRIGGERED = 0x02,
        STOP_CONTAINER_TRIGGERED = 0x04,
        STOP_BUS_STOP = 0x08,
        STOP_CONTAINER_STOP = 0x10,
        STOP_CHARGING_STATION = 0x20,
        STOP_PARKING_AREA = 0x40
    }

    /// <summary>
    /// see http://sumo.dlr.de/wiki/TraCI/Vehicle_Signalling
    /// </summary>
    public enum VehicleSignalling : int
    {
        VEH_SIGNAL_BLINKER_RIGHT = 0,
        VEH_SIGNAL_BLINKER_LEFT = 1,
        VEH_SIGNAL_BLINKER_EMERGENCY = 2,
        VEH_SIGNAL_BRAKELIGHT = 3,
        VEH_SIGNAL_FRONTLIGHT = 4,
        VEH_SIGNAL_FOGLIGHT = 5,
        VEH_SIGNAL_HIGHBEAM = 6,
        VEH_SIGNAL_BACKDRIVE = 7,
        VEH_SIGNAL_WIPER = 8,
        VEH_SIGNAL_DOOR_OPEN_LEFT = 9,
        VEH_SIGNAL_DOOR_OPEN_RIGHT = 10,
        VEH_SIGNAL_EMERGENCY_BLUE = 11,
        VEH_SIGNAL_EMERGENCY_RED = 12,
        VEH_SIGNAL_EMERGENCY_YELLOW = 13

    }

    public enum RoutingMode : int
    {
        Default = 0,
        Aggregated = 1
    }

    [Flags]
    public enum SpeedMode : int
    {
        RegardSafeSpeed = 1,
        RegardMaximumAcceleration = 2,
        RegardMaximumDeceleration = 4,
        RegardRightOfWayAtIntersections = 8,
        BrakeHardToAvoidPassingARedLight = 16
    }

    public enum LaneChangeStrategicMode
    {
        NoChanges = 0,
        ChangeIfNotInConflict = 1,
        ChangeEvenIfOverriding = 2
    }

    public enum LaneChangeCooperativeMode
    {
        NoChanges = 0,
        ChangeIfNotInConflict = 1,
        ChangeEvenIfOverriding = 2
    }

    public enum LaneChangeSpeedMode
    {
        NoChanges = 0,
        ChangeIfNotInConflict = 1,
        ChangeEvenIfOverriding = 2
    }

    public enum LaneChangeRightMode
    { 
        NoChanges = 0,
        ChangeIfNotInConflict = 1,
        ChangeEvenIfOverriding = 2
    }

    public enum LaneChangeRespectMode
    {
        NotRespectOther = 0,
        AvoidImmediateCollisions = 1,
        RespectOthersAdaptSpeed = 2,
        RespectOthersNoSpeedAdaption = 3
    }

    public enum LaneChangeSublaneMode
    {
        NoSublaneChanges = 0,
        DoSublaneChangesIfNotInConflict = 1,
        DoSublaneChangeEvenIfOverriding = 2
    }
}


    
