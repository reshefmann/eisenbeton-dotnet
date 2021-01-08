#r "paket:
nuget Fake.Core.Target //"
// include Fake modules, see Fake modules section
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core


// *** Define Targets ***
Target.create "Clean" (fun _ ->
  Trace.log " --- Cleaning stuff --- "
)

Target.create "Build" (fun _ ->
  Trace.log " --- Building the app --- "
)

Target.create "Deploy" (fun _ ->
  Trace.log " --- Deploying app --- "
)


Target.create "Flatc" (fun _ ->
  CreateProcess.fromRawCommand 
      "flatc" 
      ["-o"; "flatc"; "--csharp"; "../eisenbeton-go/flatbuff/request.fbs"] 
      |> Proc.run 
      |> ignore
      
  CreateProcess.fromRawCommand 
      "flatc" 
      ["-o"; "flatc"; "--csharp"; "../eisenbeton-go/flatbuff/response.fbs"] 
      |> Proc.run 
      |> ignore

)


open Fake.Core.TargetOperators

// *** Define Dependencies ***
"Clean"
  ==> "Build"
  ==> "Deploy"

"Flatc" ==> "Clean"
// *** Start Build ***
Target.runOrDefault "Deploy"