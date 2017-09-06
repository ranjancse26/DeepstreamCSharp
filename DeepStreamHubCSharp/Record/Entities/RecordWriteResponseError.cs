using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordWriteResponseErrorBody
    {
        public string errorTopic { get; set; }
        public string errorEvent { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        public int currentVersion { get; set; }
        public JObject currentData { get; set; }
    }

    public class RecordWriteResponseError
    {
        public string result { get; set; }
        public List<RecordWriteResponseErrorBody> body
            { get; set; }
    }
}
