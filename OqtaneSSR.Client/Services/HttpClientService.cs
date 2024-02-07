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
            return await _http.GetStringAsync("api/Text/");
        }
    }
}
