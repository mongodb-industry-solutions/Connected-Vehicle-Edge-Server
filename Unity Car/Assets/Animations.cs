using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using System.Text;

public class Animations : MonoBehaviour
{
    private IManagedMqttClient mqttClient;
    public Animator SportCar;

    public GameObject FrontLights;

    public GameObject TailLights;

    public AudioSource EngineSound;
    public AudioClip EngineStart, EngineIdle, EngineStop;

    public GameObject SportCarVibration;
    private Coroutine carVibrationCoroutine;

    private async void Start()
    {
        var options = new ManagedMqttClientOptionsBuilder()
            .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
            .WithClientOptions(new MqttClientOptionsBuilder()
                .WithClientId("UnityClient")
                .WithTcpServer("23.22.137.53", 1883)  
                .Build())
            .Build();

        mqttClient = new MqttFactory().CreateManagedMqttClient();
        mqttClient.UseApplicationMessageReceivedHandler(HandleMqttMessageReceived);
        await mqttClient.StartAsync(options);

        await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("vehicle/updates").Build());
    }

    private void HandleMqttMessageReceived(MqttApplicationMessageReceivedEventArgs e)
    {
        string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
        VehicleData modifiedObject = JsonUtility.FromJson<VehicleData>(payload);

        // Lights Modifications
        if (modifiedObject.LightsOn && !FrontLights.activeSelf)
        {
            EngineSound.clip = EngineStart;
            EngineSound.loop = false;
            EngineSound.Play();
            Invoke("EngineIdleSound", EngineSound.clip.length);
            FrontLights.SetActive(true);
            TailLights.SetActive(true);
            StartVibration();
        }
        else if (!modifiedObject.LightsOn && FrontLights.activeSelf)
        {
            EngineSound.clip = EngineStop;
            EngineSound.loop = false;
            EngineSound.Play();
            FrontLights.SetActive(false);
            TailLights.SetActive(false);
            StopVibration();
        }

        // Open Door Modifications
        if (modifiedObject.DriverDoorOpen && !SportCar.GetBool("Door_Open"))
        {
            SportCar.SetTrigger("open_door");
            SportCar.SetBool("Door_Open", true);
        }
        else if (!modifiedObject.DriverDoorOpen && SportCar.GetBool("Door_Open"))
        {
            SportCar.SetTrigger("close_door");
            SportCar.SetBool("Door_Open", false);
        }

        // Hood Modifications
        if (modifiedObject.HoodOpen && !SportCar.GetBool("Hood_Open"))
        {
            SportCar.SetTrigger("open_hood");
            SportCar.SetBool("Hood_Open", true);
        }
        else if (!modifiedObject.HoodOpen && SportCar.GetBool("Hood_Open"))
        {
            SportCar.SetTrigger("close_hood");
            SportCar.SetBool("Hood_Open", false);
        }

        // Print or process the modified object
        Debug.Log($"Modified object: {modifiedObject}");
    }

    void EngineIdleSound()
    {
        if (FrontLights.activeSelf)
        {
            EngineSound.clip = EngineIdle;
            EngineSound.loop = true;
            EngineSound.Play();
        }
    }

    void StartVibration()
    {
        // Start vibration effect
        if (carVibrationCoroutine == null)
        {
            carVibrationCoroutine = StartCoroutine(VibrateCar());
        }
    }

    void StopVibration()
    {
        // Stop all coroutines to stop the vibration
        if (carVibrationCoroutine != null)
        {
            StopCoroutine(carVibrationCoroutine);
            carVibrationCoroutine = null;
        }
    }

    IEnumerator VibrateCar()
    {
        // Original position of the car
        Vector3 originalPosition = SportCarVibration.transform.position;
        float vibrationIntensity = 0.009f; // value can be adjusted for more or less vibration

        while (true)
        {
            // Simulate gentle vibration by small random position adjustments
            SportCarVibration.transform.position = originalPosition + new Vector3(
                UnityEngine.Random.Range(-vibrationIntensity, vibrationIntensity),
                UnityEngine.Random.Range(-vibrationIntensity, vibrationIntensity),
                UnityEngine.Random.Range(-vibrationIntensity, vibrationIntensity)
            );

            // Wait for a short period of time before the next vibration
            yield return new WaitForSeconds(0.07f); // Adjust for faster or slower vibration
        }
    }
}
