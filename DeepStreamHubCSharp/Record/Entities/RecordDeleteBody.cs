namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordDeleteBody
    {
        public string topic { get; set; }
        public string action { get; set; }
        public string recordName { get; set; }
    }
}
