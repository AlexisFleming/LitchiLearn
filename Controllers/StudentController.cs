using Microsoft.AspNetCore.Mvc;
using Final_LitchiLearn.Data;
using Final_LitchiLearn.Models;
using System.Collections.Generic;
using System.Linq;
using Final_LitchiLearn.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Final_LitchiLearn.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ManageMySubject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ManageMySubject(Enrol obj)
        {
            return View();

            if (ModelState.IsValid)
            { 
                _db.EnrolTable.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ManageMySubject");
            }


                 
        }
        public IActionResult MySubjectPage()
        {
            IEnumerable<Enrol> objList = _db.EnrolTable;
            return View(objList);
        }

        public IActionResult ManageAccount()
        {
            return View();
        }

        public IActionResult TimeTable()
        {
            IEnumerable<TimeTable> objList = _db.TimeTable;
            return View(objList);
            
        }

       
    }
}
