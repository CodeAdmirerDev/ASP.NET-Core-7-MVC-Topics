using Microsoft.AspNetCore.Mvc;

namespace FiltersInASPNETCoreMVCApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ResponseCache(Duration = 60)]
    public class ResponseCacheExampleController : ControllerBase
    {

        [HttpGet]
        [ResponseCache(NoStore = true)]
        public string Index()
        {
            return $"I am using the response cache {DateTime.Now}";
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public string Test()
        {
            return $"I am using the response cache {DateTime.Now}";
        }

        public string Test2()
        {
            return $"I am using the response cache {DateTime.Now}";
        }
    }
}
