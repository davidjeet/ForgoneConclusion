#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Net.Http.dll"
#r @"..\packages\Microsoft.AspNet.WebApi.Client.5.2.2\lib\net45\System.Net.Http.Formatting.dll"
 
open System
open System.Net.Http
open System.Net.Http.Headers
open System.Net.Http.Formatting
open System.Collections.Generic
 
let serviceName = "machine_translation"
let baseUrl = "http://wex-mt.mybluemix.net/resources/translate"
let userName = "youNameHere@aol.com"
let password = "yourPasswordHere"
let authKey = userName + ":" + password
 
let client = new HttpClient()
client.DefaultRequestHeaders.Authorization <- new AuthenticationHeaderValue("Basic",authKey)
 
let input = new Dictionary<string,string>()
input.Add("text","This is a test")
input.Add("sid","mt-enus-eses")
let content = new FormUrlEncodedContent(input)
 
let result = client.PostAsync(baseUrl,content).Result
let resultContent = result.Content.ReadAsStringAsync().Result