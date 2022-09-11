using Microsoft.AspNetCore.Mvc;
using Final_LitchiLearn.Data;
using Final_LitchiLearn.Models;
using System.Collections.Generic;

namespace Final_LitchiLearn.Controllers
{
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
            IEnumerable<TimeTable> objList = _db.TimeTable;
            return View(objList);
            
        }

       
    }
}
