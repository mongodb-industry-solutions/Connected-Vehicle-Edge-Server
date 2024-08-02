using UnityEngine;
using System;
using System.Collections.Generic;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Subscribing;
using System.Text;
using Newtonsoft.Json;

public class MQTTManager : MonoBehaviour
{
    public static MQTTManager Instance { get; private set; }
    public event Action OnMQTTConnected;

    private IMqttClient mqttClient;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeMQTT();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private async void InitializeMQTT()
    {
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithClientId("UnityClient")
            .WithTcpServer("23.22.137.53", 1883)  
            .WithCleanSession()
            .Build();

        mqttClient.UseConnectedHandler(async e =>
        {
            Debug.Log("Connected to MQTT broker.");

            // Subscribe to relevant topics here
            var topicFilter = new MqttClientSubscribeOptionsBuilder()
                .WithTopicFilter("vehicle/updates")
                .Build();

            await mqttClient.SubscribeAsync(topicFilter);
            OnMQTTConnected?.Invoke();
        });

        mqttClient.UseDisconnectedHandler(e =>
        {
            Debug.LogError("Disconnected from MQTT broker.");
        });

        mqttClient.UseApplicationMessageReceivedHandler(e =>
        {
            Debug.Log("Received message from MQTT broker.");
            HandleIncomingMessage(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
        });

        try
        {
            await mqttClient.ConnectAsync(options);
        }
        catch (Exception ex)
        {
            Debug.LogError($@"Error connecting to MQTT broker. {ex.Message}");
        }
    }

    private void HandleIncomingMessage(string message)
    {
        // Parse the message and update vehicle data
        var vehicleData = JsonConvert.DeserializeObject<VehicleData>(message);
        if (vehicleData != null)
        {
            // Perform operations with the vehicle data
            Debug.Log("Vehicle Data: " + vehicleData.VehicleName);
        }
        else
        {
            Debug.LogError("Failed to parse vehicle data message.");
        }
    }
}
