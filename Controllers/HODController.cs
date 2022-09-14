using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Final_LitchiLearn.Models;
using Final_LitchiLearn.Data;
using System.Collections;
using System.Collections.Generic;

namespace Final_LitchiLearn.Controllers
{
    [Authorize(Roles = "Hod")]
    public class HodController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HodController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HodAssign()
        {
            return View();
        }
        public IActionResult ReportStudent()
        {
            return View();
        }
        public IActionResult ReportGrade()
        {
            return View();
        }
        public IActionResult Grades()
        {
            return View();
        }

        public IActionResult Subjects()
        {
            return View();
        }

    }
}