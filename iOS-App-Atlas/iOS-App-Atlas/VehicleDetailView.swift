//
//  VehicleDetailView.swift
//  Vehicle App
//
//  Created by Arnaldo Vera on 24/12/23.
//

import SwiftUI
import RealmSwift
//import MongoKitten


struct VehicleDetailView: View {
    @EnvironmentObject var networkMonitor: NetworkMonitor
    @State private var showNetworkAlert = false
    
    //@ObservedRealmObject var vehicle: vehicle_data
    // var vehicle: Vehicle
    //var realm: Realm
    var vehicleId: String
    @State var vehicleDetail: Vehicle?
    @State private var showingCommandView = false
    @State private var observer: NSKeyValueObservation?
    @State var Hood_Open : Bool = true
    @State var LightsOn : Bool = true
    @State var Driver_Door_Open : Bool = true

    var body: some View {
        
        NavigationView {
            VStack(spacing:20){
                Form {
                    Section(header: Text("CONTROLS")) {
                         Toggle(isOn: $LightsOn) {
                             Text("Car On")
                         }
                         Toggle(isOn: $Driver_Door_Open) {
                             Text("Open Driver Door")
                        }
                        Toggle(isOn: $Hood_Open) {
                            Text("Open Hood")
                        }
                    }
                    Section(header: Text("Engine & Battery")) {
                        
                        HStack {
                            Text("Engine Status")
                            Spacer()
                            Text(vehicleDetail?.Engine_Status ?? "Engine Off")
                            //                        Text("\(vehicle.Powertrain?.Battery?.SOC?.Current ?? 0)")
                        }
                        HStack {
                            Text("Temperature")
                            Spacer()
                            Text(String(format: "%.1f °C", vehicleDetail?.Battery_Temp ?? 1.0))
                        }
                        HStack {
                            Text("Charge Limit")
                            Spacer()
                            Text(String(format: "%.0f %%", vehicleDetail?.Battery_Current ?? 1.0))
                            //                        Text("\(vehicle.Powertrain?.Battery?.SOC?.Current ?? 0)")
                        }
                        HStack {
                            Text("Battery Status")
                            Spacer()
                            // This is not the most accurate in terms of real application MIL isn't related to battery status. But just for demo pursposes.
                            if (vehicleDetail?.Battery_Status_OK == true) {
                                Image(systemName: "checkmark.circle.fill")
                                    .foregroundColor(.green)
                                    .imageScale(.large)
                                
                            } else {
                                Image(systemName: "exclamationmark.triangle.fill")
                                    .foregroundColor(.red)
                                    .imageScale(.large)
                            }
                        }
                    }
                    
                    Button(action: {showingCommandView = true}){
                        Text("Send Command").frame(maxWidth: .infinity, alignment: .center)
                    }
                }
            }.padding().task{
                do{
                    vehicleDetail = try await getVehicleDetail()
                    Hood_Open = vehicleDetail?.Hood_Open ?? true
                    LightsOn = vehicleDetail?.LightsOn ?? true
                    Driver_Door_Open = vehicleDetail?.Driver_Door_Open ?? true
                    print("vehicleDetail", vehicleDetail)
                } catch VehicleError.invalidUrl{
                    print("errorrr 0: invalidUrl")
                //}catch VehicleError.invalidResponse{
                //    print("errorrr 1: invalidResponse")
                }catch VehicleError.invalidData{
                    print("errorrr 1: invalidData")
                }catch{
                    print("errorrr 2: ", error)
                }
            }
        }
        .navigationBarTitle("Connected to Atlas")
        //.onChange(of: networkMonitor.isConnected) { connection in
        //    showNetworkAlert = connection == false
        //}
        .alert(
            "Network connection seems to be offline.",
            isPresented: $showNetworkAlert
        ) {}
    }
    
    func getVehicleDetail() async throws -> Vehicle {
        let endpoint = "https://eu-west-1.aws.data.mongodb-api.com/app/connected-vehicle-edge-server-cbvdz/endpoint/vehicle_data_details?arg1=" + vehicleId
        guard let url = URL(string: endpoint) else {throw VehicleError.invalidUrl}
        print("El vehiculo seleccionado es: ", endpoint)
        let (data, response) = try await URLSession.shared.data(from: url)
        guard let response = response as? HTTPURLResponse, response.statusCode == 200 else {
            throw VehicleError.invalidResponse
        }
        do {
            let decoder = JSONDecoder()
            //print("Decoder 1", String(data: data, encoding: .utf8) ?? "")
            //print("Decoder 2", try decoder.decode([Vehicle].self, from: data))
            return try decoder.decode(Vehicle.self, from: data)
        } catch{
            throw VehicleError.invalidData
        }
    }
}

// struct DeviceDetailView_Previews: PreviewProvider {
//     static var previews: some View {
//         //let realm = try! Realm()
//         var vehicle : Vehicle

//         VehicleDetailView(vehicle: vehicle)//vehicle_data(), realm: realm)
//     }
// }

