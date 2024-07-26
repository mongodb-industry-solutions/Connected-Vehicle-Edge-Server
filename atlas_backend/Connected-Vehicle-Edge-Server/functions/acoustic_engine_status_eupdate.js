exports = async function(changeEvent) {
  // A Database Trigger will always call a function with a changeEvent.
  // Documentation on ChangeEvents: https://www.mongodb.com/docs/manual/reference/change-events

  // This sample function will listen for events and replicate them to a collection in a different Database

  // Access the _id of the changed document:

  // Get the MongoDB service you want to use (see "Linked Data Sources" tab)
  const serviceName = "mongodb-atlas";
  const vehicle_data_DB = "Connected-Vehicle-Edge-Server";
  const coll_name = "vehicle_data";
  const vehicle_data_coll = context.services.get(serviceName).db(vehicle_data_DB).collection("vehicle_data");
  // const vehicle_data_coll = context.services.get(serviceName).db(databaseName).collection(changeEvent.ns.coll);

  const filter = { Driver_id: "6584053032d5b2616b7b635c" };

  try {
    if (changeEvent.operationType === "insert") {
      // update the value of the 'Engine_Status'
      const updateDocument = {
         $set: {
            Engine_Status: changeEvent.fullDocument.results[0].audio,
         },
      };
      await vehicle_data_coll.updateOne(filter, updateDocument);
    }
    
  } catch(err) {
    console.log("error performing mongodb write: ", err.message);
  }
};
