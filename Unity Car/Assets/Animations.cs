using System;
using System.Collections;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;
using System.Threading;

public class Animations : MonoBehaviour
{
    private MqttClient client;
    public Animator SportCar;
    public GameObject FrontLights;
    public GameObject TailLights;
    public AudioSource EngineSound;
    public AudioClip EngineStart, EngineIdle, EngineStop;
    public GameObject SportCarVibration;
    private Coroutine carVibrationCoroutine;
    private string brokerAddress = "23.22.137.53";
    private int brokerPort = 1883;
    private string topic = "vehicle/updates";
    private SynchronizationContext unityContext;

    private void Start()
    {
        unityContext = SynchronizationContext.Current;
        SetupMqttClient();
    }

    private void SetupMqttClient()
    {
        client = new MqttClient(brokerAddress, brokerPort, false, null, null, MqttSslProtocols.None);
        string clientId = System.Guid.NewGuid().ToString();
        client.Connect(clientId);

        if (client.IsConnected)
        {
            Debug.Log("Connected to MQTT broker.");
            client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            client.MqttMsgPublishReceived += OnMqttMessageReceived;
        }
        else
        {
            Debug.LogError("Failed to connect to MQTT broker.");
        }
    }

    private void OnMqttMessageReceived(object sender, MqttMsgPublishEventArgs e)
    {
        string message = System.Text.Encoding.UTF8.GetString(e.Message);
        var payload = JsonConvert.DeserializeObject<VehicleData>(message);
        Debug.Log($"Received message: {message}");
        unityContext.Post(_ => ProcessVehicleData(payload), null);
    }

    private void ProcessVehicleData(VehicleData payload)
    {
        UpdateLights(payload.LightsOn);
        UpdateDoor(payload.DriverDoorOpen, "Door_Open", "open_door", "close_door");
        UpdateHood(payload.HoodOpen, "Hood_Open", "open_hood", "close_hood");
    }

    private void UpdateLights(bool lightsOn)
    {
        if (lightsOn && !FrontLights.activeSelf)
        {
            PlayEngineSound(EngineStart, false);
            Invoke(nameof(PlayEngineIdleSound), EngineStart.length);
            FrontLights.SetActive(true);
            TailLights.SetActive(true);
            StartVibration();
        }
        else if (!lightsOn && FrontLights.activeSelf)
        {
            PlayEngineSound(EngineStop, false);
            FrontLights.SetActive(false);
            TailLights.SetActive(false);
            StopVibration();
        }
    }

    private void UpdateDoor(bool doorOpen, string animatorBool, string openTrigger, string closeTrigger)
    {
        if (doorOpen && !SportCar.GetBool(animatorBool))
        {
            SportCar.SetTrigger(openTrigger);
            SportCar.SetBool(animatorBool, true);
        }
        else if (!doorOpen && SportCar.GetBool(animatorBool))
        {
            SportCar.SetTrigger(closeTrigger);
            SportCar.SetBool(animatorBool, false);
        }
    }

    private void UpdateHood(bool hoodOpen, string animatorBool, string openTrigger, string closeTrigger)
    {
        UpdateDoor(hoodOpen, animatorBool, openTrigger, closeTrigger);
    }

    private void PlayEngineSound(AudioClip clip, bool loop)
    {
        EngineSound.clip = clip;
        EngineSound.loop = loop;
        EngineSound.Play();
    }

    private void PlayEngineIdleSound()
    {
        if (FrontLights.activeSelf)
        {
            PlayEngineSound(EngineIdle, true);
        }
    }

    private void StartVibration()
    {
        if (carVibrationCoroutine == null)
        {
            carVibrationCoroutine = StartCoroutine(VibrateCar());
        }
    }

    private void StopVibration()
    {
        if (carVibrationCoroutine != null)
        {
            StopCoroutine(carVibrationCoroutine);
            carVibrationCoroutine = null;
        }
    }

    private IEnumerator VibrateCar()
    {
        Vector3 originalPosition = SportCarVibration.transform.position;
        float vibrationIntensity = 0.009f;

        while (true)
        {
            SportCarVibration.transform.position = originalPosition + new Vector3(
                UnityEngine.Random.Range(-vibrationIntensity, vibrationIntensity),
                UnityEngine.Random.Range(-vibrationIntensity, vibrationIntensity),
                UnityEngine.Random.Range(-vibrationIntensity, vibrationIntensity)
            );

            yield return new WaitForSeconds(0.07f);
        }
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
        public bool LightsOn;
        public bool DriverDoorOpen;
        public bool HoodOpen;
    }
}
