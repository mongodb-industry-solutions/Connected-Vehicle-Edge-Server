using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using MQTTnet;
using MQTTnet.Client;
using System.Text;
using System.Threading.Tasks;

public class ResetBattery : MonoBehaviour
{
    public string mqttTopic = "vehicle/updates"; // Define the MQTT topic for updates

    public async void OnButtonClick()
    {
        // Simulate creating an updated vehicle data object with the new battery status
        VehicleData vehicleData = new VehicleData
        {
            Id = "658876fde27a68ff985cdb4d", 
            BatteryCurrent = 100,
            BatteryStatusOK = true
        };

        // Convert the vehicle data to a JSON string
        string jsonData = JsonConvert.SerializeObject(vehicleData);

        // Publish the updated data to the MQTT broker
        await PublishMqttMessageAsync(mqttTopic, jsonData);
    }

    private async Task PublishMqttMessageAsync(string topic, string message)
    {
        // Create a new MQTT client
        var mqttFactory = new MqttFactory();
        var mqttClient = mqttFactory.CreateMqttClient();

        var mqttClientOptions = new MqttClientOptionsBuilder()
            .WithTcpServer("23.22.137.53") 
            .WithClientId("UnityClient") // Optional: Set a unique client ID
            .Build();

        // Connect to the MQTT broker
        await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

        // Create the MQTT message to publish
        var mqttMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(message)
            .WithExactlyOnceQoS() 
            .WithRetainFlag(false)
            .Build();

        // Publish the message
        await mqttClient.PublishAsync(mqttMessage, CancellationToken.None);

        // Disconnect from the MQTT broker
        await mqttClient.DisconnectAsync();
    }
}
