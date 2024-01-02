using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;
using Realms.Sync.Exceptions;
using MongoDB.Bson;


public class Animations : MonoBehaviour
{
    private Realm realm;
    private IDisposable notificationToken;
    public  Animator SportCar;

    public GameObject FrontLights;

    public GameObject TailLights;

    public AudioSource EngineSound;
    public AudioClip EngineStart, EngineIdle, EngineStop;

    public GameObject SportCarVibration;
    private Coroutine carVibrationCoroutine;
    
    private async void Start()
    {
        
        
        if (RealmManager.Instance.RealmInstance != null)
        {
            // If Realm is already initialized
            SubscribeToChanges(RealmManager.Instance.RealmInstance);
        }
        else
        {
            // Wait for Realm to be initialized
            RealmManager.Instance.OnRealmReady += OnRealmReady;
        }
    }
    private void OnRealmReady()
    {
        SubscribeToChanges(RealmManager.Instance.RealmInstance);
        // Unsubscribe from the event to avoid potential memory leaks
        RealmManager.Instance.OnRealmReady -= OnRealmReady;
    }
    private void SubscribeToChanges(Realm realm)
    {


        if (realm == null)
        {
            Debug.LogError("Realm is not initialized.");
            return;
        }

        var query = realm.All<vehicle_data>();

        notificationToken = query.SubscribeForNotifications((sender, changes) =>
        {
    
            if (changes == null)
            {
                // This is the initial notification, sender contains all objects
                Debug.Log($"Initial data: {sender.Count} items");
            }
            else
            {
                // Query results have changed
                Debug.Log($"Insertions: {changes.InsertedIndices.Length}");
                Debug.Log($"Deletions: {changes.DeletedIndices.Length}");
                Debug.Log($"Modifications: {changes.ModifiedIndices.Length}");
                
                foreach (var index in changes.ModifiedIndices)
                {
                    var modifiedObject = sender[index];
                    // Ligths Modifications
                    if(modifiedObject.LightsOn==true && FrontLights.activeSelf==false)
                    {
                        EngineSound.clip = EngineStart;
                        EngineSound.loop = false;
                        EngineSound.Play();
                        Invoke("EngineIdleSound", EngineSound.clip.length);
                        FrontLights.SetActive(true);
                        TailLights.SetActive(true);
                        StartVibration();
                        if (modifiedObject.BatteryCurrent == 0){
                            realm.Write(() =>
                            {
                                modifiedObject.LightsOn = false;
                            });
                        }
                    }
                    else if(modifiedObject.LightsOn==false && FrontLights.activeSelf==true){

                        EngineSound.clip = EngineStop;
                        EngineSound.loop = false;
                        EngineSound.Play();
                        FrontLights.SetActive(false);
                        TailLights.SetActive(false);
                        StopVibration();
                    }

                    // Open Door Modifications
                    if(modifiedObject.DriverDoorOpen==true && SportCar.GetBool("Door_Open")==false)
                    {
                        SportCar.SetTrigger("open_door");
                        SportCar.SetBool("Door_Open", true);
                    }
                    else if(modifiedObject.DriverDoorOpen==false && SportCar.GetBool("Door_Open")==true){
                        SportCar.SetTrigger("close_door");
                        SportCar.SetBool("Door_Open", false);
                    }

                    // Open Door Modifications
                    if(modifiedObject.HoodOpen==true && SportCar.GetBool("Hood_Open")==false)
                    {
                        SportCar.SetTrigger("open_hood");
                        SportCar.SetBool("Hood_Open", true);
                    }
                    else if(modifiedObject.HoodOpen==false && SportCar.GetBool("Hood_Open")==true){
                        SportCar.SetTrigger("close_hood");
                        SportCar.SetBool("Hood_Open", false);
                    }

                    // Print or process the modified object
                    Debug.Log($"Modified object: {modifiedObject}");
                }
            }
        });
    }

    void EngineIdleSound()
    {
        if(FrontLights.activeSelf)
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
        float vibrationIntensity = 0.009f; // You can adjust this value for more or less vibration

        while (true)
        {
            // Simulate gentle vibration by small random position adjustments
            SportCarVibration.transform.position = originalPosition + new Vector3(
                UnityEngine.Random.Range(-vibrationIntensity, vibrationIntensity),
                UnityEngine.Random.Range(-vibrationIntensity, vibrationIntensity),
                UnityEngine.Random.Range(-vibrationIntensity, vibrationIntensity)
            );

            // Wait for a short period of time before the next vibration
            yield return new WaitForSeconds(0.07f); // Adjust the time for faster or slower vibration
        }
    }

    
}