using Final_LitchiLearn.Data;
using Final_LitchiLearn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult AdminDashboard()
        {
            return View();
        }
        
        public IActionResult AdminCreateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(UserAccountModel obj)
        {
            if (ModelState.IsValid)
            {
                obj.Active = "True";
                _db.UserAccountModels.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("AdminCreateAccount");
            }
            return View(obj);
        }

        public IActionResult AdminEditAccount()
        {
            IEnumerable<UserAccountModel> accountList = _db.UserAccountModels;
            return View(accountList);
        }

        public IActionResult AdminEditAccountChosen(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.UserAccountModels.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]      
        public IActionResult AdminUpdateAccount(UserAccountModel obj)
        {
            obj.Active = "True";
            _db.UserAccountModels.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("AdminEditAccount");
        }


        public IActionResult AdminRemoveAccountChosen(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.UserAccountModels.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        public IActionResult AdminRemoveAccount(UserAccountModel obj)
        {

            obj.Active = "False";
            _db.UserAccountModels.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("AdminEditAccount");
        }


        //public IActionResult AdminCreateSubject()
        //{
        //    //IEnumerable<UserAccountModel> accountList = _db.UserAccountModels;
        //    //IEnumerable<AdminSubject> subjectList = _db.AdminSubjectModels;
        //    //ViewData["UserAccounts"] = accountList;
        //    //ViewData["SubjectList"] = subjectList;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateSubject (AdminSubject obj)
        //{
        //    if (ModelState.IsValid)
        //    {
                
        //        _db.AdminSubjectModels.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("AdminCreateSubject");
        //    }
        //    return View(obj);
        //}



        //public IActionResult AdminEditSubject()
        //{
        //    IEnumerable<AdminSubject> subjectList = _db.AdminSubjectModels;
        //    return View(subjectList);
            
        //}


        //public IActionResult AdminEditSubjectChosen(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var obj = _db.AdminSubjectModels.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
            
        //    return View(obj);
        //}

        //[HttpPost]
        //public IActionResult AdminUpdateSubject(AdminSubject obj)
        //{
            
        //    _db.AdminSubjectModels.Update(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("AdminEditSubject");
        //}

        //public IActionResult AdminRemoveSubjectChosen(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var obj = _db.AdminSubjectModels.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(obj);
        //}
        //[HttpPost]
        //public IActionResult AdminRemoveSubject(AdminSubject obj)
        //{
        //    _db.AdminSubjectModels.Remove(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("AdminEditSubject");
        //}

        public IActionResult AdminAudit()
        {
            return View();
        }

     
        public IActionResult CreateAccountRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccountRequest(AccountRequestModel obj)
        {
            if (ModelState.IsValid)
            {
                obj.RequestStatus = 1;
                _db.AccountRequestModels.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("AdminDashBoard");
            }
            return View(obj);
        }



        public IActionResult CuriculumPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CuriculumPage(CurriculumModel curriculum)
        {
            if (ModelState.IsValid)
            {

                _db.CurriculumModel.Add(curriculum);
                _db.SaveChanges();
                return RedirectToAction("AdminDasboard");
            }
            return View(curriculum);
        }

        



    }
}
