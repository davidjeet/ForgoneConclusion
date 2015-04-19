
#r "C:/Users/jamie/Desktop/4Gone.DriveSafe.Analytics/packages/FSharp.Data.2.2.0/lib/net40/FSharp.Data.dll"

open FSharp.Data

type SpeedLimit = JsonProvider<"C:\Users\jamie\Desktop\4Gone.DriveSafe.Analytics\Data\GoogleSpeedLimit.json">
let speedLimits = SpeedLimit.Load("C:\Users\jamie\Desktop\4Gone.DriveSafe.Analytics\Data\GoogleSpeedLimit.json");
let lastSpeedLimit = speedLimits.SpeedLimits |> Seq.head
lastSpeedLimit.SpeedLimit
