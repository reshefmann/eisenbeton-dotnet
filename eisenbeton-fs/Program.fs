// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Threading
open Suave
open Suave.LibUv
open eisenbeton.wire.request
open eisenbeton.wire.response
open FlatBuffers
open NATS.Client




let buildEisenRequest method path uri contentType content =
    let builder = FlatBuffers.FlatBufferBuilder 1024
    let method = builder.CreateString method
    let path = builder.CreateString path
    let uri = builder.CreateString uri
    let contentType = builder.CreateString contentType

    EisenRequest.StartContentVector(builder, 3)
    content |> Seq.map builder.AddByte |> ignore
    let content = builder.EndVector()

    EisenRequest.StartEisenRequest builder

    EisenRequest.AddMethod(builder, method)
    EisenRequest.AddPath(builder, path)
    EisenRequest.AddUri(builder, uri)
    EisenRequest.AddContentType(builder, contentType)

    EisenRequest.AddContent(builder, content)
    let request = EisenRequest.EndEisenRequest(builder)
    builder.Finish(request.Value)
    builder.SizedByteArray()

type EisenResp = {
    Status : int
    Content : byte[]
    Headers : List<string * string>
}

let openEisenResponse resp =
    let buf = ByteBuffer(buffer=resp)
    let response = EisenResponse.GetRootAsEisenResponse buf
    let headers = [| for i in 0..response.HeadersLength-1 do (response.Headers i) |] 
                    |> Array.map (fun h -> h.Value)
                    |> Array.map (fun h -> (h.Key, h.Value))
                    |> Array.toList
    
    
    {Status=response.Status
     Content=response.GetContentBytes().Value.ToArray()
     Headers=headers}

    

let callNats (natsConn : NATS.Client.IConnection) (ctx : HttpContext) : Async<HttpContext option> =
    let req = ctx.request
    let contentType = req.header "Content-Type" |> Choice.orDefault (fun()-> String.Empty)

    async {
        let! (msg : Msg) = natsConn.RequestAsync(ctx.request.path, (buildEisenRequest (req.method.ToString()) req.path req.url.AbsoluteUri contentType req.rawForm))
        let resp = openEisenResponse msg.Data
        return (Some {ctx with response = {status={code = resp.Status; reason = String.Empty}
                                           headers=resp.Headers
                                           writePreamble=true
                                           content=(Bytes resp.Content)}})
    }

[<EntryPoint>]
let main argv =
    let cts = new CancellationTokenSource()
    let conf = {defaultConfig with tcpServerFactory = new LibUvServerFactory(); cancellationToken = cts.Token; bindings = [HttpBinding.createSimple Protocol.HTTP "0.0.0.0" 8500]}
    let nc = NATS.Client.ConnectionFactory()
    let c = nc.CreateConnection()    

    let listening, server = startWebServerAsync conf (callNats c)
    Async.Start(server, cts.Token)
    printfn "Started"
    Console.ReadKey true |> ignore 
    
    0 
(*

main [||]

let handler ctx =
    greq <- ctx
    printfn "Here"
    async {
        return (Some {ctx with response = Http.HttpResult.empty})
    }

let l, svr = startWebServerAsync conf handler

Async.Start(svr, cts.Token)
cts.Cancel true   
let mutable greq : HttpContext = HttpContext.empty


greq.request.header "content-type" |> Choice.orDefault "klakak"
greq.request.url.ToString()

let nc = NATS.Client.ConnectionFactory()
let c = nc.CreateConnection()    


c.RequestAsync("/test", [|66uy; 67uy|]) |> ignore

buildEisenRequest "GET" "/test" "/test" "application/json" [| (byte)66; (byte)67; (byte)68 |]

open System.IO
use stream = File.Open("/tmp/resp.bin", FileMode.Open, FileAccess.Read)
use mem = new MemoryStream()
stream.CopyTo mem

let data = mem.ToArray()
  
openEisenResponse data

*)