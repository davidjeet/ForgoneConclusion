namespace Data.Analytics

open System
open Data.Model
open FSharp.Data

type SpeedLimit = JsonProvider<"../Data/GoogleSpeedLimit.json">

type GoogleMapsSpeedLimitProvider() = 
    interface ISpeedLimitProvider with 
        member this.GetSpeedLimit(latitude, longitude) = 
            let speedLimits = SpeedLimit.Load("../Data/GoogleSpeedLimit.json");
            let lastSpeedLimit = speedLimits.SpeedLimits |> Seq.head
            lastSpeedLimit.SpeedLimit

