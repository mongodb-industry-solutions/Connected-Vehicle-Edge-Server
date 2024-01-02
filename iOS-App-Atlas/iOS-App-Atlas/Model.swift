//
//  Model.swift
//  Vehicle App
//
//  Created by Arnaldo Vera on 24/12/23.
//

import Foundation
import RealmSwift

class vehicle_data: Object, ObjectKeyIdentifiable {
    @Persisted(primaryKey: true) var _id: ObjectId

    @Persisted var Battery_Current: Double?

    @Persisted var Battery_Status_OK: Bool?

    @Persisted var Battery_Temp: Double?

    @Persisted var Driver_id: String?

    @Persisted var LightsOn: Bool = false
    
    @Persisted var Driver_Door_Open: Bool = false
    
    @Persisted var Hood_Open: Bool = false

    @Persisted var Vehicle_Name: String?
}
