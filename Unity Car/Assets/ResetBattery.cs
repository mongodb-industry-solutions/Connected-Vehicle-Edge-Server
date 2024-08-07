using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;
using System.Text;
using System;

public class ResetBattery : MonoBehaviour
{
    private MqttClient client;
    private string brokerAddress = "23.22.137.53";
    private int brokerPort = 1883;
    private string topic = "vehicle/updates";

    private void Start()
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

    public void OnButtonClick()
    {
        VehicleData vehicleData = new VehicleData
        {
            Id = "658876fde27a68ff985cdb4d",
            BatteryCurrent = 100,
            BatteryStatusOK = true
        };

        string jsonData = JsonConvert.SerializeObject(vehicleData);
        PublishMqttMessage(topic, jsonData);
    }

    private void PublishMqttMessage(string topic, string message)
    {
        client.Publish(topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
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
        public string Id;
        public int BatteryCurrent;
        public bool BatteryStatusOK;
    }
}
