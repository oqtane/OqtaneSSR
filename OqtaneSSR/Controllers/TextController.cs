using Microsoft.AspNetCore.Mvc;
using OqtaneSSR.Client.Services;

namespace OqtaneSSR.Controllers
{
    [Route("api/[controller]")]
    public class TextController : Controller
    {
        private readonly ITextService _TextService;

        public TextController(ITextService TextService)
        {
            _TextService = TextService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await _TextService.GetTextAsync();
        }
    }
}
