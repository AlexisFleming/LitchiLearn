using Microsoft.AspNetCore.Mvc;

namespace Final_LitchiLearn.Controllers
{
    public class SubCoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult Moderate()
        {
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }
    }
}
