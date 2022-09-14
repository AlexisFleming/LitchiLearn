using Final_LitchiLearn.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Final_LitchiLearn.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SchoolAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.HOD.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SubjectCoordinator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Teacher.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Student.ToString()));
        }
        public static async Task SeedSchoolAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "schooladmin",
                Email = "schooladmin@gmail.com",
                FirstName = "Mark",
                LastName = "Smith",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@123");                 
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Student.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Teacher.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SubjectCoordinator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.HOD.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SchoolAdmin.ToString());
                }

            }
        }
    }
}