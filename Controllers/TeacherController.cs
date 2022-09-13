using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Final_LitchiLearn.Models;
using Final_LitchiLearn.Data;
using System.Collections;
using System.Collections.Generic;

namespace Final_LitchiLearn.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Subject()
        {
            //load subjects to the Subject Page
            IEnumerable<Subject> sub = _db.Subjects;
            return View(sub);
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
