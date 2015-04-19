
#r "C:/Users/jamie/Desktop/4Gone.DriveSafe.Analytics/packages/MongoDB.Driver.2.0.0/lib/net45/MongoDB.Driver.dll"
#r "C:/Users/jamie/Desktop/4Gone.DriveSafe.Analytics/packages/MongoDB.Driver.Core.2.0.0/lib/net45/MongoDB.Driver.Core.dll"
#r "C:/Users/jamie/Desktop/4Gone.DriveSafe.Analytics/packages/MongoDB.Bson.2.0.0/lib/net45/MongoDB.Bson.dll"

open System

type DriverPosition = {
    DriverId: Guid;
    Latitude : float; 
    Longitude: float; 
    Altitude: float; 
    Accuracy: float; 
    AltitudeAccuracy: float;
    Heading: float;
    Speed: float;
    TimeStamp: DateTime;
    }

open MongoDB.Driver
open MongoDB.Bson

let connectionString = "mongodb://bhuser:Forgone1!@ds061621.mongolab.com:61621/battlehackraleigh"
let client = MongoDB.Driver.MongoClient(connectionString)
let database = client.GetDatabase("battlehackraleigh");

//Insert
//let collection = database.GetCollection<DriverPosition>("driverpositions");
//let driverPosition1 = { DriverId=Guid.Parse("03DE3F8D-ABDD-4124-ACC1-A32781EADE54"); 
//                       Latitude= 35.828959; Longitude= -78.895663;
//                        Altitude=0.; Accuracy=1.;
//                        AltitudeAccuracy=1.;Heading=1.;
//                        Speed=53.; TimeStamp=new DateTime(2015, 4, 18, 8, 35, 16, 0)}
//collection.InsertOneAsync(driverPosition1)

//Get
type DriverPosition' = {
    _id: BsonType;
    DriverId: Guid;
    Latitude : float; 
    Longitude: float; 
    Altitude: float; 
    Accuracy: float; 
    AltitudeAccuracy: float;
    Heading: float;
    Speed: float;
    TimeStamp: DateTime;
    }

let collection' = database.GetCollection<DriverPosition'>("driverpositions");
let get = collection'.Find(fun x -> x.DriverId  = Guid.Parse("03DE3F8D-ABDD-4124-ACC1-A32781EADE54")).ToListAsync()
get.Result |> Seq.head


