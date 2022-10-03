﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Final_LitchiLearn.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_LitchiLearn.Controllers
{
    public class Files1Controller : Controller
    {
        IHostingEnvironment _hostingEnvironment = null;

        public Files1Controller(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index(string fileName = "")
        {
            FileClass fileObj = new FileClass();
            fileObj.Name = fileName;

            string path = $"{_hostingEnvironment.WebRootPath}\\files\\";
            int nId = 1;

            foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                fileObj.files.Add(new FileClass());
                {
                    nId++;
                    fileName = Path.GetFileName(pdfPath);
                    path = pdfPath;

                }
            }

            return View(fileObj);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName)) 
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return Index();
        }

        public IActionResult PDFViewerNewTab(string fileName)
        {
            string path = _hostingEnvironment.WebRootPath + "\\files\\" + fileName;
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }
    }
}