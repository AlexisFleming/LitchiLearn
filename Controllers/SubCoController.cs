using Final_LitchiLearn.Data;
using Final_LitchiLearn.Models;
using Final_LitchiLearn.SpecialClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Controllers
{
    //[Authorize(Roles = "SubjectCoordinator")]
    public class SubCoController : Controller
    {
        private readonly ILogger<SubCoController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _appContext;

        public SubCoController(ILogger<SubCoController> logger,
                     IWebHostEnvironment hostingEnvironment,
                     ApplicationDbContext appContext)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _appContext = appContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult Moderate()
        {
            return View();
        }
        public IActionResult Upload()
        {
            AttachmentViewModel model = new AttachmentViewModel();
            model.attachments = _appContext.attachments.Select(m => m).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(AttachmentViewModel model)
        {
            if (model.attachment != null)
            {
                //write file to a physical path
                var uniqueFileName = SPClass.CreateUniqueFileExtension(model.attachment.FileName);
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "attachment");
                var filePath = Path.Combine(uploads, uniqueFileName);
                model.attachment.CopyTo(new FileStream(filePath, FileMode.Create));

                //save the attachment to the database
                Attachment attachment = new Attachment();
                attachment.FileName = uniqueFileName;
                attachment.Description = model.Description;
                attachment.attachment = SPClass.GetByteArrayFromImage(model.attachment);

                _appContext.attachments.Add(attachment);
                _appContext.SaveChanges();
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        public FileResult GetFileResultDemo(string filename)
        {
            string path = "/attachment/" + filename;
            string contentType = SPClass.GetContenttype(filename);
            return File(path, contentType);
        }

        [HttpGet]
        public FileContentResult GetFileContentResultDemo(string filename)
        {
            string path = "wwwroot/attachment/" + filename;
            byte[] fileContent = System.IO.File.ReadAllBytes(path);
            string contentType = SPClass.GetContenttype(filename);
            return new FileContentResult(fileContent, contentType);
        }
        [HttpGet]
        public async Task<FileContentResult> GetFileContentResultDemoAsync(string filename)
        {
            string path = "wwwroot/attachment/" + filename;
            byte[] data = await System.IO.File.ReadAllBytesAsync(path);
            string contentType = SPClass.GetContenttype(filename);
            return new FileContentResult(data, contentType);
        }
        [HttpGet]
        public FileStreamResult GetFileStreamResultDemo(string filename) //download file
        {
            string path = "wwwroot/attachment/" + filename;
            var stream = new MemoryStream(System.IO.File.ReadAllBytes(path));
            string contentType = SPClass.GetContenttype(filename);
            return new FileStreamResult(stream, new MediaTypeHeaderValue(contentType))
            {
                FileDownloadName = filename
            };
        }

        [HttpGet]
        public VirtualFileResult GetVirtualFileResultDemo(string filename)
        {
            string path = "attachment/" + filename;
            string contentType = SPClass.GetContenttype(filename);
            return new VirtualFileResult(path, contentType);
        }

        [HttpGet]
        public PhysicalFileResult GetPhysicalFileResultDemo(string filename)
        {
            string path = "/wwwroot/attachment/" + filename;
            string contentType = SPClass.GetContenttype(filename);
            return new PhysicalFileResult(_hostingEnvironment.ContentRootPath
                + path, contentType);
        }

        [HttpGet]
        public ActionResult GetAttachment(int ID)
        {

            byte[] fileContent;
            string fileName = string.Empty;

            Attachment attachment = new Attachment();

            attachment = _appContext.attachments.Select(m => m).Where(m => m.id == ID).FirstOrDefault();

            string contentType = SPClass.GetContenttype(attachment.FileName);
            fileContent = (byte[])attachment.attachment;


            return new FileContentResult(fileContent, contentType);
        }
    }
}
