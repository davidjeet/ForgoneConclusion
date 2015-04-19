namespace Data.Analytics

open Data.Model

type public DriverProfile() = 
    member this.HandleData (driverId) = 
        let notification = new SendGridNotification() :> INotificaton
        let debitService = new BrainTreeDebitService() :> IDebitService
        let creditService = new VenmoCreditService() :> ICreditService
        let speedLimitProvider = new GoogleMapsSpeedLimitProvider() :> ISpeedLimitProvider
        let dataProvider = new MongoDataProvider();
        let driverAnalysis = new DriverAnalysis()
        let prediction = new AzureMLPrediction()

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

        let predictedSpeed = Async.RunSynchronously(prediction.InvokeService(driverId))
        let predictedSpeed' = System.Int32.Parse(predictedSpeed)
        let speedLimit' = System.Convert.ToInt32(speedLimit)
        let prediction = if(predictedSpeed' > speedLimit') then true else false
        match prediction with
        | true -> notification.SendEmail(customerData.Email,"You might speed soon","You might speed soon")
        | false-> ()
        