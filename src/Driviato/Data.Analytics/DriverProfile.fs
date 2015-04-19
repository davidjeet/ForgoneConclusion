namespace Data.Analytics

open Data.Model

type ProfileProfile() = 
    member this.HandleData (driverId) = 
        let notification = new SendGridNotification() :> INotificaton
        let debitService = new BrainTreeDebitService() :> IDebitService
        let creditService = new VenmoCreditService() :> ICreditService
        let speedLimitProvider = new GoogleMapsSpeedLimitProvider() :> ISpeedLimitProvider
        let dataProvider = new MongoDataProvider();
        let driverAnalysis = new DriverAnalysis()


        let brainTreeToken = "";

        let driverData = dataProvider.GetLatestDriverData(driverId)
        let speedLimit = float (speedLimitProvider.GetSpeedLimit(driverData.Latitude, driverData.Longitude))
        let analysis = driverAnalysis.WasDriverSpeeding(driverData.Speed,speedLimit)
        let customerData = dataProvider.GetCustomerDataFromDriverId(driverId)
        match analysis with 
        | true -> 
            debitService.DebitAccount(driverData.DriverId.ToString(),brainTreeToken, 10.M)
            notification.SendEmail(customerData.Email,"You were speeding","You were speeding")
        | false ->
            creditService.CreditAccount(customerData.Email,0.01)
        
