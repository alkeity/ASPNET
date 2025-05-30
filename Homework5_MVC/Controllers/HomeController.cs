using Homework5_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework5_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGreetingService _greetingService;

        public HomeController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [ActionName("Index")]
        [HttpGet]
        public IActionResult IndexHttpGet()
        {
            return View();
        }

        [HttpGet]
        public string Welcome()
        {
            return _greetingService.GetGreetingMessage();
        }

        [HttpGet]
        public string Time()
        {
            return DateTime.Now.ToString();
        }
    }
}
