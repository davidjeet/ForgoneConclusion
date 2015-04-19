
#r "C:/Github/ForgoneConclusion/src/Driviato/packages/FSharp.Data.2.2.0/lib/net40/FSharp.Data.dll"

open FSharp.Data

type SpeedLimit = JsonProvider<"../Data/GoogleSpeedLimit.json">
let speedLimits = SpeedLimit.Load("../Data/GoogleSpeedLimit.json");
let lastSpeedLimit = speedLimits.SpeedLimits |> Seq.head
lastSpeedLimit.SpeedLimit
