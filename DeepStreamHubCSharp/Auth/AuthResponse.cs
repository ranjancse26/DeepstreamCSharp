namespace DeepStreamHubCSharp.Auth
{
    public class ClientData
    {
        public string client { get; set; }
    }

    public class AuthResponse
    {
        public bool success { get; set; }
        public string token { get; set; }
        public ClientData clientData { get; set; }
    }
}
