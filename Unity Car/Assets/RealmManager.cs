using UnityEngine;
using Realms;
using Realms.Sync;
using Realms.Sync.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;

public class RealmManager : MonoBehaviour
{
    public static RealmManager Instance { get; private set; }

    public Realm RealmInstance { get; private set; }
    public event Action OnRealmReady;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeRealm();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private async void InitializeRealm()
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

        try
        {
            RealmInstance = await Realm.GetInstanceAsync(config);
        }
        catch (Exception ex)
        {
            Debug.LogError($@"Error creating or opening the realm file. {ex.Message}");
        }
        OnRealmReady?.Invoke();
    }
}
