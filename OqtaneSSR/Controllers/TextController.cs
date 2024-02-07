using Microsoft.AspNetCore.Mvc;
using OqtaneSSR.Client.Services;
using System.Diagnostics;

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
            Debug.WriteLine("TextController Started");
            var result = await _TextService.GetTextAsync();
            Debug.WriteLine("TextController Completed");
            return result;
        }
    }
}
