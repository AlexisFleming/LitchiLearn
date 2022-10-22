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
        public IActionResult EngPDF()
        {
            var Renderer = new IronPdf.ChromePdfRenderer();
            //create the doc
            using var PDF = Renderer.RenderUrlAsPdf("http://sict-iis.mandela.ac.za/19/Performance/Index");

            var contentLength = PDF.BinaryData.Length;
            Response.Headers["Content-Length"] = contentLength.ToString();
            Response.Headers.Add("Content-Disposition", "inline; filename = TimeTableForStudent.pdf");

            return File(PDF.BinaryData, "Application/pdf;");

        }
        public IActionResult MathPDF()
        {
            var Renderer = new IronPdf.ChromePdfRenderer();
            //create the doc
            using var PDF = Renderer.RenderUrlAsPdf("http://sict-iis.mandela.ac.za/19/Performance/Math");

            var contentLength = PDF.BinaryData.Length;
            Response.Headers["Content-Length"] = contentLength.ToString();
            Response.Headers.Add("Content-Disposition", "inline; filename = TimeTableForStudent.pdf");

            return File(PDF.BinaryData, "Application/pdf;");

        }
        public IActionResult TechPDF()
        {
            var Renderer = new IronPdf.ChromePdfRenderer();
            //create the doc
            using var PDF = Renderer.RenderUrlAsPdf("http://sict-iis.mandela.ac.za/19/Performance/Technology");

            var contentLength = PDF.BinaryData.Length;
            Response.Headers["Content-Length"] = contentLength.ToString();
            Response.Headers.Add("Content-Disposition", "inline; filename = TimeTableForStudent.pdf");

            return File(PDF.BinaryData, "Application/pdf;");

        }
    }
}
