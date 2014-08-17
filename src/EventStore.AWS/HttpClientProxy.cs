using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.AWS
{
    using System.Net.Http;

    public class HttpClientProxy : IHttpClientProxy
    {
        public async Task<HttpResponseMessage> SendAsync(HttpClient client, HttpRequestMessage request)
        {
            return await client.SendAsync(request);
        }
    }
}
