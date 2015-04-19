namespace Data.Analytics

open System
open System.Net.Http
open System.Net.Http.Headers
open System.Net.Http.Formatting
open System.Collections.Generic

type IBMWatsonTranslationService() = 
    member this.InvokeService (phrase, language) = async {
        let serviceName = "machine_translation"
        let baseUrl = "http://wex-mt.mybluemix.net/resources/translate"
        let userName = "youNameHere@aol.com"
        let password = "yourPasswordHere"
        let authKey = userName + ":" + password
 
        let client = new HttpClient()
        client.DefaultRequestHeaders.Authorization <- new AuthenticationHeaderValue("Basic",authKey)
 
        let input = new Dictionary<string,string>()
        input.Add("text",phrase)
        input.Add("sid",language)
        let content = new FormUrlEncodedContent(input)
 
        let result = client.PostAsync(baseUrl,content).Result
        let resultContent = result.Content.ReadAsStringAsync().Result
        return resultContent 
    }


