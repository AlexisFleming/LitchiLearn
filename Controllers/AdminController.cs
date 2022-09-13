using Final_LitchiLearn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult AdminCreateAccount()
        {
            return View();
        }

        public IActionResult AdminEditAccount()
        {
            return View();
        }

        public IActionResult AdminCreateSubject()
        {
            return View();
        }

        public IActionResult AdminEditSubject()
        {
            return View();
        }

        public IActionResult AdminAudit()
        {
            return View();
        }

    }
}
