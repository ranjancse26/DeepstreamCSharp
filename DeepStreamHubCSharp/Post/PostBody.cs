namespace DeepStreamHubCSharp.Post
{
    public class PostBody
    {
        public bool success { get; set; }
        public string error { get; set; }
        public string errorTopic { get; set; }
        public string errorEvent { get; set; }
    }
}
