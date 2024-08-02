using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;

public class ResetBattery : MonoBehaviour
{

    private MqttClient client;
    private string brokerAddress = "23.22.137.53";
    private int brokerPort = 1883;
    private string topic = "/status";

    void Start()
    {
        // Initialize MQTT client and connect to broker
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

    public void OnButtonClick(){

        var messagePayload = new
        {
            id = "658876fde27a68ff985cdb4d",
            collection = "vehicle_data",
            updateFields = new
            {
                Battery_Current = 100,
                Battery_Status_OK = true
            }
        };

        string messageString = JsonConvert.SerializeObject(messagePayload);

        client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(messageString), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);

        Debug.Log("Published battery status update to MQTT broker.");
    }

    void OnDestroy()
    {
        if (client != null && client.IsConnected)
        {
            client.Disconnect();
            Debug.Log("Disconnected from MQTT broker.");
        }
    }
}
