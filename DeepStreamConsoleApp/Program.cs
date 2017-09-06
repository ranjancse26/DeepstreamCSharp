using System;
using System.Configuration;
using DeepStreamHubCSharp.Auth;
using DeepStreamHubCSharp.Record.Write;
using Newtonsoft.Json.Linq;
using DeepStreamHubCSharp.Record.Entities;
using System.Linq;

namespace DeepStreamConsoleApp
{
    class Program
    {
        private static string recordName = "dsh-demo/ranjan4";

        static void Main(string[] args)
        {
            (new WebsocketHelper()).RunWebSocket();
            Console.ReadLine();

            var auth = new DeepstreamAuth();
            var authUrl = ConfigurationManager.AppSettings["ApplicationAuthUrl"].ToString();
            var cRUDUrl = ConfigurationManager.AppSettings["ApplicationCRUDUrl"].ToString();
            var emailAddress = ConfigurationManager.AppSettings["EmailAddress"].ToString();
            var password = ConfigurationManager.AppSettings["Password"].ToString();

            var response = auth.Authenticate(
                authUrl, new AuthRequest
                {
                    type = "email",
                    email = emailAddress,
                    password = password
                });

            var deleteResponse = RecordDelete(response.token, cRUDUrl);
            var readResponse = RecordRead(response.token, cRUDUrl);
            var writeResponse = RecordWrite(response.token, cRUDUrl);

            Console.ReadLine();
        }

        private static RecordDeleteResponse RecordDelete(string token, string authCRUDUrl)
        {
            var recordRead = new DeepstreamRecordDelete();
            var response = recordRead.Delete(authCRUDUrl, new RecordDeleteRequest
            {
                token = token,
                body = new System.Collections.Generic.List<RecordDeleteBody>()
                   {
                       new RecordDeleteBody
                       {
                           action = "delete",
                           topic = "record",
                           recordName = recordName
                       }
                   }
            });
            return response;
        }

        private static RecordReadResponse RecordRead(string token, string authCRUDUrl)
        {
            var recordRead = new DeepstreamRecordRead();
            var response = recordRead.Read(authCRUDUrl, new RecordReadRequest
            {
                token = token,
                body = new System.Collections.Generic.List<RecordReadBody>()
               {
                   new RecordReadBody
                   {
                       action = "read",
                       topic = "record",
                       recordName = recordName
                   }
               }
            });
            return response;
        }

        /// <summary>
        /// Token and HTTP Url is required.
        /// The version can be set to 0 if you want to always overwrite the data and not to worry about the explicity specifying the version numbers
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="authCRUDUrl">HTTP Url</param>
        /// <returns>RecordWriteResponse</returns>
        private static RecordWriteResponse RecordWrite(string token, string authCRUDUrl)
        {
            var recordWrite = new DeepstreamRecordWrite();

            dynamic jsonObject = new JObject();
            jsonObject.Name = "Testing";
            jsonObject.Age = 50;

            var recordWriteBody = new System.Collections.Generic.List<RecordWriteBody>();
            recordWriteBody.Add(new RecordWriteBody
            {
                action = "write",
                topic = "record",
                path = "name",
                recordName = recordName,
                version = 0,
                data = jsonObject
            });

            var response = recordWrite.Write(authCRUDUrl,
                new RecordWriteRequest
                {
                    token = token,
                    body = recordWriteBody
                });

            return response;
        }
    }
}
