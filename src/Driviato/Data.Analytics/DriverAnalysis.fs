namespace Data.Analytics

open System
open Data.Model

type DriverAnalysis() = 
    member this.WasDriverSpeeding(speedRecord, speedLimit) = 
        let bufferedRecordedSpeed = speedRecord + 10.
        if bufferedRecordedSpeed > speedLimit then true else false




