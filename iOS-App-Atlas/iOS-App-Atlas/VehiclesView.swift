//
//  VehiclesView.swift
//  Vehicle App
//
//  Created by Arnaldo Vera on 24/12/23.
//

import SwiftUI
import RealmSwift

struct VehiclesView: View {

    @State private var vehiclesList: [VehicleListItem] = []

    // This view opens a synced realm.
    // We've injected a `flexibleSyncConfiguration` as an environment value,
    // so `@AsyncOpen` here opens a realm using that configuration.
    @AsyncOpen(appId: nil, timeout: 4000 ) var asyncOpen

    var body: some View {
        // Because we are setting the `ownerId` to the `user.id`, we need
        // access to the app's current user in this view.
        //let user = app?.currentUser
        
        NavigationView{
            VStack(spacing:20){
                List {
                    ForEach(vehiclesList, id: \._id) { vehicle in
                        NavigationLink(destination: VehicleDetailView(vehicleId: vehicle.Driver_id)){
                            Text(vehicle.Vehicle_Name!)
                        }
                    }
                }
            }.padding().task{
                do{
                    vehiclesList = try await getVehicles()
                    print("vehiclesList", vehiclesList)
                } catch VehicleError.invalidUrl{
                    print("errorrr 0: invalidUrl")
                }catch VehicleError.invalidResponse{
                    print("errorrr 1: invalidResponse")
                }catch VehicleError.invalidData{
                    print("errorrr 1: invalidData")
                }catch{
                    print("errorrr 2: ", error)
                }
            }
        }

        // switch asyncOpen {
        //     // Starting the Realm.asyncOpen process.
        //     // Show a progress view.
        // case .connecting:
        //     ProgressView()
        //     // Waiting for a user to be logged in before executing
        //     // Realm.asyncOpen.
        // case .waitingForUser:
        //     ProgressView("Waiting for user to log in...")
        //     // The realm has been opened and is ready for use.
        //     // Show the content view.
        // case .open(let realm):
        //     VehiclesListView(realm: realm)
        //     // The realm is currently being downloaded from the server.
        //     // Show a progress view.
        // case .progress(let progress):
        //     ProgressView(progress)
        //     // Opening the Realm failed.
        //     // Show an error view.
        // case .error(let error):
        //     ErrorView(error: error)
        // }
    }
    
    func getVehicles() async throws -> [VehicleListItem] {
        let endpoint = "https://eu-west-1.aws.data.mongodb-api.com/app/connected-vehicle-edge-server-cbvdz/endpoint/vehicle_data"
        guard let url = URL(string: endpoint) else {throw VehicleError.invalidUrl}
        let (data, response) = try await URLSession.shared.data(from: url)
        guard let response = response as? HTTPURLResponse, response.statusCode == 200 else {
            throw VehicleError.invalidResponse
        }
        do {
            let decoder = JSONDecoder()
            //print("Decoder 1", String(data: data, encoding: .utf8) ?? "")
            //print("Decoder 2", try decoder.decode([Vehicle].self, from: data))
            return try decoder.decode([VehicleListItem].self, from: data)
        } catch{
            throw VehicleError.invalidData
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


// struct VehiclesListView: View {
//     //var realm: Realm
//     @ObservedResults(vehicle_data.self) var vehicles
//     var body: some View {
//         NavigationView {
//             VStack{
//                 // The list shows the items in the realm.
//                 List {
//                     ForEach(vehicles) { vehicle in
//                         NavigationLink(vehicle.Vehicle_Name ?? "My Car", destination: VehicleDetailView(vehicle: vehicle, realm: realm))
//                         // + " " + vehicle.VehicleIdentification.Brand + " " + vehicle.VehicleIdentification.Model
//                     }
//                         .onDelete(perform: $vehicles.remove)
//                 }
//             }
//             .navigationTitle("Vehicles")
//             .toolbar {
//                 ToolbarItem(placement: .primaryAction) {
//                     Button("Logout", action: logout)
//                 }
//             }
//         }
//         .navigationViewStyle(.stack)  
//     }
    
//     func logout() {
//         guard let user = app!.currentUser else {
//             return
//         }
//         user.logOut() { error in
//             // Other views are observing the app and will detect
//             // that the currentUser has changed. Nothing more to do here.
//             print("Logged out")
//         }
//     }
// }

struct VehicleListItem: Codable {
    let _id: String
    let Driver_id: String
    let Vehicle_Name: String?
}

struct Vehicle: Codable {
    let _id: String
    let Battery_Current: Double?
    let Battery_Status_OK: Bool?
    let Battery_Temp: Double?
    let Driver_id: String
    let LightsOn: Bool
    let Driver_Door_Open: Bool?
    let Hood_Open: Bool
    let Vehicle_Name: String?
    let Engine_Status: String?
}

enum VehicleError : Error{
    case invalidUrl
    case invalidResponse
    case invalidData
}
