using Newtonsoft.Json.Linq;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordReadResponseBody
    {
        public RecordReadResponseBody()
        {
            data = new JObject();
        }
        public bool success { get; set; }
        public string errorTopic { get; set; }
        public string errorEvent { get; set; }
        public string error { get; set; }
        public int version { get; set; }
        public JObject data { get; set; }
    }
}
