using OqtaneSSR.Client.Services;

namespace OqtaneSSR.Services
{
    public class TextService : ITextService
    {
        public async Task<string> GetTextAsync()
        {
            return await Task.FromResult("Hello World!!");
        }
    }
}
