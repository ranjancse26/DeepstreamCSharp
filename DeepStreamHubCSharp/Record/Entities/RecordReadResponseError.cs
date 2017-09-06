using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordReadResponseErrorBody
    {
        public string errorTopic { get; set; }
        public string errorEvent { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        public int currentVersion { get; set; }
        public JObject currentData { get; set; }
    }

    public class RecordReadResponseError
    {
        public string result { get; set; }
        public List<RecordReadResponseErrorBody> body
            { get; set; }
    }
}
