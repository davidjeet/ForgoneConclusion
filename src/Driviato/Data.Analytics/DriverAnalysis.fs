namespace Data.Analytics

open System
open Data.Model

type DriverAnalysis() = 
    member this.WasDriverSpeeding(speedRecords, speedLimit) = 
        let highestRecordedSpeed = speedRecords |> Seq.max
        let bufferedRecordedSpeed = highestRecordedSpeed + 10
        if bufferedRecordedSpeed > speedLimit then true else false




