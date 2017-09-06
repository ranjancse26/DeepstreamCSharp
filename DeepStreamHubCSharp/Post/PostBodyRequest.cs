namespace DeepStreamHubCSharp.Post
{
    public class PostBodyRequest
    {
        public string topic { get; set; }
        public string action { get; set; }
        public string eventName { get; set; }
        public object data { get; set; }
    }
}
