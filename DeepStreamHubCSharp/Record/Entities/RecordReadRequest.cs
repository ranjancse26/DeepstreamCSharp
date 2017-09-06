using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordReadRequest
    {
        public string token { get; set; }
        public List<RecordReadBody> body { get; set; }
    }
}
