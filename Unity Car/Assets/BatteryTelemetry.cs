using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class BatteryTelemetry : MonoBehaviour
{
    private VehicleData vehicleData;
    private bool reduceBatteryActive = false;

    private void Start()
    {
        if (MQTTManager.Instance != null)
        {
            MQTTManager.Instance.OnMQTTConnected += OnMQTTConnected;
        }
        else
        {
            Debug.LogError("MQTTManager instance not found.");
        }
    }

    private void OnMQTTConnected()
    {
        // Subscribe to relevant topics here or handle data reception
        InitializeBattery();
        StartCoroutine(ReduceBattery());
    }

    private void InitializeBattery()
    {
        // Dummy data for initialization
        vehicleData = new VehicleData
        {
            BatteryCurrent = 100,
            BatteryTemp = 28
        };
    }

    public IEnumerator ReduceBattery()
    {
        if (vehicleData == null)
        {
            Debug.LogError("VehicleData is null.");
            yield break;
        }

        reduceBatteryActive = true;
        while (vehicleData.BatteryCurrent > 0 && reduceBatteryActive)
        {
            yield return new WaitForSeconds(2);
            if (vehicleData.LightsOn)
            {
                vehicleData.BatteryCurrent -= 1; 
                PublishBatteryData();
            }
        }
    }

    private void PublishBatteryData()
    {
        // Convert vehicleData to JSON and publish to MQTT
        string jsonData = JsonConvert.SerializeObject(vehicleData);
        MQTTManager.Instance.Publish("VehicleData", jsonData);
    }
}
