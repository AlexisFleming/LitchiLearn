using Microsoft.AspNetCore.Mvc;

namespace Final_LitchiLearn.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageMySubject()
        {
            return View();        
        }
        public IActionResult MySubjectPage()
        {
            return View();
        }

        public IActionResult ManageAccount()
        {
            return View();
        }

        public IActionResult TimeTable()
        {
            return View();
        }
    }
}
