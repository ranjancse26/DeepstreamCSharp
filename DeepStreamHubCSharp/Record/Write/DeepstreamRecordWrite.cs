using DeepStreamHubCSharp.Record.Entities;
using DeepStreamHubCSharp.Record.Mappers;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Write
{
    public class DeepstreamRecordWrite
    {
        public RecordWriteResponse Write(string applicationUrl, 
               RecordWriteRequest recordWriteRequest)
        {
            var client = new RestClient(applicationUrl);
            var request = new RestRequest(Method.POST);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json",
                JsonConvert.SerializeObject(recordWriteRequest),
                ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var responseJSON = response.Content.ToString();
            dynamic responseJSONObj = JsonConvert.DeserializeObject(responseJSON);

            if (responseJSONObj.result != "FAILURE")
            {                
                return JsonConvert.DeserializeObject<RecordWriteResponse>(responseJSON);
            }

            var errorJSON = JsonConvert.DeserializeObject<RecordWriteResponseError>(responseJSON);
            var errorBody = new List<RecordWriteResponseBody>();
            errorBody.Add(new RecordWriteResponseMapper().Map(errorJSON));

            return new RecordWriteResponse
            {
                result = errorJSON.result,
                body = errorBody
            };
        }
    }
}
