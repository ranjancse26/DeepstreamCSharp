using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordDeleteResponse
    {
        public string result { get; set; }
        public List<RecordDeleteResponseBody> body
            { get; set; }
    }
}
