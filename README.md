# Connected Vehicle with Edge Server
The automotive and transportation industries are going through a significant transformation.

This transformation is the shift to software-focused vehicles. This is known as **Software Defined Vehicles**. 

Thanks to being able to realiably ship new updates to software on the vehicles, this transformation will enable innovative customer experiences, increase security, make more efficient transportation and open new business models. 

However, creating a state-of-the-art connected vehicle platform requires a high quality foundation.
In this demonstration, we will showcase a connected vehicle utilizing MongoDB Edge Server, the Atlas Device SDKs (previously known as Realm), and Device Sync. 

MongoDB and its Device SDKs serve as a comprehensive data layer, facilitating effective two-way data transfer and maintaining consistency across ECUs, DCUs, HCPs, mobile devices, and cloud systems. Allowing you to focus on value-generating work such as enhancing the dirving experience, gaining value out of the data or produce the right recommendations.

[ARCHITECTURE IMAGE HERE]

# Set up instructions
## Part 1 - MongoDB Atlas Backend
# MongoDB Atlas Backend

In order to the make the demo work end-to-end, you will need to set up the backend. Let's get started! 

## Setup the MongoDB Atlas Backend

1. Create a [MongoDB Cloud](https://cloud.mongodb.com/) user account and ensure that you have access to an organization/project. 
2. Under the Data Services tab, click on Database in the sidedar, then "+ Create" and [create a free MongoDB cluster](https://www.mongodb.com/docs/atlas/tutorial/create-new-cluster/) in your preferred region and call it ```Connected-Vehicle-DB```. <br>You can choose a Free Tier (Shared), Serverless, or Dedicated cluster.

## Setup App Services and create an App
You can also follow the instructions on [this page](https://www.mongodb.com/docs/atlas/app-services/apps/create/#create-an-app-services-app) and create an app from the template 'Real-time Sync'. However, here are also the steps to follow:
1. In the Atlas UI Project dashboard, click the **App Services** tab.
2. Click **Create App from Template** and select ***Real-time Sync***.
    - Link your Data Source. Select the option 'Use an existing MongoDB Atlas Data Source' and select the cluster you created previously.
    - Give it a Name
    - Select a Deployment Model (default options are usually fine to start)
3.  Click **Create App Service**.
    
    | If any pop-ups appear, you can close them. You have all you need in the instructions of this repo. 
4. Create a demo user by clicking on **App Users** in the sidedar, then **Add New User**. 
    - As Email Address write: 'demo'
    - As Password write: 'demopw'
    
    | These values are the ones used in this repository and will enable you to use this demo quicker. But feel free to use any email/password combination! Just be aware you would need to edit some in this repo to adjust to the changes.

<br><br>



Congrats! The first part is done. Now you'll continue with configuring / running the vehicle simulator ["Part 2: Set up the Typescript Vehicle Simulator"]().



## Part 2 - Edge Server
# Edge Server

Edge Server is a "local" server that sits between your client devices and MongoDB Atlas App Services. 

## Get Access to Edge Server Private Preview

At the time of writing this documentation, Edge Server is in Private Preview. 

You can do this step and follow the rest of the instructions in the meantime. 

If you are a MongoDB customer, contact your Product or Account Representative to enable this step. 
1. Go to the [Atlas Edge Server](https://www.mongodb.com/products/platform/atlas-edge-server) page and Request Access to the Private Preview by filling the form. 

2. When contacted, you will have to give your [App Services App ID](https://www.mongodb.com/docs/atlas/app-services/apps/metadata/#std-label-find-app-id) to enable Edge Server and generate an authorization secret for your App.


## Install Edge Server

1. [Get Edge Server Code](https://www.mongodb.com/docs/atlas/app-services/edge-server/configure/#get-the-edge-server-code)
2. Once Edge Server folder is unzipped, open and edit the `config.json` file as follows:
    ```json
    {
    "clientAppId": "YOUR-APP-ID",
    "query": "*",
    "cloudSyncServerAuthSecret": "YOUR-AUTH-SECRET",
    "hostname": "localhost:80",
    "tls" : {
        "enabled": false,
        "certificates": [
        {
            "publicKeyPath": "certs/cert.pem",
            "privateKeyPath": "certs/certkey.pem"
        }
        ]
    }
    }
    ```
    - In `"clientAppId": "YOUR-APP-ID"` set your your [App Services App ID](https://www.mongodb.com/docs/atlas/app-services/apps/metadata/#std-label-find-app-id)
    - In `"cloudSyncServerAuthSecret": "YOUR-AUTH-SECRET"` set the auth token that you should have received in the previous step. If you don't have it yet, continue the tutorial and come back to edit this file later. This is the only place where you would need the secret.
    - In `"hostname": "localhost:80",`. We have set up local host 80. Feel free to pick any other host name.
3. [Install Edge Server Dependencies](https://www.mongodb.com/docs/atlas/app-services/edge-server/configure/#install-dependencies)


Congrats!! You have completed Step 2 of this demo. Go to step 3 to continue. 


## Part 3 - Set Up Unity
# Unity

make sure unity version is 2022.3.13f1 or higher
```
sealed class Constants
{
    public sealed class Realm
    {
        public const string AppId = ">>YOUR-REALM-APP-ID<<";
        public const string baseURL = "http://localhost:80";
        public const string UserName = ">>YOUR-REALM-USER-NAME<<";
        public const string Password = ">>YOUR-REALM-PASSWORD<<";
        public static bool flag = false;
    }
}
```


## Part 4 - Set Up the iOS Swift Apps
# iOS Swift Apps



```
APP_ID = >>YOUR-APP-ID<<
USER = >>YOUR-USER<<
PASSWORD = >>YOUR-PASSWORD<<
```

