using Microsoft.AspNetCore.Mvc;

namespace Final_LitchiLearn.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
