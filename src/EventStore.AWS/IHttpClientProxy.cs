namespace EventStore.AWS
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IHttpClientProxy
    {
        Task<HttpResponseMessage> SendAsync(HttpClient client, HttpRequestMessage request);
    }
}