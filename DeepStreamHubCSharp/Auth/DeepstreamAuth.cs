using Newtonsoft.Json;
using RestSharp;

namespace DeepStreamHubCSharp.Auth
{
    public class DeepstreamAuth
    {
        /// <summary>
        /// Authenticate and return AuthResponse (JSON) with ClientData if one
        /// </summary>
        /// <param name="applicationUrl">ApplicationUrl</param>
        /// <param name="authEntity">AuthEntity</param>
        /// <returns>AuthResponse</returns>
        public AuthResponse Authenticate(string applicationUrl,
            AuthRequest authEntity)
        {
            var authJSON = JsonConvert.SerializeObject(authEntity);
            var client = new RestClient(applicationUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json",
                authJSON.ToString(),
                ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               var responseJSON = response.Content.ToString();
                return JsonConvert.DeserializeObject<AuthResponse>(responseJSON);
            }

            return null;
        }
    }
}
