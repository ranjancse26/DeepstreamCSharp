using System.Collections.Generic;

namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordReadResponse
    {
        public string result { get; set; }
        public List<RecordReadResponseBody> body
            { get; set; }
    }
}
