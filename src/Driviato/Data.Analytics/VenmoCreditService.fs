namespace Data.Analytics

open System
open Data.Model
open VenmoWrapper

type VenmoCreditService() = 
    interface ICreditService with 
        member this.CreditAccount(customerEmail, amount) = 
            VenmoHelper.PostVenmoTransaction(VenmoHelper.USER_TYPE.EMAIL,customerEmail,"Payment", amount) |> ignore
