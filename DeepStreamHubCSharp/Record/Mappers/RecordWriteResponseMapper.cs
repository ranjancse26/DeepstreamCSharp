using DeepStreamHubCSharp.Record.Entities;

namespace DeepStreamHubCSharp.Record.Mappers
{
    public class RecordWriteResponseMapper
    {
        public RecordWriteResponseBody Map(RecordWriteResponseError recordWriteResponseError)
        {
            return new RecordWriteResponseBody
            {
                success = recordWriteResponseError.body[0].success,
                data = recordWriteResponseError.body[0].currentData,
                error = recordWriteResponseError.body[0].error,
                errorEvent = recordWriteResponseError.body[0].errorEvent,
                errorTopic = recordWriteResponseError.body[0].errorTopic,
                version = recordWriteResponseError.body[0].currentVersion
            };
        }
    }
}
