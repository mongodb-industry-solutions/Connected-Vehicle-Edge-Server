using System;
using System.Collections;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;
using System.Threading;
using System.Text;

public class BatteryTelemetry : MonoBehaviour
{
    private MqttClient client;
    private string brokerAddress = "23.22.137.53";
    private int brokerPort = 1883;
    private string topic = "VehicleData";
    private VehicleData vehicleData;
    private bool reduceBatteryActive = false;
    private SynchronizationContext unityContext;

    private void Start()
    {
        unityContext = SynchronizationContext.Current;
        SetupMqttClient();
        InitializeBattery();
        StartCoroutine(ReduceBattery());
    }

    private void SetupMqttClient()
    {
        client = new MqttClient(brokerAddress, brokerPort, false, null, null, MqttSslProtocols.None);
        string clientId = System.Guid.NewGuid().ToString();
        client.Connect(clientId);

        if (client.IsConnected)
        {
            Debug.Log("Connected to MQTT broker.");
        }
        else
        {
            Debug.LogError("Failed to connect to MQTT broker.");
        }
    }

    private void InitializeBattery()
    {
        vehicleData = new VehicleData
        {
            BatteryCurrent = 100,
            BatteryTemp = 28,
            LightsOn = true
        };
    }

    private IEnumerator ReduceBattery()
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
        string jsonData = JsonConvert.SerializeObject(vehicleData);
        client.Publish(topic, Encoding.UTF8.GetBytes(jsonData), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
    }

    private void OnDestroy()
    {
        if (client != null && client.IsConnected)
        {
            client.Disconnect();
            Debug.Log("Disconnected from MQTT broker.");
        }
    }

    [Serializable]
    public class VehicleData
    {
        public int BatteryCurrent;
        public int BatteryTemp;
        public bool LightsOn;
    }
}
