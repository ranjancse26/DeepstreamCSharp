using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordDeleteRequest
    {
        public string token { get; set; }
        public List<RecordDeleteBody> body { get; set; }
    }
}
