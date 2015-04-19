namespace Data.Analytics

open Data.Model

type ProfileProfile() = 
    member this.HandleData () = 
        let notification = new SendGridNotification() :> INotificaton
        let debitService = new BrainTreeDebitService() :> IDebitService
        let creditService = new VenmoCreditService() :> ICreditService
        let speedLimitProvider = new GoogleMapsSpeedLimitProvider() :> ISpeedLimitProvider
        let driverAnalysis = new DriverAnalysis()
        ()
