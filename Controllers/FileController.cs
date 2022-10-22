using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Final_LitchiLearn.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveFile(IFormFile File1)
        {
            if (File1 != null)
            {
                string FileName = File1.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", FileName);

                var stream = new FileStream(path, FileMode.Create);
                File1.CopyToAsync(stream);

                string url = "/files" + FileName;
            }


            return View();

        }


        public IActionResult MIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MSaveFile(IFormFile File1)
        {
            if (File1 != null)
            {
                string FileName = File1.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/moderation", FileName);

                var stream = new FileStream(path, FileMode.Create);
                File1.CopyToAsync(stream);

                string url = "/files" + FileName;
            }


            return View();
        }
    }
}
