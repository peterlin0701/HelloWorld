using HelloWorld.model.HelloWorld;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly HelloWorldConfig _config;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(IHttpContextAccessor contextAccessor, IOptions<HelloWorldConfig> config)
        {
            _contextAccessor = contextAccessor;
            _config = config.Value;
        }

        public IActionResult Index()
        {
            var xxx = _contextAccessor.HttpContext.Response.Cookies;
            ResponseViewModel model = new ResponseViewModel();
            model.AppName = _config.AppName;

            return View(model);
        }
    }
}
