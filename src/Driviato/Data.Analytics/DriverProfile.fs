namespace Data.Analytics

open Data.Model

type ProfileProfile() = 
    member this.HandleData (driverId) = 
        let notification = new SendGridNotification() :> INotificaton
        let debitService = new BrainTreeDebitService() :> IDebitService
        let creditService = new VenmoCreditService() :> ICreditService
        let speedLimitProvider = new GoogleMapsSpeedLimitProvider() :> ISpeedLimitProvider
        let driverDataProvider = new MongoDriverDataProvider();
        let driverAnalysis = new DriverAnalysis()

        //TODO start here
        //let customer = 
        let brainTreeToken = "";

        let driverData = driverDataProvider.GetLatestDriverData(driverId)
        let speedLimit = float (speedLimitProvider.GetSpeedLimit(driverData.Latitude, driverData.Longitude))
        let analysis = driverAnalysis.WasDriverSpeeding(driverData.Speed,speedLimit)
        ()
//        match analysis with 
//        | true -> 
//            debitService.DebitAccount(driverData.DriverId.ToString(),brainTreeToken, 10.)
//            notification.SendEmail(driverData.)
//        ()
