using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using Realms;

public class ResetBattery : MonoBehaviour
{
    // public  GameObject ChargeBatteryButton;
    public void OnButtonClick(){
        var realm = RealmManager.Instance.RealmInstance;
        var objectId = new ObjectId("658876fde27a68ff985cdb4d"); 
        var vehicleData = realm.Find<vehicle_data>(objectId);

        if (vehicleData == null)
        {
            Debug.LogError("vehicle_data object not found.");
            return;
        }

        realm.Write(() =>
        {
            vehicleData.BatteryCurrent = 100;
            vehicleData.BatteryStatusOK = true;
        });
    }
}
