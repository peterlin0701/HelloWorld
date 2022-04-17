using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult CodeMonkey()
        {
            return View();
        }
    }
}
