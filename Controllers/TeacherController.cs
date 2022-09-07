using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Final_LitchiLearn.Models;

namespace Final_LitchiLearn.Controllers
{
    public class TeacherController : Controller
    {
        //[Authorize(Roles = "Teacher")]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Subject()
        {
            return View();
        }
        public IActionResult Topics()
        {
            return View();
        }
        public IActionResult Quiz()
        {
            return View();
        }
        public IActionResult Student()
        {
            return View();
        }
        public IActionResult QuizMarks()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
     

    }
}
