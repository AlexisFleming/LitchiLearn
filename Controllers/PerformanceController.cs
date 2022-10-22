using Final_LitchiLearn.Data;
using Final_LitchiLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Controllers
{
    public class PerformanceController : Controller
    {

        private readonly ApplicationDbContext _db;

        public PerformanceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Performance> objList = _db.Performances;
            return View(objList);
        }   
        public IActionResult Math()
        {
            IEnumerable<Performance> objList = _db.Performances;
            return View(objList);
        }
        public IActionResult Technology()
        {
            IEnumerable<Performance> objList = _db.Performances;
            return View(objList);
        }
    }
}
