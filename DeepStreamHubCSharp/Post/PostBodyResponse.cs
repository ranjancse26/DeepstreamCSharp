using System.Collections.Generic;

namespace DeepStreamHubCSharp.Post
{
    public class PostBodyResponse
    {
        public string result { get; set; }
        public List<PostBody> body { get; set; }
    }
}
