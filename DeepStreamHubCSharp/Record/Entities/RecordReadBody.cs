namespace DeepStreamHubCSharp.Record.Entities
{
    public class RecordReadBody
    {
        public string topic { get; set; }
        public string action { get; set; }
        public string recordName { get; set; }
    }
}
