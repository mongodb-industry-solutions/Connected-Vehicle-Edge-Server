//
//  VehicleDetailView.swift
//  Vehicle App
//
//  Created by Arnaldo Vera on 24/12/23.
//

import SwiftUI
import RealmSwift


struct VehicleDetailView: View {
    @ObservedRealmObject var vehicle: vehicle_data
    @State private var showingCommandView = false
    
    var body: some View {
        NavigationView {
            Form {
                // Section(header: Text("Attributes")) {
                //     HStack {
                //         Text("VIN")
                //         Spacer()
                //         Text(vehicle._id)
                //     }
                //     // HStack {
                //     //     Text("Miscellaneous")
                //     //     Spacer()
                //     //     switch vehicle.mixedTypes {
                //     //     case .string(_):
                //     //         Text(vehicle.mixedTypes.stringValue ?? "")
                //     //     case .bool(_):
                //     //         Text(String(vehicle.mixedTypes.boolValue!))
                //     //     case .double(_):
                //     //         Text(String(vehicle.mixedTypes.doubleValue!))
                //     //     case .float(_):
                //     //         Text(String(vehicle.mixedTypes.floatValue!))
                //     //     case .int(_):
                //     //         Text(String(vehicle.mixedTypes.intValue!))
                //     //     case .date(_):
                //     //         if #available(iOS 15.0, *) {
                //     //             Text(vehicle.mixedTypes.dateValue?.ISO8601Format() ?? "")
                //     //         } else {
                //     //             // Fallback on earlier versions
                //     //         }
                //     //     default:
                //     //         Text("\(vehicle.mixedTypes.stringValue ?? "other")")
                //     //     }
                //     // }
                // }
                Section(header: Text("CONTROLS")) {
                    Toggle(isOn: $vehicle.LightsOn) {
                        Text("Car On")
                    }
                    Toggle(isOn: $vehicle.Driver_Door_Open) {
                        Text("Open Driver Door")
                    }
                    Toggle(isOn: $vehicle.Hood_Open) {
                        Text("Open Hood")
                    }
                }
                Section(header: Text("Battery")) {
                    HStack {
                        Text("Temperature")
                        Spacer()
                        Text(String(format: "%.1f °C", vehicle.Battery_Temp ?? 1.0))
                    }
                    HStack {
                        Text("Charge Limit")
                        Spacer()
                        Text(String(format: "%.0f %%", vehicle.Battery_Current ?? 1.0))
//                        Text("\(vehicle.Powertrain?.Battery?.SOC?.Current ?? 0)")
                    }
                    HStack {
                        Text("Status")
                        Spacer()
                        // This is not the most accurate in terms of real application MIL isn't related to battery status. But just for demo pursposes.
                        if (vehicle.Battery_Status_OK == true) {
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
                // // Section(header: Text("Commands: \(vehicle.commands.count)")) {
                // //     List {
                // //         ForEach(vehicle.commands) { cmd in
                // //             HStack {
                // //                 Text(cmd.command ?? "")
                // //                 Spacer()
                // //                 Text(cmd.status?.rawValue ?? "")
                // //             }
                // //         }
                // //     }
                // // }
                // // Section(header: Text("Components: \(vehicle.components.count)")) {
                // //     List {
                // //         ForEach(vehicle.components, id: \._id) { component in
                // //             HStack {
                // //                 Text(component.name ?? "")
                // //             }
                // //         }
                // //     }
                // // }
                Button(action: {showingCommandView = true}){
                    Text("Send Command").frame(maxWidth: .infinity, alignment: .center)
                }
            }
        }
        .navigationBarTitle("Connected to Vehicle")
        // .sheet(isPresented: $showingCommandView) {

        //     CommandView(vehicle: vehicle, isPresented: $showingCommandView)
        // }
    }
}

// struct CommandView: View {
//     @ObservedRealmObject var vehicle: vehicle
//     @Binding var isPresented: Bool
//     @State var key: String = ""
//     @State var value: String = ""
//     @State private var selectedCommand = "Reset Battery"
//     let commands = ["Reset Battery"]
    
//     var body: some View {
//         VStack() {
//             List {
//                 Picker("Commands", selection: $selectedCommand) {
//                     ForEach(commands, id: \.self) {
//                         Text($0)
//                     }
//                 }
//             }
//             HStack() {
//                 Button("Send", action: sendCommand)

//             }
//         }
//     }
    
//     func sendCommand(){
//         $vehicle.commands.append(Command(value: ["command": selectedCommand, "status": CmdStatus.submitted]))
//         isPresented = false

//     }
// }


struct DeviceDetailView_Previews: PreviewProvider {
    static var previews: some View {
        VehicleDetailView(vehicle: vehicle_data())
    }
}
