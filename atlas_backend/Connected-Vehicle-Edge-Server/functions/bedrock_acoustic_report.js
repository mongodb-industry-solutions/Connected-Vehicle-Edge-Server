

exports = async function(changeEvent){
  // This default function will get a value and find a document in MongoDB
  // To see plenty more examples of what you can do with functions see: 
  // https://www.mongodb.com/docs/atlas/app-services/functions/
  
  const {
    BedrockRuntimeClient,
    InvokeModelCommand,
  } = require('@aws-sdk/client-bedrock-runtime');
  
  const text_decoding = require('text-decoding');
  
  var config = ({
    region: "eu-central-1",
    credentials: {
      accessKeyId: context.values.get(`AWS_ACCESS_KEY`),
      secretAccessKey: context.values.get(`AWS_ACCESS_SECRET_VALUE`),
    }
  });
  
  const client = new BedrockRuntimeClient(config);
  latest_status = changeEvent.fullDocument.results[0].audio
  //let latest_status = "Harda Material Hit"
  let abnormal_keyword = ""
  if (latest_status == "Soft Material Hit" || latest_status == "Metallic Hit"){
    abnormal_keyword = "Abnormal"
  } 
  else {
    console.log("no report")
    return
  }
//   const prompt = `Engine Acoustic-Based Status: "Soft Material Hit"
// Room Temperature: 25 Degrees
// RPM: 1300

// Create a comprehensive status report for this engine.
//   `;

  const serviceName = "mongodb-atlas";
  const vehicle_data_DB = "Connected-Vehicle-Edge-Server";
  const coll_name = "vehicle_data";
  const vehicle_data_coll = context.services.get(serviceName).db(vehicle_data_DB).collection("vehicle_data");
  
 const query = { Driver_id: "6584053032d5b2616b7b635c" };

    // Define the projection to get only Battery_Temp and Battery_Current
  // const options = {
  //     projection: { _id: 0, Battery_Temp: 1, Battery_Current: 1 },
  //   };
  
  const batteryData = await vehicle_data_coll.findOne(query);
  
  
  const input = {
   "modelId": "amazon.titan-text-express-v1",
   "contentType": "application/json",
   "accept": "application/json",
   "body": `{\"inputText\":\"Engine Acoustic-Based Status: ${abnormal_keyword} ${latest_status}, Battery Temperature: ${batteryData.Battery_Temp} Degrees, Battery Percentage: ${batteryData.Battery_Current}, Create a comprehensive status report for this engine based on a 4-cilinder engnine. Start with the report here:\",\"textGenerationConfig\":{\"maxTokenCount\":8192,\"stopSequences\":[],\"temperature\":0,\"topP\":1}}`
  }


  // console.log(input)
  
  const command = new InvokeModelCommand(input);
  
  let data, completions;
  
  try {
    data = await client.send(command);
    
    // console.log(JSON.stringify(new text_decoding.TextDecoder().decode(data.body)));
    // console.log(JSON.parse(new text_decoding.TextDecoder().decode(data.body)));
    
    response = JSON.parse(new text_decoding.TextDecoder().decode(data.body));
    
    
    // console.log(completions);
    const output_text = response.results[0].outputText
    
        const timestamped_output = `${new Date().toISOString()}: ${output_text}`; // Prepend timestamp

    console.log(timestamped_output);
    
    const local_dashboard_response = await context.http.post({
      url: "<Put Here Your NGrok URL>",
      body: { msg: timestamped_output },
      encodeBodyAsJSON: true
    })
    
  } catch (error) {
    console.error(error);
  }
  
  
    // // The response body is a BSON.Binary object. Parse it and return.
    // return EJSON.parse(local_dashboard_response.body.text());
  
  return;

  // // Find the name of the MongoDB service you want to use (see "Linked Data Sources" tab)
  // var serviceName = "mongodb-atlas";

  // // Update these to reflect your db/collection
  // var dbName = "db_name";
  // var collName = "coll_name";

  // // Get a collection from the context
  // var collection = context.services.get(serviceName).db(dbName).collection(collName);

  // var findResult;
  // try {
  //   // Get a value from the context (see "Values" tab)
  //   // Update this to reflect your value's name.
  //   var valueName = "value_name";
  //   var value = context.values.get(valueName);

  //   // Execute a FindOne in MongoDB 
  //   findResult = await collection.findOne(
  //     { owner_id: context.user.id, "fieldName": value, "argField": arg},
  //   );

  // } catch(err) {
  //   console.log("Error occurred while executing findOne:", err.message);

  //   return { error: err.message };
  // }

  // // To call other named functions:
  // // var result = context.functions.execute("function_name", arg1, arg2);

  // return { result: findResult };
};