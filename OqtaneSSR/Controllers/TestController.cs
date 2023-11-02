using Microsoft.AspNetCore.Mvc;

namespace OqtaneSSR.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }
    }
}
