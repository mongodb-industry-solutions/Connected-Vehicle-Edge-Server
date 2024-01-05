//
//  VehiclesView.swift
//  Vehicle App
//
//  Created by Arnaldo Vera on 24/12/23.
//

import SwiftUI
import RealmSwift

struct VehiclesView: View {
    // This view opens a synced realm.
    // We've injected a `flexibleSyncConfiguration` as an environment value,
    // so `@AsyncOpen` here opens a realm using that configuration.
    @AsyncOpen(appId: nil,
               timeout: 4000 ) var asyncOpen


    var body: some View {
        // Because we are setting the `ownerId` to the `user.id`, we need
        // access to the app's current user in this view.
        //let user = app?.currentUser

        switch asyncOpen {
            // Starting the Realm.asyncOpen process.
            // Show a progress view.
        case .connecting:
            ProgressView()
            // Waiting for a user to be logged in before executing
            // Realm.asyncOpen.
        case .waitingForUser:
            ProgressView("Waiting for user to log in...")
            // The realm has been opened and is ready for use.
            // Show the content view.
        case .open(let realm):
            VehiclesListView(realm: realm)
            // The realm is currently being downloaded from the server.
            // Show a progress view.
        case .progress(let progress):
            ProgressView(progress)
            // Opening the Realm failed.
            // Show an error view.
        case .error(let error):
            ErrorView(error: error)
        }
    }
}
struct ErrorView: View {
    var error: Error
    var body: some View {
        VStack {
            Text("Error opening the realm: \(error.localizedDescription)")
        }
    }
}


struct VehiclesListView: View {
    var realm: Realm
    @ObservedResults(vehicle_data.self) var vehicles
    var body: some View {
        NavigationView {
            VStack{
                // The list shows the items in the realm.
                List {
                    ForEach(vehicles) { vehicle in
                        NavigationLink(vehicle.Vehicle_Name ?? "My Car", destination: VehicleDetailView(vehicle: vehicle, realm: realm))
                        // + " " + vehicle.VehicleIdentification.Brand + " " + vehicle.VehicleIdentification.Model
                    }
                        .onDelete(perform: $vehicles.remove)
                }
            }
            .navigationTitle("Vehicles")
            .toolbar {
                ToolbarItem(placement: .primaryAction) {
                    Button("Logout", action: logout)
                }
            }
        }
        .navigationViewStyle(.stack)
    }
    
    func logout() {
        guard let user = app!.currentUser else {
            return
        }
        user.logOut() { error in
            // Other views are observing the app and will detect
            // that the currentUser has changed. Nothing more to do here.
            print("Logged out")
        }
    }
}
