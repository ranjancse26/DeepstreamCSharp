using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordWriteResponse
    {
        public string result { get; set; }
        public List<RecordWriteResponseBody> body
            { get; set; }
    }
}
