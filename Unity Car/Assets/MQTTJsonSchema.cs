using System;

[Serializable]
public class VehicleData
{
    public string Id { get; set; }  

    public double? BatteryCurrent { get; set; }

    public bool? BatteryStatusOK { get; set; }

    public double? BatteryTemp { get; set; }

    public string DriverId { get; set; }

    public bool LightsOn { get; set; }

    public string VehicleName { get; set; }

    public bool HoodOpen { get; set; }

    public bool DriverDoorOpen { get; set; }

    public string EngineStatus { get; set; }
}
