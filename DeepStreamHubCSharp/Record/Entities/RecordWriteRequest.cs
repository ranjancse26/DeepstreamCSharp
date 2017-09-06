using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordWriteRequest
    {
        public string token { get; set; }
        public List<RecordWriteBody> body { get; set; }
    }
}
