using System;
using System.Collections.Generic;
using Realms;
using MongoDB.Bson;

public partial class vehicle : IRealmObject
{
    [MapTo("_id")]
    [PrimaryKey]
    public ObjectId Id { get; set; }

    public vehicle_ADAS? ADAS { get; set; }

    public vehicle_Acceleration? Acceleration { get; set; }

    public double? AmbientAirTemperature { get; set; }

    public vehicle_AngularVelocity? AngularVelocity { get; set; }

    public double? AverageSpeed { get; set; }

    public vehicle_Body? Body { get; set; }

    public vehicle_Cabin? Cabin { get; set; }

    public vehicle_Chassis? Chassis { get; set; }

    public int? CurbWeight { get; set; }

    public vehicle_CurrentLocation? CurrentLocation { get; set; }

    public int? CurrentOverallWeight { get; set; }

    public int? DriveTime { get; set; }

    public vehicle_Driver? Driver { get; set; }

    public int? GrossWeight { get; set; }

    public int? Height { get; set; }

    public int? IdleTime { get; set; }

    public int? IgnitionOffTime { get; set; }

    public bool? IgnitionOn { get; set; }

    public int? IgnitionOnTime { get; set; }

    public bool? IsMoving { get; set; }

    public int? Length { get; set; }

    public int? MaxTowBallWeight { get; set; }

    public int? MaxTowWeight { get; set; }

    public string? Media { get; set; }

    public vehicle_OBD? OBD { get; set; }

    public vehicle_Powertrain? Powertrain { get; set; }

    public string? Private { get; set; }

    public int? RoofLoad { get; set; }

    public double? Speed { get; set; }

    public vehicle_Trailer? Trailer { get; set; }

    public double? TravelledDistance { get; set; }

    public double? TripMeterReading { get; set; }

    public vehicle_VehicleIdentification? VehicleIdentification { get; set; }

    public vehicle_VersionVSS? VersionVSS { get; set; }

    public int? Width { get; set; }

    [MapTo("accelerationTime")]
    public int? AccelerationTime { get; set; }

    [MapTo("cargoVolume")]
    public double? CargoVolume { get; set; }

    [MapTo("emissionsCO2")]
    public int? EmissionsCO2 { get; set; }
}

public partial class vehicle_ADAS : IEmbeddedObject
{
    public vehicle_ADAS_ABS? ABS { get; set; }

    public vehicle_ADAS_CruiseControl? CruiseControl { get; set; }

    public vehicle_ADAS_ESC? ESC { get; set; }

    public vehicle_ADAS_LaneDepartureDetection? LaneDepartureDetection { get; set; }

    public vehicle_ADAS_ObstacleDetection? ObstacleDetection { get; set; }

    public vehicle_ADAS_TCS? TCS { get; set; }
}

public partial class vehicle_ADAS_ABS : IEmbeddedObject
{
    public bool? Error { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsEngaged { get; set; }
}

public partial class vehicle_ADAS_CruiseControl : IEmbeddedObject
{
    public bool? Error { get; set; }

    public bool? IsActive { get; set; }

    public double? SpeedSet { get; set; }
}

public partial class vehicle_ADAS_ESC : IEmbeddedObject
{
    public bool? Error { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsEngaged { get; set; }
}

public partial class vehicle_ADAS_LaneDepartureDetection : IEmbeddedObject
{
    public bool? Error { get; set; }

    public bool? IsActive { get; set; }

    public bool? Warning { get; set; }
}

public partial class vehicle_ADAS_ObstacleDetection : IEmbeddedObject
{
    public bool? Error { get; set; }

    public bool? IsActive { get; set; }
}

public partial class vehicle_ADAS_TCS : IEmbeddedObject
{
    public bool? Error { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsEngaged { get; set; }
}

public partial class vehicle_Acceleration : IEmbeddedObject
{
    public double? Lateral { get; set; }

    public double? Longitudinal { get; set; }

    public double? Vertical { get; set; }
}

public partial class vehicle_AngularVelocity : IEmbeddedObject
{
    public int? Pitch { get; set; }

    public int? Roll { get; set; }

    public double? Yaw { get; set; }
}

public partial class vehicle_Body : IEmbeddedObject
{
    public string? BodyType { get; set; }

    public vehicle_Body_ChargingPort? ChargingPort { get; set; }

    public vehicle_Body_Hood? Hood { get; set; }

    public vehicle_Body_Horn? Horn { get; set; }

    public vehicle_Body_Lights? Lights { get; set; }

    public vehicle_Body_Mirrors? Mirrors { get; set; }

    public vehicle_Body_Raindetection? Raindetection { get; set; }

    public string? RefuelPosition { get; set; }

    public vehicle_Body_Trunk? Trunk { get; set; }

    public vehicle_Body_Windshield? Windshield { get; set; }
}

public partial class vehicle_Body_ChargingPort : IEmbeddedObject
{
    public string? Type { get; set; }
}

public partial class vehicle_Body_Hood : IEmbeddedObject
{
    public bool? IsOpen { get; set; }
}

public partial class vehicle_Body_Horn : IEmbeddedObject
{
    public bool? IsActive { get; set; }
}

public partial class vehicle_Body_Lights : IEmbeddedObject
{
    public bool? IsBackupOn { get; set; }

    public bool? IsBrakeOn { get; set; }

    public bool? IsFrontFogOn { get; set; }

    public bool? IsHazardOn { get; set; }

    public bool? IsHighBeamOn { get; set; }

    public bool? IsLeftIndicatorOn { get; set; }

    public bool? IsLowBeamOn { get; set; }

    public bool? IsParkingOn { get; set; }

    public bool? IsRearFogOn { get; set; }

    public bool? IsRightIndicatorOn { get; set; }

    public bool? IsRunningOn { get; set; }
}

public partial class vehicle_Body_Mirrors : IEmbeddedObject
{
    public vehicle_Body_Mirrors_Left? Left { get; set; }

    public vehicle_Body_Mirrors_Right? Right { get; set; }
}

public partial class vehicle_Body_Mirrors_Left : IEmbeddedObject
{
    public vehicle_Body_Mirrors_Left_Heating? Heating { get; set; }

    public int? Pan { get; set; }

    public int? Tilt { get; set; }
}

public partial class vehicle_Body_Mirrors_Left_Heating : IEmbeddedObject
{
    public bool? Status { get; set; }
}

public partial class vehicle_Body_Mirrors_Right : IEmbeddedObject
{
    public vehicle_Body_Mirrors_Right_Heating? Heating { get; set; }

    public int? Pan { get; set; }

    public int? Tilt { get; set; }
}

public partial class vehicle_Body_Mirrors_Right_Heating : IEmbeddedObject
{
    public bool? Status { get; set; }
}

public partial class vehicle_Body_Raindetection : IEmbeddedObject
{
    [MapTo("intensity")]
    public int? Intensity { get; set; }
}

public partial class vehicle_Body_Trunk : IEmbeddedObject
{
    public bool? IsLocked { get; set; }

    public bool? IsOpen { get; set; }
}

public partial class vehicle_Body_Windshield : IEmbeddedObject
{
    public vehicle_Body_Windshield_Front? Front { get; set; }

    public vehicle_Body_Windshield_Rear? Rear { get; set; }
}

public partial class vehicle_Body_Windshield_Front : IEmbeddedObject
{
    public vehicle_Body_Windshield_Front_Heating? Heating { get; set; }

    public vehicle_Body_Windshield_Front_WasherFluid? WasherFluid { get; set; }

    public vehicle_Body_Windshield_Front_Wiping? Wiping { get; set; }
}

public partial class vehicle_Body_Windshield_Front_Heating : IEmbeddedObject
{
    public bool? Status { get; set; }
}

public partial class vehicle_Body_Windshield_Front_WasherFluid : IEmbeddedObject
{
    public int? Level { get; set; }

    public bool? LevelLow { get; set; }
}

public partial class vehicle_Body_Windshield_Front_Wiping : IEmbeddedObject
{
    public string? Status { get; set; }
}

public partial class vehicle_Body_Windshield_Rear : IEmbeddedObject
{
    public vehicle_Body_Windshield_Rear_Heating? Heating { get; set; }

    public vehicle_Body_Windshield_Rear_WasherFluid? WasherFluid { get; set; }

    public vehicle_Body_Windshield_Rear_Wiping? Wiping { get; set; }
}

public partial class vehicle_Body_Windshield_Rear_Heating : IEmbeddedObject
{
    public bool? Status { get; set; }
}

public partial class vehicle_Body_Windshield_Rear_WasherFluid : IEmbeddedObject
{
    public int? Level { get; set; }

    public bool? LevelLow { get; set; }
}

public partial class vehicle_Body_Windshield_Rear_Wiping : IEmbeddedObject
{
    public string? Status { get; set; }
}

public partial class vehicle_Cabin : IEmbeddedObject
{
    public vehicle_Cabin_Convertible? Convertible { get; set; }

    public vehicle_Cabin_Door? Door { get; set; }

    public int? DriverPosition { get; set; }

    public vehicle_Cabin_HVAC? HVAC { get; set; }

    public vehicle_Cabin_Infotainment? Infotainment { get; set; }

    public vehicle_Cabin_Lights? Lights { get; set; }

    public vehicle_Cabin_RearShade? RearShade { get; set; }

    public vehicle_Cabin_RearviewMirror? RearviewMirror { get; set; }

    public vehicle_Cabin_Seat? Seat { get; set; }

    public int? SeatPosCount { get; set; }

    public int? SeatRowCount { get; set; }

    public vehicle_Cabin_Sunroof? Sunroof { get; set; }
}

public partial class vehicle_Cabin_Convertible : IEmbeddedObject
{
    public string? Status { get; set; }
}

public partial class vehicle_Cabin_Door : IEmbeddedObject
{
    public vehicle_Cabin_Door_Row1? Row1 { get; set; }

    public vehicle_Cabin_Door_Row2? Row2 { get; set; }

    public vehicle_Cabin_Door_Row3? Row3 { get; set; }

    public vehicle_Cabin_Door_Row4? Row4 { get; set; }
}

public partial class vehicle_Cabin_Door_Row1 : IEmbeddedObject
{
    public vehicle_Cabin_Door_Row1_Left? Left { get; set; }

    public int? LeftCount { get; set; }

    public vehicle_Cabin_Door_Row1_Right? Right { get; set; }

    public int? RightCount { get; set; }
}

public partial class vehicle_Cabin_Door_Row1_Left : IEmbeddedObject
{
    public bool? IsChildLockActive { get; set; }

    public bool? IsLocked { get; set; }

    public bool? IsOpen { get; set; }

    public vehicle_Cabin_Door_Row1_Left_Shade? Shade { get; set; }

    public vehicle_Cabin_Door_Row1_Left_Window? Window { get; set; }
}

public partial class vehicle_Cabin_Door_Row1_Left_Shade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_Door_Row1_Left_Window : IEmbeddedObject
{
    public bool? ChildLock { get; set; }

    public int? Position { get; set; }

    public string? Switch { get; set; }

    [MapTo("isOpen")]
    public bool? IsOpen { get; set; }
}

public partial class vehicle_Cabin_Door_Row1_Right : IEmbeddedObject
{
    public bool? IsChildLockActive { get; set; }

    public bool? IsLocked { get; set; }

    public bool? IsOpen { get; set; }

    public vehicle_Cabin_Door_Row1_Right_Shade? Shade { get; set; }

    public vehicle_Cabin_Door_Row1_Right_Window? Window { get; set; }
}

public partial class vehicle_Cabin_Door_Row1_Right_Shade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_Door_Row1_Right_Window : IEmbeddedObject
{
    public bool? ChildLock { get; set; }

    public int? Position { get; set; }

    public string? Switch { get; set; }

    [MapTo("isOpen")]
    public bool? IsOpen { get; set; }
}

public partial class vehicle_Cabin_Door_Row2 : IEmbeddedObject
{
    public vehicle_Cabin_Door_Row2_Left? Left { get; set; }

    public int? LeftCount { get; set; }

    public vehicle_Cabin_Door_Row2_Right? Right { get; set; }

    public int? RightCount { get; set; }
}

public partial class vehicle_Cabin_Door_Row2_Left : IEmbeddedObject
{
    public bool? IsChildLockActive { get; set; }

    public bool? IsLocked { get; set; }

    public bool? IsOpen { get; set; }

    public vehicle_Cabin_Door_Row2_Left_Shade? Shade { get; set; }

    public vehicle_Cabin_Door_Row2_Left_Window? Window { get; set; }
}

public partial class vehicle_Cabin_Door_Row2_Left_Shade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_Door_Row2_Left_Window : IEmbeddedObject
{
    public bool? ChildLock { get; set; }

    public int? Position { get; set; }

    public string? Switch { get; set; }

    [MapTo("isOpen")]
    public bool? IsOpen { get; set; }
}

public partial class vehicle_Cabin_Door_Row2_Right : IEmbeddedObject
{
    public bool? IsChildLockActive { get; set; }

    public bool? IsLocked { get; set; }

    public bool? IsOpen { get; set; }

    public vehicle_Cabin_Door_Row2_Right_Shade? Shade { get; set; }

    public vehicle_Cabin_Door_Row2_Right_Window? Window { get; set; }
}

public partial class vehicle_Cabin_Door_Row2_Right_Shade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_Door_Row2_Right_Window : IEmbeddedObject
{
    public bool? ChildLock { get; set; }

    public int? Position { get; set; }

    public string? Switch { get; set; }

    [MapTo("isOpen")]
    public bool? IsOpen { get; set; }
}

public partial class vehicle_Cabin_Door_Row3 : IEmbeddedObject
{
    public vehicle_Cabin_Door_Row3_Left? Left { get; set; }

    public int? LeftCount { get; set; }

    public vehicle_Cabin_Door_Row3_Right? Right { get; set; }

    public int? RightCount { get; set; }
}

public partial class vehicle_Cabin_Door_Row3_Left : IEmbeddedObject
{
    public bool? IsChildLockActive { get; set; }

    public bool? IsLocked { get; set; }

    public bool? IsOpen { get; set; }

    public vehicle_Cabin_Door_Row3_Left_Shade? Shade { get; set; }

    public vehicle_Cabin_Door_Row3_Left_Window? Window { get; set; }
}

public partial class vehicle_Cabin_Door_Row3_Left_Shade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_Door_Row3_Left_Window : IEmbeddedObject
{
    public bool? ChildLock { get; set; }

    public int? Position { get; set; }

    public string? Switch { get; set; }

    [MapTo("isOpen")]
    public bool? IsOpen { get; set; }
}

public partial class vehicle_Cabin_Door_Row3_Right : IEmbeddedObject
{
    public bool? IsChildLockActive { get; set; }

    public bool? IsLocked { get; set; }

    public bool? IsOpen { get; set; }

    public vehicle_Cabin_Door_Row3_Right_Shade? Shade { get; set; }

    public vehicle_Cabin_Door_Row3_Right_Window? Window { get; set; }
}

public partial class vehicle_Cabin_Door_Row3_Right_Shade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_Door_Row3_Right_Window : IEmbeddedObject
{
    public bool? ChildLock { get; set; }

    public int? Position { get; set; }

    public string? Switch { get; set; }

    [MapTo("isOpen")]
    public bool? IsOpen { get; set; }
}

public partial class vehicle_Cabin_Door_Row4 : IEmbeddedObject
{
    public vehicle_Cabin_Door_Row4_Left? Left { get; set; }

    public int? LeftCount { get; set; }

    public vehicle_Cabin_Door_Row4_Right? Right { get; set; }

    public int? RightCount { get; set; }
}

public partial class vehicle_Cabin_Door_Row4_Left : IEmbeddedObject
{
    public bool? IsChildLockActive { get; set; }

    public bool? IsLocked { get; set; }

    public bool? IsOpen { get; set; }

    public vehicle_Cabin_Door_Row4_Left_Shade? Shade { get; set; }

    public vehicle_Cabin_Door_Row4_Left_Window? Window { get; set; }
}

public partial class vehicle_Cabin_Door_Row4_Left_Shade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_Door_Row4_Left_Window : IEmbeddedObject
{
    public bool? ChildLock { get; set; }

    public int? Position { get; set; }

    public string? Switch { get; set; }

    [MapTo("isOpen")]
    public bool? IsOpen { get; set; }
}

public partial class vehicle_Cabin_Door_Row4_Right : IEmbeddedObject
{
    public bool? IsChildLockActive { get; set; }

    public bool? IsLocked { get; set; }

    public bool? IsOpen { get; set; }

    public vehicle_Cabin_Door_Row4_Right_Shade? Shade { get; set; }

    public vehicle_Cabin_Door_Row4_Right_Window? Window { get; set; }
}

public partial class vehicle_Cabin_Door_Row4_Right_Shade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_Door_Row4_Right_Window : IEmbeddedObject
{
    public bool? ChildLock { get; set; }

    public int? Position { get; set; }

    public string? Switch { get; set; }

    [MapTo("isOpen")]
    public bool? IsOpen { get; set; }
}

public partial class vehicle_Cabin_HVAC : IEmbeddedObject
{
    public double? AmbientAirTemperature { get; set; }

    public bool? IsAirConditioningActive { get; set; }

    public bool? IsFrontDefrosterActive { get; set; }

    public bool? IsRearDefrosterActive { get; set; }

    public bool? IsRecirculationActive { get; set; }

    public vehicle_Cabin_HVAC_Station? Station { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station : IEmbeddedObject
{
    public vehicle_Cabin_HVAC_Station_Row1? Row1 { get; set; }

    public vehicle_Cabin_HVAC_Station_Row2? Row2 { get; set; }

    public vehicle_Cabin_HVAC_Station_Row3? Row3 { get; set; }

    public vehicle_Cabin_HVAC_Station_Row4? Row4 { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row1 : IEmbeddedObject
{
    public vehicle_Cabin_HVAC_Station_Row1_Left? Left { get; set; }

    public vehicle_Cabin_HVAC_Station_Row1_Right? Right { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row1_Left : IEmbeddedObject
{
    public string? AirDistribution { get; set; }

    public int? FanSpeed { get; set; }

    public int? Temperature { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row1_Right : IEmbeddedObject
{
    public string? AirDistribution { get; set; }

    public int? FanSpeed { get; set; }

    public int? Temperature { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row2 : IEmbeddedObject
{
    public vehicle_Cabin_HVAC_Station_Row2_Left? Left { get; set; }

    public vehicle_Cabin_HVAC_Station_Row2_Right? Right { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row2_Left : IEmbeddedObject
{
    public string? AirDistribution { get; set; }

    public int? FanSpeed { get; set; }

    public int? Temperature { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row2_Right : IEmbeddedObject
{
    public string? AirDistribution { get; set; }

    public int? FanSpeed { get; set; }

    public int? Temperature { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row3 : IEmbeddedObject
{
    public vehicle_Cabin_HVAC_Station_Row3_Left? Left { get; set; }

    public vehicle_Cabin_HVAC_Station_Row3_Right? Right { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row3_Left : IEmbeddedObject
{
    public string? AirDistribution { get; set; }

    public int? FanSpeed { get; set; }

    public int? Temperature { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row3_Right : IEmbeddedObject
{
    public string? AirDistribution { get; set; }

    public int? FanSpeed { get; set; }

    public int? Temperature { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row4 : IEmbeddedObject
{
    public vehicle_Cabin_HVAC_Station_Row4_Left? Left { get; set; }

    public vehicle_Cabin_HVAC_Station_Row4_Right? Right { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row4_Left : IEmbeddedObject
{
    public string? AirDistribution { get; set; }

    public int? FanSpeed { get; set; }

    public int? Temperature { get; set; }
}

public partial class vehicle_Cabin_HVAC_Station_Row4_Right : IEmbeddedObject
{
    public string? AirDistribution { get; set; }

    public int? FanSpeed { get; set; }

    public int? Temperature { get; set; }
}

public partial class vehicle_Cabin_Infotainment : IEmbeddedObject
{
    public vehicle_Cabin_Infotainment_HMI? HMI { get; set; }

    public vehicle_Cabin_Infotainment_Media? Media { get; set; }

    public vehicle_Cabin_Infotainment_Navigation? Navigation { get; set; }
}

public partial class vehicle_Cabin_Infotainment_HMI : IEmbeddedObject
{
    public string? CurrentLanguage { get; set; }

    public string? DateFormat { get; set; }

    public string? DayNightMode { get; set; }

    public string? DistanceUnit { get; set; }

    public string? EVEconomyUnits { get; set; }

    public string? FuelEconomyUnits { get; set; }

    public string? TemperatureUnit { get; set; }

    public string? TimeFormat { get; set; }
}

public partial class vehicle_Cabin_Infotainment_Media : IEmbeddedObject
{
    public string? Action { get; set; }

    public string? DeclinedURI { get; set; }

    public vehicle_Cabin_Infotainment_Media_Played? Played { get; set; }

    public string? SelectedURI { get; set; }

    public int? Volume { get; set; }
}

public partial class vehicle_Cabin_Infotainment_Media_Played : IEmbeddedObject
{
    public string? Album { get; set; }

    public string? Artist { get; set; }

    public string? Source { get; set; }

    public string? Track { get; set; }

    public string? URI { get; set; }
}

public partial class vehicle_Cabin_Infotainment_Navigation : IEmbeddedObject
{
    public vehicle_Cabin_Infotainment_Navigation_CurrentLocation? CurrentLocation { get; set; }

    public vehicle_Cabin_Infotainment_Navigation_DestinationSet? DestinationSet { get; set; }
}

public partial class vehicle_Cabin_Infotainment_Navigation_CurrentLocation : IEmbeddedObject
{
    public double? Accuracy { get; set; }

    public double? Altitude { get; set; }

    public double? Heading { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public int? Speed { get; set; }
}

public partial class vehicle_Cabin_Infotainment_Navigation_DestinationSet : IEmbeddedObject
{
    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
}

public partial class vehicle_Cabin_Lights : IEmbeddedObject
{
    public int? AmbientLight { get; set; }

    public bool? IsDomeOn { get; set; }

    public bool? IsGloveBoxOn { get; set; }

    public bool? IsTrunkOn { get; set; }

    public int? LightIntensity { get; set; }

    public vehicle_Cabin_Lights_Row3? Row3 { get; set; }

    public vehicle_Cabin_Lights_Row4? Row4 { get; set; }

    public vehicle_Cabin_Lights_Spotlight? Spotlight { get; set; }
}

public partial class vehicle_Cabin_Lights_Row3 : IEmbeddedObject
{
    public bool? IsLeftOn { get; set; }

    public bool? IsRightOn { get; set; }

    public bool? IsSharedOn { get; set; }
}

public partial class vehicle_Cabin_Lights_Row4 : IEmbeddedObject
{
    public bool? IsLeftOn { get; set; }

    public bool? IsRightOn { get; set; }

    public bool? IsSharedOn { get; set; }
}

public partial class vehicle_Cabin_Lights_Spotlight : IEmbeddedObject
{
    public vehicle_Cabin_Lights_Spotlight_Row1? Row1 { get; set; }

    public vehicle_Cabin_Lights_Spotlight_Row2? Row2 { get; set; }
}

public partial class vehicle_Cabin_Lights_Spotlight_Row1 : IEmbeddedObject
{
    public bool? IsLeftOn { get; set; }

    public bool? IsRightOn { get; set; }

    public bool? IsSharedOn { get; set; }
}

public partial class vehicle_Cabin_Lights_Spotlight_Row2 : IEmbeddedObject
{
    public bool? IsLeftOn { get; set; }

    public bool? IsRightOn { get; set; }

    public bool? IsSharedOn { get; set; }
}

public partial class vehicle_Cabin_RearShade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_RearviewMirror : IEmbeddedObject
{
    public int? DimmingLevel { get; set; }
}

public partial class vehicle_Cabin_Seat : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1? Row1 { get; set; }

    public vehicle_Cabin_Seat_Row2? Row2 { get; set; }

    public vehicle_Cabin_Seat_Row3? Row3 { get; set; }

    public vehicle_Cabin_Seat_Row4? Row4 { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos1? Pos1 { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2? Pos2 { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3? Pos3 { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4? Pos4 { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5? Pos5 { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos1_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos1_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos1_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos1_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos2_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos2_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos2_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos2_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos3_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos3_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos3_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos3_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos4_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos4_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos4_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos4_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos5_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row1_Pos5_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row1_Pos5_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row1_Pos5_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos1? Pos1 { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2? Pos2 { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3? Pos3 { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4? Pos4 { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5? Pos5 { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos1_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos1_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos1_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos1_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos2_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos2_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos2_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos2_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos3_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos3_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos3_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos3_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos4_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos4_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos4_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos4_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos5_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row2_Pos5_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row2_Pos5_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row2_Pos5_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos1? Pos1 { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2? Pos2 { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3? Pos3 { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4? Pos4 { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5? Pos5 { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos1_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos1_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos1_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos1_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos2_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos2_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos2_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos2_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos3_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos3_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos3_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos3_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos4_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos4_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos4_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos4_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos5_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row3_Pos5_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row3_Pos5_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row3_Pos5_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos1? Pos1 { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2? Pos2 { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3? Pos3 { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4? Pos4 { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5? Pos5 { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos1_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos1_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos1_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos1_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos2_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos2_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos2_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos2_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos3_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos3_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos3_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos3_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos4_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos4_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos4_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos4_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5 : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos5_Airbag? Airbag { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Cushion? Cushion { get; set; }

    public bool? HasPassenger { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_HeadRestraint? HeadRestraint { get; set; }

    public int? Heating { get; set; }

    public bool? IsBelted { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Lumbar? Lumbar { get; set; }

    public int? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Occupant? Occupant { get; set; }

    public int? Position { get; set; }

    public int? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_SideBolster? SideBolster { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Switch? Switch { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Airbag : IEmbeddedObject
{
    public bool? IsDeployed { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Cushion : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Length { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_HeadRestraint : IEmbeddedObject
{
    public int? Height { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Lumbar : IEmbeddedObject
{
    public int? Height { get; set; }

    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Occupant : IEmbeddedObject
{
    public vehicle_Cabin_Seat_Row4_Pos5_Occupant_Identifier? Identifier { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Occupant_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_SideBolster : IEmbeddedObject
{
    public int? Inflation { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Switch : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Cooler { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Switch_Cushion? Cushion { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Switch_HeadRestraint? HeadRestraint { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Switch_Lumbar? Lumbar { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Switch_Massage? Massage { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Switch_Recline? Recline { get; set; }

    public vehicle_Cabin_Seat_Row4_Pos5_Switch_SideBolster? SideBolster { get; set; }

    public bool? Up { get; set; }

    public bool? Warmer { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Switch_Cushion : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Down { get; set; }

    public bool? Forward { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Switch_HeadRestraint : IEmbeddedObject
{
    public bool? Down { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Switch_Lumbar : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Down { get; set; }

    public bool? Inflate { get; set; }

    public bool? Up { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Switch_Massage : IEmbeddedObject
{
    public bool? Decrease { get; set; }

    public bool? Increase { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Switch_Recline : IEmbeddedObject
{
    public bool? Backward { get; set; }

    public bool? Forward { get; set; }
}

public partial class vehicle_Cabin_Seat_Row4_Pos5_Switch_SideBolster : IEmbeddedObject
{
    public bool? Deflate { get; set; }

    public bool? Inflate { get; set; }
}

public partial class vehicle_Cabin_Sunroof : IEmbeddedObject
{
    public int? Position { get; set; }

    public vehicle_Cabin_Sunroof_Shade? Shade { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Cabin_Sunroof_Shade : IEmbeddedObject
{
    public int? Position { get; set; }

    public string? Switch { get; set; }
}

public partial class vehicle_Chassis : IEmbeddedObject
{
    public vehicle_Chassis_Accelerator? Accelerator { get; set; }

    public vehicle_Chassis_Axle? Axle { get; set; }

    public vehicle_Chassis_Brake? Brake { get; set; }

    public int? CurbWeight { get; set; }

    public int? GrossWeight { get; set; }

    public int? Height { get; set; }

    public int? Length { get; set; }

    public vehicle_Chassis_ParkingBrake? ParkingBrake { get; set; }

    public vehicle_Chassis_SteeringWheel? SteeringWheel { get; set; }

    public int? TowWeight { get; set; }

    public int? Track { get; set; }

    public vehicle_Chassis_Trailer? Trailer { get; set; }

    public int? Wheelbase { get; set; }

    public int? Width { get; set; }
}

public partial class vehicle_Chassis_Accelerator : IEmbeddedObject
{
    public int? PedalPosition { get; set; }
}

public partial class vehicle_Chassis_Axle : IEmbeddedObject
{
    public vehicle_Chassis_Axle_Row1? Row1 { get; set; }

    public int? Row1Count { get; set; }

    public vehicle_Chassis_Axle_Row2? Row2 { get; set; }

    public int? Row2Count { get; set; }
}

public partial class vehicle_Chassis_Axle_Row1 : IEmbeddedObject
{
    public int? TireDiameter { get; set; }

    public int? TireWidth { get; set; }

    public vehicle_Chassis_Axle_Row1_Wheel? Wheel { get; set; }

    public int? WheelCount { get; set; }

    public int? WheelDiameter { get; set; }

    public int? WheelWidth { get; set; }
}

public partial class vehicle_Chassis_Axle_Row1_Wheel : IEmbeddedObject
{
    public vehicle_Chassis_Axle_Row1_Wheel_Left? Left { get; set; }

    public vehicle_Chassis_Axle_Row1_Wheel_Right? Right { get; set; }
}

public partial class vehicle_Chassis_Axle_Row1_Wheel_Left : IEmbeddedObject
{
    public vehicle_Chassis_Axle_Row1_Wheel_Left_Brake? Brake { get; set; }

    public vehicle_Chassis_Axle_Row1_Wheel_Left_Tire? Tire { get; set; }
}

public partial class vehicle_Chassis_Axle_Row1_Wheel_Left_Brake : IEmbeddedObject
{
    public bool? BrakesWorn { get; set; }

    public int? FluidLevel { get; set; }

    public bool? FluidLevelLow { get; set; }

    public int? PadWear { get; set; }
}

public partial class vehicle_Chassis_Axle_Row1_Wheel_Left_Tire : IEmbeddedObject
{
    public int? Pressure { get; set; }

    public bool? PressureLow { get; set; }

    public double? Temperature { get; set; }
}

public partial class vehicle_Chassis_Axle_Row1_Wheel_Right : IEmbeddedObject
{
    public vehicle_Chassis_Axle_Row1_Wheel_Right_Brake? Brake { get; set; }

    public vehicle_Chassis_Axle_Row1_Wheel_Right_Tire? Tire { get; set; }
}

public partial class vehicle_Chassis_Axle_Row1_Wheel_Right_Brake : IEmbeddedObject
{
    public bool? BrakesWorn { get; set; }

    public int? FluidLevel { get; set; }

    public bool? FluidLevelLow { get; set; }

    public int? PadWear { get; set; }
}

public partial class vehicle_Chassis_Axle_Row1_Wheel_Right_Tire : IEmbeddedObject
{
    public int? Pressure { get; set; }

    public bool? PressureLow { get; set; }

    public double? Temperature { get; set; }
}

public partial class vehicle_Chassis_Axle_Row2 : IEmbeddedObject
{
    public int? TireDiameter { get; set; }

    public int? TireWidth { get; set; }

    public vehicle_Chassis_Axle_Row2_Wheel? Wheel { get; set; }

    public int? WheelCount { get; set; }

    public int? WheelDiameter { get; set; }

    public int? WheelWidth { get; set; }
}

public partial class vehicle_Chassis_Axle_Row2_Wheel : IEmbeddedObject
{
    public vehicle_Chassis_Axle_Row2_Wheel_Left? Left { get; set; }

    public vehicle_Chassis_Axle_Row2_Wheel_Right? Right { get; set; }
}

public partial class vehicle_Chassis_Axle_Row2_Wheel_Left : IEmbeddedObject
{
    public vehicle_Chassis_Axle_Row2_Wheel_Left_Brake? Brake { get; set; }

    public vehicle_Chassis_Axle_Row2_Wheel_Left_Tire? Tire { get; set; }
}

public partial class vehicle_Chassis_Axle_Row2_Wheel_Left_Brake : IEmbeddedObject
{
    public bool? BrakesWorn { get; set; }

    public int? FluidLevel { get; set; }

    public bool? FluidLevelLow { get; set; }

    public int? PadWear { get; set; }
}

public partial class vehicle_Chassis_Axle_Row2_Wheel_Left_Tire : IEmbeddedObject
{
    public int? Pressure { get; set; }

    public bool? PressureLow { get; set; }

    public double? Temperature { get; set; }
}

public partial class vehicle_Chassis_Axle_Row2_Wheel_Right : IEmbeddedObject
{
    public vehicle_Chassis_Axle_Row2_Wheel_Right_Brake? Brake { get; set; }

    public vehicle_Chassis_Axle_Row2_Wheel_Right_Tire? Tire { get; set; }
}

public partial class vehicle_Chassis_Axle_Row2_Wheel_Right_Brake : IEmbeddedObject
{
    public bool? BrakesWorn { get; set; }

    public int? FluidLevel { get; set; }

    public bool? FluidLevelLow { get; set; }

    public int? PadWear { get; set; }
}

public partial class vehicle_Chassis_Axle_Row2_Wheel_Right_Tire : IEmbeddedObject
{
    public int? Pressure { get; set; }

    public bool? PressureLow { get; set; }

    public double? Temperature { get; set; }
}

public partial class vehicle_Chassis_Brake : IEmbeddedObject
{
    public int? PedalPosition { get; set; }
}

public partial class vehicle_Chassis_ParkingBrake : IEmbeddedObject
{
    public bool? IsEngaged { get; set; }
}

public partial class vehicle_Chassis_SteeringWheel : IEmbeddedObject
{
    public int? Angle { get; set; }

    public int? Extension { get; set; }

    public string? Position { get; set; }

    public int? Tilt { get; set; }
}

public partial class vehicle_Chassis_Trailer : IEmbeddedObject
{
    public bool? Connected { get; set; }
}

public partial class vehicle_CurrentLocation : IEmbeddedObject
{
    public double? Accuracy { get; set; }

    public double? Altitude { get; set; }

    public double? Heading { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
}

public partial class vehicle_Driver : IEmbeddedObject
{
    public double? AttentiveProbability { get; set; }

    public double? DistractionLevel { get; set; }

    public bool? EyesOnRoad { get; set; }

    public double? FatigueLevel { get; set; }

    public int? HeartRate { get; set; }

    public vehicle_Driver_Identifier? Identifier { get; set; }
}

public partial class vehicle_Driver_Identifier : IEmbeddedObject
{
    public string? Issuer { get; set; }

    public string? Subject { get; set; }
}

public partial class vehicle_OBD : IEmbeddedObject
{
    public double? AbsoluteLoad { get; set; }

    public double? AcceleratorPositionD { get; set; }

    public double? AcceleratorPositionE { get; set; }

    public double? AcceleratorPositionF { get; set; }

    public string? AirStatus { get; set; }

    public double? AmbientAirTemperature { get; set; }

    public bool? AuxInputStatus { get; set; }

    public double? BarometricPressure { get; set; }

    public vehicle_OBD_Catalyst? Catalyst { get; set; }

    public double? CommandedEGR { get; set; }

    public double? CommandedEVAP { get; set; }

    public double? CommandedEquivalenceRatio { get; set; }

    public double? ControlModuleVoltage { get; set; }

    public double? CoolantTemperature { get; set; }

    public string? DTCList { get; set; }

    public double? DistanceSinceDTCClear { get; set; }

    public double? DistanceWithMIL { get; set; }

    public vehicle_OBD_DriveCycleStatus? DriveCycleStatus { get; set; }

    public double? EGRError { get; set; }

    public double? EVAPVaporPressure { get; set; }

    public double? EVAPVaporPressureAbsolute { get; set; }

    public double? EVAPVaporPressureAlternate { get; set; }

    public double? EngineLoad { get; set; }

    public double? EngineSpeed { get; set; }

    public double? EthanolPercent { get; set; }

    public string? FreezeDTC { get; set; }

    public double? FuelInjectionTiming { get; set; }

    public double? FuelLevel { get; set; }

    public double? FuelPressure { get; set; }

    public double? FuelRailPressureAbsolute { get; set; }

    public double? FuelRailPressureDirect { get; set; }

    public double? FuelRailPressureVac { get; set; }

    public double? FuelRate { get; set; }

    public string? FuelStatus { get; set; }

    public string? FuelType { get; set; }

    public double? HybridBatteryRemaining { get; set; }

    public double? IntakeTemp { get; set; }

    public double? LongTermFuelTrim1 { get; set; }

    public double? LongTermFuelTrim2 { get; set; }

    public double? LongTermO2Trim1 { get; set; }

    public double? LongTermO2Trim2 { get; set; }

    public double? MAF { get; set; }

    public double? MAP { get; set; }

    public double? MaxMAF { get; set; }

    public vehicle_OBD_O2? O2 { get; set; }

    public vehicle_OBD_O2Alt? O2Alt { get; set; }

    public vehicle_OBD_O2WR? O2WR { get; set; }

    public double? OilTemperature { get; set; }

    public int? PidsA { get; set; }

    public int? PidsB { get; set; }

    public int? PidsC { get; set; }

    public double? RelativeAcceleratorPosition { get; set; }

    public double? RelativeThrottlePosition { get; set; }

    public double? RunTime { get; set; }

    public double? RunTimeMIL { get; set; }

    public double? ShortTermFuelTrim1 { get; set; }

    public double? ShortTermFuelTrim2 { get; set; }

    public double? ShortTermO2Trim1 { get; set; }

    public double? ShortTermO2Trim2 { get; set; }

    public double? Speed { get; set; }

    public vehicle_OBD_Status? Status { get; set; }

    public double? ThrottleActuator { get; set; }

    public double? ThrottlePosition { get; set; }

    public double? ThrottlePositionB { get; set; }

    public double? ThrottlePositionC { get; set; }

    public double? TimeSinceDTCCleared { get; set; }

    public double? TimingAdvance { get; set; }

    public int? WarmupsSinceDTCClear { get; set; }
}

public partial class vehicle_OBD_Catalyst : IEmbeddedObject
{
    public vehicle_OBD_Catalyst_Bank1? Bank1 { get; set; }

    public vehicle_OBD_Catalyst_Bank2? Bank2 { get; set; }
}

public partial class vehicle_OBD_Catalyst_Bank1 : IEmbeddedObject
{
    public double? Temperature1 { get; set; }

    public double? Temperature2 { get; set; }
}

public partial class vehicle_OBD_Catalyst_Bank2 : IEmbeddedObject
{
    public double? Temperature1 { get; set; }

    public double? Temperature2 { get; set; }
}

public partial class vehicle_OBD_DriveCycleStatus : IEmbeddedObject
{
    public int? DTCCount { get; set; }

    public string? IgnitionType { get; set; }

    public bool? MIL { get; set; }
}

public partial class vehicle_OBD_O2 : IEmbeddedObject
{
    public vehicle_OBD_O2_Bank1? Bank1 { get; set; }

    public vehicle_OBD_O2_Bank2? Bank2 { get; set; }
}

public partial class vehicle_OBD_O2Alt : IEmbeddedObject
{
    public vehicle_OBD_O2Alt_Bank1? Bank1 { get; set; }

    public vehicle_OBD_O2Alt_Bank2? Bank2 { get; set; }
}

public partial class vehicle_OBD_O2Alt_Bank1 : IEmbeddedObject
{
    public string? Sensor1 { get; set; }

    public string? Sensor2 { get; set; }

    public string? Sensor3 { get; set; }

    public string? Sensor4 { get; set; }
}

public partial class vehicle_OBD_O2Alt_Bank2 : IEmbeddedObject
{
    public string? Sensor1 { get; set; }

    public string? Sensor2 { get; set; }

    public string? Sensor3 { get; set; }

    public string? Sensor4 { get; set; }
}

public partial class vehicle_OBD_O2WR : IEmbeddedObject
{
    public vehicle_OBD_O2WR_Sensor1? Sensor1 { get; set; }

    public vehicle_OBD_O2WR_Sensor2? Sensor2 { get; set; }

    public vehicle_OBD_O2WR_Sensor3? Sensor3 { get; set; }

    public vehicle_OBD_O2WR_Sensor4? Sensor4 { get; set; }

    public vehicle_OBD_O2WR_Sensor5? Sensor5 { get; set; }

    public vehicle_OBD_O2WR_Sensor6? Sensor6 { get; set; }

    public vehicle_OBD_O2WR_Sensor7? Sensor7 { get; set; }

    public vehicle_OBD_O2WR_Sensor8? Sensor8 { get; set; }
}

public partial class vehicle_OBD_O2WR_Sensor1 : IEmbeddedObject
{
    public double? Current { get; set; }

    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2WR_Sensor2 : IEmbeddedObject
{
    public double? Current { get; set; }

    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2WR_Sensor3 : IEmbeddedObject
{
    public double? Current { get; set; }

    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2WR_Sensor4 : IEmbeddedObject
{
    public double? Current { get; set; }

    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2WR_Sensor5 : IEmbeddedObject
{
    public double? Current { get; set; }

    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2WR_Sensor6 : IEmbeddedObject
{
    public double? Current { get; set; }

    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2WR_Sensor7 : IEmbeddedObject
{
    public double? Current { get; set; }

    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2WR_Sensor8 : IEmbeddedObject
{
    public double? Current { get; set; }

    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2_Bank1 : IEmbeddedObject
{
    public vehicle_OBD_O2_Bank1_Sensor1? Sensor1 { get; set; }

    public vehicle_OBD_O2_Bank1_Sensor2? Sensor2 { get; set; }

    public vehicle_OBD_O2_Bank1_Sensor3? Sensor3 { get; set; }

    public vehicle_OBD_O2_Bank1_Sensor4? Sensor4 { get; set; }
}

public partial class vehicle_OBD_O2_Bank1_Sensor1 : IEmbeddedObject
{
    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2_Bank1_Sensor2 : IEmbeddedObject
{
    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2_Bank1_Sensor3 : IEmbeddedObject
{
    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2_Bank1_Sensor4 : IEmbeddedObject
{
    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2_Bank2 : IEmbeddedObject
{
    public vehicle_OBD_O2_Bank2_Sensor1? Sensor1 { get; set; }

    public vehicle_OBD_O2_Bank2_Sensor2? Sensor2 { get; set; }

    public vehicle_OBD_O2_Bank2_Sensor3? Sensor3 { get; set; }

    public vehicle_OBD_O2_Bank2_Sensor4? Sensor4 { get; set; }
}

public partial class vehicle_OBD_O2_Bank2_Sensor1 : IEmbeddedObject
{
    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2_Bank2_Sensor2 : IEmbeddedObject
{
    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2_Bank2_Sensor3 : IEmbeddedObject
{
    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_O2_Bank2_Sensor4 : IEmbeddedObject
{
    public double? Voltage { get; set; }
}

public partial class vehicle_OBD_Status : IEmbeddedObject
{
    public int? DTCCount { get; set; }

    public string? IgnitionType { get; set; }

    public bool? MIL { get; set; }
}

public partial class vehicle_Powertrain : IEmbeddedObject
{
    public double? AccumulatedBrakingEnergy { get; set; }

    public vehicle_Powertrain_Battery? Battery { get; set; }

    public vehicle_Powertrain_CombustionEngine? CombustionEngine { get; set; }

    public vehicle_Powertrain_ElectricMotor? ElectricMotor { get; set; }

    public string? FuelCell { get; set; }

    public vehicle_Powertrain_FuelSystem? FuelSystem { get; set; }

    public int? Range { get; set; }

    public vehicle_Powertrain_Transmission? Transmission { get; set; }
}

public partial class vehicle_Powertrain_Battery : IEmbeddedObject
{
    public double? AccumulatedChargedEnergy { get; set; }

    public double? AccumulatedConsumedEnergy { get; set; }

    public vehicle_Powertrain_Battery_Charging? Charging { get; set; }

    public int? GrossCapacity { get; set; }

    public int? NetCapacity { get; set; }

    public int? NominalVoltage { get; set; }

    public int? Range { get; set; }

    public int? ReferentVoltage { get; set; }

    public vehicle_Powertrain_Battery_StateOfCharge? StateOfCharge { get; set; }

    public double? Temperature { get; set; }
}

public partial class vehicle_Powertrain_Battery_Charging : IEmbeddedObject
{
    public double? ChargeCurrent { get; set; }

    public int? ChargeLimit { get; set; }

    public bool? ChargePlugStatus { get; set; }

    public string? ChargePlugType { get; set; }

    public string? ChargePortFlap { get; set; }

    public double? ChargeRate { get; set; }

    public double? ChargeVoltage { get; set; }

    public double? MaximumChargingCurrent { get; set; }

    public string? Mode { get; set; }

    public string? StartStopCharging { get; set; }

    public bool? Status { get; set; }

    public int? TimeToComplete { get; set; }

    public vehicle_Powertrain_Battery_Charging_Timer? Timer { get; set; }
}

public partial class vehicle_Powertrain_Battery_Charging_Timer : IEmbeddedObject
{
    public string? Mode { get; set; }

    public int? Time { get; set; }
}

public partial class vehicle_Powertrain_Battery_StateOfCharge : IEmbeddedObject
{
    public double? Current { get; set; }

    public double? Displayed { get; set; }

    public int? Target { get; set; }
}

public partial class vehicle_Powertrain_CombustionEngine : IEmbeddedObject
{
    public string? AspirationType { get; set; }

    public double? Bore { get; set; }

    public string? CompressionRatio { get; set; }

    public string? Configuration { get; set; }

    public vehicle_Powertrain_CombustionEngine_DieselParticulateFilter? DieselParticulateFilter { get; set; }

    public int? Displacement { get; set; }

    public vehicle_Powertrain_CombustionEngine_Engine? Engine { get; set; }

    public double? EngineCoolantCapacity { get; set; }

    public double? EngineOilCapacity { get; set; }

    public string? FuelType { get; set; }

    public int? MaxPower { get; set; }

    public int? MaxTorque { get; set; }

    public int? NumberOfCylinders { get; set; }

    public int? NumberOfValvesPerCylinder { get; set; }

    public int? OilLifeRemaining { get; set; }

    public double? StrokeLength { get; set; }
}

public partial class vehicle_Powertrain_CombustionEngine_DieselParticulateFilter : IEmbeddedObject
{
    public double? DeltaPressure { get; set; }

    public double? InletTemperature { get; set; }

    public double? OutletTemperature { get; set; }
}

public partial class vehicle_Powertrain_CombustionEngine_Engine : IEmbeddedObject
{
    public int? ECT { get; set; }

    public int? EOP { get; set; }

    public int? EOT { get; set; }

    public int? MAF { get; set; }

    public int? MAP { get; set; }

    public int? Power { get; set; }

    public int? Speed { get; set; }

    public int? TPS { get; set; }

    public int? Torque { get; set; }
}

public partial class vehicle_Powertrain_ElectricMotor : IEmbeddedObject
{
    public int? MaxPower { get; set; }

    public int? MaxRegenPower { get; set; }

    public int? MaxRegenTorque { get; set; }

    public int? MaxTorque { get; set; }

    public vehicle_Powertrain_ElectricMotor_Motor? Motor { get; set; }
}

public partial class vehicle_Powertrain_ElectricMotor_Motor : IEmbeddedObject
{
    public int? CoolantTemperature { get; set; }

    public int? Power { get; set; }

    public int? Rpm { get; set; }

    public int? Temperature { get; set; }

    public int? Torque { get; set; }
}

public partial class vehicle_Powertrain_FuelSystem : IEmbeddedObject
{
    public double? AverageConsumption { get; set; }

    public double? ConsumptionSinceStart { get; set; }

    public bool? EngineStopStartEnabled { get; set; }

    public string? FuelType { get; set; }

    public string? HybridType { get; set; }

    public double? InstantConsumption { get; set; }

    public int? Level { get; set; }

    public bool? LowFuelLevel { get; set; }

    public int? Range { get; set; }

    public double? TankCapacity { get; set; }

    public int? TimeSinceStart { get; set; }
}

public partial class vehicle_Powertrain_Transmission : IEmbeddedObject
{
    public int? ClutchWear { get; set; }

    public string? DriveType { get; set; }

    public int? Gear { get; set; }

    public string? GearChangeMode { get; set; }

    public int? GearCount { get; set; }

    public string? PerformanceMode { get; set; }

    public int? Speed { get; set; }

    public int? Temperature { get; set; }

    public double? TravelledDistance { get; set; }

    public string? Type { get; set; }
}

public partial class vehicle_Trailer : IEmbeddedObject
{
    public bool? Connected { get; set; }
}

public partial class vehicle_VehicleIdentification : IEmbeddedObject
{
    public string? ACRISSCode { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? VIN { get; set; }

    public string? WMI { get; set; }

    public int? Year { get; set; }

    [MapTo("bodyType")]
    public string? BodyType { get; set; }

    [MapTo("dateVehicleFirstRegistered")]
    public string? DateVehicleFirstRegistered { get; set; }

    [MapTo("knownVehicleDamages")]
    public string? KnownVehicleDamages { get; set; }

    [MapTo("meetsEmissionStandard")]
    public string? MeetsEmissionStandard { get; set; }

    [MapTo("productionDate")]
    public string? ProductionDate { get; set; }

    [MapTo("purchaseDate")]
    public string? PurchaseDate { get; set; }

    [MapTo("vehicleConfiguration")]
    public string? VehicleConfiguration { get; set; }

    [MapTo("vehicleModelDate")]
    public string? VehicleModelDate { get; set; }

    [MapTo("vehicleSeatingCapacity")]
    public int? VehicleSeatingCapacity { get; set; }

    [MapTo("vehicleSpecialUsage")]
    public string? VehicleSpecialUsage { get; set; }

    [MapTo("vehicleinteriorColor")]
    public string? VehicleinteriorColor { get; set; }

    [MapTo("vehicleinteriorType")]
    public string? VehicleinteriorType { get; set; }
}

public partial class vehicle_VersionVSS : IEmbeddedObject
{
    public string? Label { get; set; }

    public int? Major { get; set; }

    public int? Minor { get; set; }

    public int? Patch { get; set; }
}
