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

    
    
    private async void Start()
    {
        
        var realmApp = App.Create(new AppConfiguration(Constants.Realm.AppId)
        {
            BaseUri = new Uri(Constants.Realm.baseURL),
        });
        var syncUser = await realmApp.LogInAsync(Credentials.EmailPassword(Constants.Realm.UserName, Constants.Realm.Password));
        var config = new FlexibleSyncConfiguration(syncUser)
        {
            PopulateInitialSubscriptions = (realm) =>
            {
                var VehicleData = realm.All<vehicle_data>();
                realm.Subscriptions.Add(VehicleData, new SubscriptionOptions { Name = "VehicleData" });
            }
        };
        // Console.WriteLine(realm.Config.DatabasePath);
        try
        {
            realm = await Realm.GetInstanceAsync(config);
        }
        catch (Exception ex)
        {
            Debug.LogError($@"Error creating or opening the realm file. {ex.Message}");
            return;
        }

        SubscribeToChanges();

        // StartCoroutine(ModifyVehicleDataAfterDelay(2));

    }
    private void SubscribeToChanges()
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
                    if(modifiedObject.LightsOn==true)
                    {
                        FrontLights.SetActive(true);
                        TailLights.SetActive(true);
                    }
                    else if(modifiedObject.LightsOn==false){
                        FrontLights.SetActive(false);
                        TailLights.SetActive(false);
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

    // private IEnumerator ModifyVehicleDataAfterDelay(float delay)
    // {
    //     // Wait for the specified delay
    //     yield return new WaitForSeconds(delay);

    //     // Modify a vehicle_data object inside a write transaction
    //     realm.Write(() =>
    //     {
    //         // Convert the string to ObjectId
    //         var objectId = new ObjectId("658876fde27a68ff985cdb4d");  // Replace "some_id" with the actual ObjectId string

    //         // Find the vehicle_data object using ObjectId or create a new one if none exists
    //         var vehicle = realm.Find<vehicle_data>(objectId);

    //         // Modify properties of the vehicle_data object
    //         vehicle.LightsOn = false; // Example modification
    //     });

    //     Debug.Log("Vehicle data modified after delay.");
    // }


//     private void OnCollectionChanged(IRealmCollection<vehicle_data> collection, ChangeSet changes)
//     {
//     realm.SubscribeForNotifications(OnCollectionChanged);
//         // if (error != null)
//         // {
//         //     Debug.LogError("Error occurred: " + error.Message);
//         //     return;
//         // }

//         if (changes != null)
//         {
//             // Iterate through the inserted documents
//             foreach (var insertIndex in changes.InsertedIndices)
//             {
//                 var vehicle_data_doc = collection[insertIndex];
//                 Debug.Log("New document inserted: " + vehicle_data_doc);
//                 if(sensor_doc.Topic=="i/bme680")
//                 {
//                     // Temperature = sensor_doc.T ?? 22;;
//                     // Pressure = sensor_doc.P ?? 1080;;
//                     // Humidity = sensor_doc.H ?? 30;;
//                     // AirQuality = sensor_doc.Iaq ?? 150;;
//                 }
//                 else if(sensor_doc.Topic=="i/ldr"){
//                     RoomBrigthness = sensor_doc.Br;
//                 }
//                 // Debug.Log(newMessage);
// //                 SensorText.text = $@"Temperature [°C]: {Temperature}
// // Room Brightness [%]: {RoomBrigthness}
// // Air Pressure [hPa]: {Pressure}
// // Humidity [%]: {Humidity}
// // Air Quality Index [0-500]: {AirQuality}";
//                 Debug.Log("Running again...");
//                 // Debug.Log(sensor_doc);
//             }
//         }
    // }
}