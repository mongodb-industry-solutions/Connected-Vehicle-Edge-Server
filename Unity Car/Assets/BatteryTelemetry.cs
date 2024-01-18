using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using MongoDB.Bson;

public class BatteryTelemetry : MonoBehaviour
{
    private vehicle_data vehicleData;
    private bool reduceBatteryActive = false;
    private void Start()
    {
        if (RealmManager.Instance.RealmInstance != null)
        {
            // If Realm is already initialized
            InitializeBattery(RealmManager.Instance.RealmInstance);
            StartCoroutine(ReduceBattery(RealmManager.Instance.RealmInstance));
        }
        else
        {
            // Wait for Realm to be initialized
            RealmManager.Instance.OnRealmReady += OnRealmReady;
        }
    }
    private void OnRealmReady()
    {
        InitializeBattery(RealmManager.Instance.RealmInstance);
        StartCoroutine(ReduceBattery(RealmManager.Instance.RealmInstance));
        // Unsubscribe from the event to avoid potential memory leaks
        RealmManager.Instance.OnRealmReady -= OnRealmReady;
    }

    private void InitializeBattery(Realm realm)
    {
        var objectId = new ObjectId("658876fde27a68ff985cdb4d"); 
        vehicleData = realm.Find<vehicle_data>(objectId);

        if (vehicleData == null)
        {
            Debug.LogError("vehicle_data object not found.");
            return;
        }

        realm.Write(() =>
        {
            vehicleData.BatteryCurrent = 100;
            vehicleData.BatteryTemp = 28;
        });

    }

    public IEnumerator ReduceBattery(Realm realm)
    {
        // Check if vehicleData is not null
        if (vehicleData == null)
        {
            Debug.LogError("vehicle_data is null.");
            yield break; // Stop the coroutine
        }

        reduceBatteryActive = true;
        while (vehicleData.BatteryCurrent > 0 && reduceBatteryActive)
        {
            yield return new WaitForSeconds(2);
            if (vehicleData.LightsOn)
            {
                realm.Write(() =>
                {
                    vehicleData.BatteryCurrent = Math.Max(vehicleData.BatteryCurrent.Value - UnityEngine.Random.Range(0, 15), 0);
                    vehicleData.BatteryTemp = vehicleData.BatteryTemp.Value + UnityEngine.Random.Range(-2, 3);
                    if (vehicleData.BatteryCurrent == 0)
                    {
                        vehicleData.LightsOn = false;
                        vehicleData.BatteryStatusOK = false;
                    }
                });
            }
            if (!reduceBatteryActive)
            {
                yield break;
            }
        }
        reduceBatteryActive = false;
    }

    public void RestartReduceBattery()
    {
        if (vehicleData != null && !reduceBatteryActive)
        {
            StartCoroutine(ReduceBattery(RealmManager.Instance.RealmInstance));
        }
    }
}