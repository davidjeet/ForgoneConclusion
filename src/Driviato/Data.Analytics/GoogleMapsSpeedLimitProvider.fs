namespace Data.Analytics

open System
open Data.Model
open FSharp.Data

type SpeedLimit = JsonProvider<"C:\Git\ForgoneConclusion\src\Driviato\Data\GoogleSpeedLimit.json">

type GoogleMapsSpeedLimitProvider() = 
    interface ISpeedLimitProvider with 
        member this.GetSpeedLimit(latitude, longitude) = 
            let speedLimits = SpeedLimit.Load("C:\Git\ForgoneConclusion\src\Driviato\Data\GoogleSpeedLimit.json");
            let lastSpeedLimit = speedLimits.SpeedLimits |> Seq.head
            lastSpeedLimit.SpeedLimit

