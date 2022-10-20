using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Final_LitchiLearn.Models;
using Final_LitchiLearn.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Final_LitchiLearn.Controllers
{
    //[Authorize(Roles = "Teacher")]
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
        public IActionResult TopicCreate(Topics topic)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Topics.Add(topic);
                _db.SaveChanges();
                return RedirectToAction("Topic");
            }
            return View(topic);

        }

        public IActionResult SubjectCreate() //takes us to create subject page to add subject
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
                return RedirectToAction("Subject");
            }
            return View(subject);

        }  
      


        public IActionResult UpdateSubject(int? id)//Get subject we want to update
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Subjects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSubject(Subject sub) //post update to update the changes
        {

            _db.Subjects.Update(sub);
            _db.SaveChanges();
            return RedirectToAction("Subject");
        }
       




    }
}
