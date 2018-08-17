using System.Collections.Generic;
using CodingConnected.TraCI.NET.Helpers;
using CodingConnected.TraCI.NET.Types;
using System;

namespace CodingConnected.TraCI.NET.Commands
{
    public class VehicleTypeCommands : TraCICommandsBase
    {
        #region Public Methods

        public TraCIResponse<List<string>> GetIdList()
        {
            return
                TraCICommandHelper.ExecuteGetCommand<List<string>>(
                    Client,
                    "ignored",
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.ID_LIST);
        }

        public TraCIResponse<int> GetIdCount()
        {
            return
                TraCICommandHelper.ExecuteGetCommand<int>(
                    Client,
                    "ignored",
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.ID_COUNT);
        }

        public TraCIResponse<double> GetLength(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_LENGTH);
        }

        public TraCIResponse<double> GetMaxSpeed(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_MAXSPEED);
        }

        public TraCIResponse<double> GetAccel(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_ACCEL);
        }

        public TraCIResponse<double> GetDecel(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_DECEL);
        }

        public TraCIResponse<double> GetTau(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_TAU);
        }

        public TraCIResponse<double> GetImperfection(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_IMPERFECTION);
        }

        public TraCIResponse<double> GetSpeedFactor(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_SPEED_FACTOR);
        }

        public TraCIResponse<double> GetSpeedDeviation(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_SPEED_DEVIATION);
        }

        public TraCIResponse<string> GetVehicleClass(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_VEHICLECLASS);
        }

        public TraCIResponse<string> GetEmissionClass(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_EMISSIONCLASS);
        }

        public TraCIResponse<string> GetShapeClass(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_SHAPECLASS);
        }

        public TraCIResponse<double> GetMinGap(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_MINGAP);
        }

        public TraCIResponse<double> GetWidth(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_WIDTH);
        }

        public TraCIResponse<double> GetHeight(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_HEIGHT);
        }

        public TraCIResponse<Color> GetColor(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<Color>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_COLOR);
        }

        public TraCIResponse<double> GetMaxSpeedLat(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_MAXSPEED_LAT);
        }

        public TraCIResponse<double> GetMinGapLat(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_MINGAP_LAT);
        }

        public TraCIResponse<string> GetLateralAlignment(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<string>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
                    TraCIConstants.VAR_LATALIGNMENT);
        }

        public TraCIResponse<double> GetActionStepLength(string id)
        {
            return
                TraCICommandHelper.ExecuteGetCommand<double>(
                    Client,
                    id,
                    TraCIConstants.CMD_GET_VEHICLETYPE_VARIABLE,
#warning Check this
                    TraCIConstants.VAR_MIN_EXPECTED_VEHICLES);
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
        public TraCIResponse<object> SetMaxSpeed(string id, double speed)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MAXSPEED,
                    speed
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
        public TraCIResponse<object> SetSpeedDeviation(string id, double speedDeviation)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_SPEED_DEVIATION,
                    speedDeviation
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
        public TraCIResponse<object> SetDecel(string id, double decceleration)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_DECEL,
                    decceleration
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
        public TraCIResponse<object> SetMinGapLat(string id, double minGap)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, double>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.VAR_MINGAP_LAT,
                    minGap
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
        public TraCIResponse<object> Copy(string id, string newId)
        {
            return TraCICommandHelper.ExecuteSetCommand<object, string>(
                    Client,
                    id,
                    TraCIConstants.CMD_SET_VEHICLE_VARIABLE,
                    TraCIConstants.COPY,
                    newId
                    );
        }
        public TraCIResponse<object> SetActionStepLengt(string id)
        {
            throw new NotImplementedException();
        }
        #endregion // Public Methods

        #region Constructor

        public VehicleTypeCommands(TraCIClient client) : base(client)
        {
        }

        #endregion // Constructor
    }
}