namespace OqtaneSSR.Client.Services
{
    public class TextService : ITextService
    {
        private readonly HttpClient _http;

        public TextService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GetTextAsync()
        {
            return await _http.GetStringAsync("api/Text/");
        }
    }
}
