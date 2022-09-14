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
            IEnumerable<Topics> topic = _db.Topics;
            return View(topic);
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
        public IActionResult TopicCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubjectCreate(Topics topic)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Topics.Add(topic);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);

        }

        public IActionResult SubjectCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubjectCreate(Subject subject)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Subjects.Add(subject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);

        }



    }
}
