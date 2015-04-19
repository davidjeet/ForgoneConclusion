namespace Data.Analytics

open System
open Data.Model
open MongoDB.Driver
open MongoDB.Bson
open MongoDB.Driver.Linq
open System.Linq

type MongoDataProvider() = 
    member this.GetLatestDriverData(driverId) = 
        let connectionString = "mongodb://bhuser:Forgone1!@ds061621.mongolab.com:61621/battlehackraleigh"
        let client = MongoDB.Driver.MongoClient(connectionString)
        let server = client.GetServer()
        let database = server.GetDatabase("battlehackraleigh");
        let collection = database.GetCollection<DriverPosition>("driverpositions");
        let collection' = collection.AsQueryable()
        let records = collection'.Where(fun x -> x.DriverId  = driverId)
        records |> Seq.head

    member this.GetCustomerData(customerId)=
        let connectionString = "mongodb://bhuser:Forgone1!@ds061621.mongolab.com:61621/battlehackraleigh"
        let client = MongoDB.Driver.MongoClient(connectionString)
        let server = client.GetServer()
        let database = server.GetDatabase("battlehackraleigh");
        let collection = database.GetCollection<Customer>("customers");
        let collection' = collection.AsQueryable()
        let records = collection'.Where(fun x -> x.Id  = customerId)
        records |> Seq.head

    member this.GetCustomerDataFromDriverId(driverId)=
        let connectionString = "mongodb://bhuser:Forgone1!@ds061621.mongolab.com:61621/battlehackraleigh"
        let client = MongoDB.Driver.MongoClient(connectionString)
        let server = client.GetServer()
        let database = server.GetDatabase("battlehackraleigh");
        let collection = database.GetCollection<Customer>("customers");
        let collection' = collection.AsQueryable()
        let records = collection'.Where(fun x -> x.Number  = driverId)
        records |> Seq.head


