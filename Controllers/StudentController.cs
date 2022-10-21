using Microsoft.AspNetCore.Mvc;
using Final_LitchiLearn.Data;
using Final_LitchiLearn.Models;
using System.Collections.Generic;
using System.Linq;
using Final_LitchiLearn.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Data;

using System;

namespace Final_LitchiLearn.Controllers
{
    //[Authorize(Roles = "Student")]
    public class StudentController : Controller


    {   //this is for the PDF Report print out 




        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Student")]
        public IActionResult ManageMySubject()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public IActionResult ManageMySubject(Enrol obj)
        {

            if (ModelState.IsValid)
            {
                _db.EnrolTable.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ManageMySubject");
            }
            return View();




        }
        [Authorize(Roles = "Student")]
        public IActionResult MySubjectPage()
        {
            IEnumerable<Enrol> objList = _db.EnrolTable;
            return View(objList);
        }
        [Authorize(Roles = "Student")]
        public IActionResult ManageAccount()
        {
            return View();
        }

        public IActionResult TimeTable()
        {
            IEnumerable<TimeTable> objList = _db.TimeTable;
            return View(objList);


        }

        public IActionResult TimeTablePDF()
        {
            var Renderer = new IronPdf.ChromePdfRenderer();
            //create the doc
            using var PDF = Renderer.RenderUrlAsPdf("https://localhost:44319/Student/TimeTable");

            var contentLength = PDF.BinaryData.Length;
            Response.Headers["Content-Length"] = contentLength.ToString();
            Response.Headers.Add("Content-Disposition", "inline; filename = TimeTableForStudent.pdf");

            return File(PDF.BinaryData, "Application/pdf;");

        }

        // sport Tracker 

        public IActionResult SportTracker()
        {
            IEnumerable<Sports> objList = _db.Sports;
            return View(objList);

        }

        public IActionResult CreateSport(Sports obj)
        {
            if (ModelState.IsValid)
            {
                _db.Sports.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("SportTracker");

            }
            return View(obj);

        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Sports.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Sports obj)
        {
            _db.Sports.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("DisplaySport");

        }

        public IActionResult StudentCreateSport()
        { 
        
            return View();
        }










    }
}
