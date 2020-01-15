using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Bussines.Service
{
    public class HttpRequests
    {
        private readonly string uri;

        public HttpRequests(string uri)
        {
            this.uri = uri;
        }

        public T Get<T>(string actionUrl) where T : class
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri + actionUrl);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                if (!string.IsNullOrEmpty(responseText))
                    return JsonConvert.DeserializeObject<T>(responseText);
                else
                    return null;
            }
        }
    }
}
