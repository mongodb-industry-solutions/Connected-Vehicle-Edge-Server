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

    private async void Start()
    {
        unityContext = SynchronizationContext.Current;

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
        unityContext.Post(_ => ProcessUpdate(payload), null);
    }

    private void ProcessUpdate(VehicleData payload)
    {
        if (payload.LightsOn && !FrontLights.activeSelf)
        {
            EngineSound.clip = EngineStart;
            EngineSound.loop = false;
            EngineSound.Play();
            Invoke("EngineIdleSound", EngineSound.clip.length);
            FrontLights.SetActive(true);
            TailLights.SetActive(true);
            StartVibration();
        }
        else if (!payload.LightsOn && FrontLights.activeSelf)
        {
            EngineSound.clip = EngineStop;
            EngineSound.loop = false;
            EngineSound.Play();
            FrontLights.SetActive(false);
            TailLights.SetActive(false);
            StopVibration();
        }

        if (payload.DriverDoorOpen && !SportCar.GetBool("Door_Open"))
        {
            SportCar.SetTrigger("open_door");
            SportCar.SetBool("Door_Open", true);
        }
        else if (!payload.DriverDoorOpen && SportCar.GetBool("Door_Open"))
        {
            SportCar.SetTrigger("close_door");
            SportCar.SetBool("Door_Open", false);
        }

        if (payload.HoodOpen && !SportCar.GetBool("Hood_Open"))
        {
            SportCar.SetTrigger("open_hood");
            SportCar.SetBool("Hood_Open", true);
        }
        else if (!payload.HoodOpen && SportCar.GetBool("Hood_Open"))
        {
            SportCar.SetTrigger("close_hood");
            SportCar.SetBool("Hood_Open", false);
        }
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
        if (carVibrationCoroutine == null)
        {
            carVibrationCoroutine = StartCoroutine(VibrateCar());
        }
    }

    void StopVibration()
    {
        if (carVibrationCoroutine != null)
        {
            StopCoroutine(carVibrationCoroutine);
            carVibrationCoroutine = null;
        }
    }

    IEnumerator VibrateCar()
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

    void OnDestroy()
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
