//
//  Vehicle_AppApp.swift
//  Vehicle App
//
//  Created by Arnaldo Vera on 23/12/23.
//

import SwiftUI
import RealmSwift
import Network

// SwiftUI App Lifecycle
// MongoDB Sample Code: https://www.mongodb.com/docs/realm/sdk/swift/swiftui-tutorial/#complete-code


//let app: RealmSwift.App? = RealmSwift.App(id: Bundle.main.object(forInfoDictionaryKey:"Atlas_App_ID") as! String);

let app: RealmSwift.App? = App(id: Bundle.main.object(forInfoDictionaryKey:"APP_ID") as! String, configuration: AppConfiguration(baseURL:"http://localhost:80", transport: nil, localAppName: nil, localAppVersion: nil));

//let app2: RealmSwift.App? = RealmSwift.App(id: Bundle.main.object(forInfoDictionaryKey:"Atlas_App_ID") as! String);

class NetworkMonitor: ObservableObject {
    private let networkMonitor = NWPathMonitor()
    private let workerQueue = DispatchQueue(label: "Monitor")
    var isConnected = false

    init() {
        networkMonitor.pathUpdateHandler = { path in
            self.isConnected = path.status == .satisfied
            Task {
                await MainActor.run {
                    self.objectWillChange.send()
                }
            }
        }
        networkMonitor.start(queue: workerQueue)
    }
}

@main
struct EasyApp: SwiftUI.App {
    @Environment(\.scenePhase) private var scenePhase
    @StateObject var networkMonitor = NetworkMonitor()
    
    var body: some Scene {
        WindowGroup {
            if let app = app {
                ContentView(app: app).environmentObject(networkMonitor)
            } else {
            }
        }
//        .onChange(of: scenePhase) { phase in
//            //print(phase)
//        }
    }
}

