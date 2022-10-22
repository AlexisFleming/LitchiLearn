using Final_LitchiLearn.Data;
using Final_LitchiLearn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Controllers
{
    public class TaskingController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TaskingController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Tasking> objList = _db.Taskings;//Coming from our database
            return View(objList);
        }

        //GET Method returning the Create.cshtml
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tasking obj)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Taskings.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Taskings.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Tasking obj)
        {
            _db.Taskings.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
