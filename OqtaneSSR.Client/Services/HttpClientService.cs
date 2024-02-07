using System.Diagnostics;

namespace OqtaneSSR.Client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _http;

        public HttpClientService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GetTextAsync()
        {
            Debug.WriteLine("HttpClientService Call Started");
            var result = await _http.GetStringAsync("api/Text/");
            Debug.WriteLine("HttpClientService Call Completed");
            return result;
        }
    }
}
