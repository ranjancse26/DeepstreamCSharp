using DeepStreamHubCSharp.Record.Entities;

namespace DeepStreamHubCSharp.Record.Mappers
{
    public class RecordReadResponseMapper
    {
        public RecordReadResponseBody Map(RecordReadResponseError recordWriteResponseError)
        {
            return new RecordReadResponseBody
            {
                success = recordWriteResponseError.body[0].success,
                error = recordWriteResponseError.body[0].error,
                errorEvent = recordWriteResponseError.body[0].errorEvent,
                errorTopic = recordWriteResponseError.body[0].errorTopic,
            };
        }
    }
}
