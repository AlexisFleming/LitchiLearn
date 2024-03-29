﻿using Final_LitchiLearn.Data;
using Final_LitchiLearn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Final_LitchiLearn.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        

        public string nameSelected { get; set; }

        [Authorize(Roles = "Admin")]
        public IActionResult RemoveRequest(string userName)
        {
            userName = Request.Query["userId"];
            List<AccountRequestModel>accountList = _db.AccountRequestModels.Where(x => x.RequestUsername == userName).ToList();

            var userRequestViewModel = new List<AccountRequestModel>();


            foreach (AccountRequestModel account in accountList)
            {
                //if (account.RequestUsername == userName)
                //{
                    var thisAccountModel = new AccountRequestModel();
                    thisAccountModel.RequestID = account.RequestID;
                    thisAccountModel.RequestUsername = account.RequestUsername;
                    thisAccountModel.Email = account.Email;
                    thisAccountModel.RoleChanged = account.RoleChanged;
                    thisAccountModel.RequestStatus = account.RequestStatus;
                    userRequestViewModel.Add(thisAccountModel);
                //}


            }

            

            return View(userRequestViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveRequestPost(string USERNAME)
        {
            List<AccountRequestModel>accountList = _db.AccountRequestModels.Where(x => x.RequestUsername.Equals(USERNAME)).ToList();
            foreach(var account in accountList)
            {
                account.RequestStatus = 2;
                _db.AccountRequestModels.Update(account);


            }

            
            
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            var requests = await _db.AccountRequestModels.ToListAsync();
            var userRequestViewModel = new List<AccountRequestModel>();




            foreach (ApplicationUser user in users)
            {
                foreach (var account in requests)

                    if ((user.UserName == account.RequestUsername) && (account.RequestStatus == 1))
                    {
                        ViewBag.requestedChange = account.RoleChanged;
                        var thisViewModel = new UserRolesViewModel();
                        var thisAccountModel = new AccountRequestModel();
                        thisViewModel.UserId = user.Id;
                        thisViewModel.Email = user.Email;
                        thisViewModel.UserName = account.RequestUsername;
                        thisViewModel.FirstName = user.FirstName;
                        thisViewModel.LastName = user.LastName;
                        thisViewModel.Roles = await GetUserRoles(user);
                        userRolesViewModel.Add(thisViewModel);
                        thisAccountModel.RequestID = account.RequestID;
                        thisAccountModel.RequestUsername = account.RequestUsername;
                        thisAccountModel.Email = account.Email;
                        thisAccountModel.RoleChanged = account.RoleChanged;
                        thisAccountModel.RequestStatus = account.RequestStatus;
                        userRequestViewModel.Add(thisAccountModel);

                    }
            }
            return View(userRolesViewModel);
        }
        [Authorize(Roles = "Admin")]
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;

            var requests = await _db.AccountRequestModels.ToListAsync();
            var userRequestViewModel = new List<AccountRequestModel>();

            foreach (var account in requests)

                if (user.UserName == account.RequestUsername)
                {
                    var thisAccountModel = new AccountRequestModel();
                    thisAccountModel.RequestID = account.RequestID;
                    thisAccountModel.RequestUsername = account.RequestUsername;
                    thisAccountModel.Email = account.Email;
                    thisAccountModel.RoleChanged = account.RoleChanged;
                    thisAccountModel.RequestStatus = account.RequestStatus;
                    userRequestViewModel.Add(thisAccountModel);
                    ViewBag.roleChange = (thisAccountModel.RoleChanged);

                }


            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                model.Add(userRolesViewModel);
            }
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("Index");
        }

       
        public IActionResult UserReportPDF()
        {
            var Renderer = new IronPdf.ChromePdfRenderer();

            

            //create the doc
            using var PDF = Renderer.RenderUrlAsPdf("https://localhost:44319/UserRoles/AdminReports");

            var contentLength = PDF.BinaryData.Length;
            Response.Headers["Content-Length"] = contentLength.ToString();
            Response.Headers.Add("Content-Disposition", "inline; filename = TimeTableForStudent.pdf");

            return File(PDF.BinaryData, "Application/pdf;");

        }


        public async Task<IActionResult> AdminReports()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            var requests = await _db.AccountRequestModels.ToListAsync();
            var userRequestViewModel = new List<AccountRequestModel>();




            foreach (ApplicationUser user in users)
            {
                foreach (var account in requests)

                   
                        ViewBag.requestedChange = account.RoleChanged;
                        var thisViewModel = new UserRolesViewModel();                       
                        thisViewModel.UserId = user.Id;
                        thisViewModel.Email = user.Email;
                        thisViewModel.FirstName = user.FirstName;
                        thisViewModel.LastName = user.LastName;
                        thisViewModel.UserName = user.UserName;
                        thisViewModel.Roles = await GetUserRoles(user);
                        userRolesViewModel.Add(thisViewModel);
                        
                    
            }
            return View(userRolesViewModel);
        }




    }
}
