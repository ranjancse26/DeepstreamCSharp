using DeepStreamHubCSharp.Record.Entities;
using DeepStreamHubCSharp.Record.Mappers;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Write
{
    public class DeepstreamRecordRead
    {
        public RecordReadResponse Read(string applicationUrl, 
               RecordReadRequest recordReadRequest)
        {
            var client = new RestClient(applicationUrl);
            var request = new RestRequest(Method.POST);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json",
                JsonConvert.SerializeObject(recordReadRequest),
                ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var responseJSON = response.Content.ToString();
            dynamic responseJSONObj = JsonConvert.DeserializeObject(responseJSON);

            if (responseJSONObj.result != "FAILURE")
            {                
                return JsonConvert.DeserializeObject<RecordReadResponse>(responseJSON);
            }

            var errorJSON = JsonConvert.DeserializeObject<RecordReadResponseError>(responseJSON);
            var errorBody = new List<RecordReadResponseBody>();
            errorBody.Add(new RecordReadResponseMapper().Map(errorJSON));

            return new RecordReadResponse
            {
                result = errorJSON.result,
                body = errorBody
            };
        }
    }
}
