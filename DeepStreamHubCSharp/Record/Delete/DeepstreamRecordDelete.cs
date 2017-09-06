using DeepStreamHubCSharp.Record.Entities;
using DeepStreamHubCSharp.Record.Mappers;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Write
{
    public class DeepstreamRecordDelete
    {
        public RecordDeleteResponse Delete(string applicationUrl, 
               RecordDeleteRequest recordDeleteRequest)
        {
            var client = new RestClient(applicationUrl);
            var request = new RestRequest(Method.POST);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json",
                JsonConvert.SerializeObject(recordDeleteRequest),
                ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var responseJSON = response.Content.ToString();
            dynamic responseJSONObj = JsonConvert.DeserializeObject(responseJSON);

            return JsonConvert.DeserializeObject<RecordDeleteResponse>(responseJSON);
        }
    }
}
