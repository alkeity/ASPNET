using Homework6_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework6_MVC.Controllers
{
    public class CalcController : Controller
    {
        ICalcService _calcService;

        public CalcController(ICalcService calcService)
        {
            _calcService = calcService;
        }

        [ActionName("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("Index")]
        [HttpPost]
        public IActionResult Calculate(IFormCollection form)
        {
            string result;
            try
            {
                double res = _calcService.Calculate(Convert.ToDouble(form["num1"]), Convert.ToDouble(form["num2"]), form["operation"]);
                result = $"{form["num1"]} {form["operation"]} {form["num2"]} = {res}";
            }
            catch (DivideByZeroException exc)
            {
                result = exc.Message;
            }
            return Content(result);
        }
    }
}
