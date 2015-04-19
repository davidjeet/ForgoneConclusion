namespace Data.Analytics

open System
open System.Net.Http
open System.Net.Http.Headers
open System.Net.Http.Formatting
open System.Collections.Generic

type scoreData = {FeatureVector:Dictionary<string,string>;GlobalParameters:Dictionary<string,string>}
type scoreRequest = {Id:string; Instance:scoreData}

type AzureMLPrediction() = 
    member this.InvokeService (driverId) = async {
        let apiKey = "vaYw5jy0Jt9+NDlqCIkj5iDEpzfgoMMUprgfd+PqKS6+3U4cn4LjwJUf0KMkjqNqHGk8UaPEbPe2x0BriErtHw=="
        let uri = "https://ussouthcentral.services.azureml.net/workspaces/19a2e623b6a944a3a7f07c74b31c3b6d/services/56ad502e560b4c66a01b763c85b3a783/execute?api-version=2.0&details=true"
        use client = new HttpClient()
        client.DefaultRequestHeaders.Authorization <- new AuthenticationHeaderValue("Bearer",apiKey)
        client.BaseAddress <- new Uri(uri)

        let input = new Dictionary<string,string>()
        input.Add("Col1",driverId)
        input.Add("Col2","0")
 
        let instance = {FeatureVector=input; GlobalParameters=new Dictionary<string,string>()}
        let scoreRequest = {Id="score00001";Instance=instance}
 
        let! response = client.PostAsJsonAsync("",scoreRequest) |> Async.AwaitTask
        let! result = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        return result 
    }

