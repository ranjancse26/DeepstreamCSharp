using Newtonsoft.Json.Linq;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordWriteBody
    {
        public string topic { get; set; }
        public string action { get; set; }
        public string recordName { get; set; }
        public string path { get; set; }
        public int version { get; set; }
        public JObject data { get; set; }
    }
}
