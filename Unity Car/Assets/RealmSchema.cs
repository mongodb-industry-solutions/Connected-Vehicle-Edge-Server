using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;

public partial class vehicle_data : IRealmObject
{
    [MapTo("_id")]
    [PrimaryKey]
    public ObjectId Id { get; set; }

    [MapTo("Battery_Current")]
    public double? BatteryCurrent { get; set; }

    [MapTo("Battery_Status_OK")]
    public bool? BatteryStatusOK { get; set; }

    [MapTo("Battery_Temp")]
    public double? BatteryTemp { get; set; }

    [MapTo("Driver_id")]
    public string? DriverId { get; set; }

    [MapTo("LightsOn")]
    public bool LightsOn { get; set; }

    [MapTo("Vehicle_Name")]
    public string? VehicleName { get; set; }

    [MapTo("Hood_Open")]
    public bool HoodOpen { get; set; }

    [MapTo("Driver_Door_Open")]
    public bool DriverDoorOpen { get; set; }
}
