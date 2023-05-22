using FOS_L1_201945D.Models.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOS_L1_201945D.Configuration
{
    public static class UserRoleSeed
    {
        public static void Seed(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            string[] roleNames = { "Admin", "Customer" };
            IdentityResult roleResult;

            // Check if roles exist, else create the roles
            foreach (string roleName in roleNames)
            {
                bool roleExist = roleManager.RoleExistsAsync(roleName).Result;
                if (!roleExist)
                { roleResult = roleManager.CreateAsync(new IdentityRole(roleName)).Result; }
            }

            //Create user called admin
            // MINIMUM INFO is UN,PW,Email
            string userName = "maryt";
            string userPwd = "Pa$$w0rd";
            ApplicationUser admin = new ApplicationUser
            {
                Name = "Mary Tan",
                PhoneNumber = "61153589",
                UserName = userName,
                Email = "marytan@fos.com"
            };           

            //Check if admin user dont exist, create the user
            ApplicationUser _user = userManager.FindByNameAsync(userName).Result;
            if (_user == null)
            {
                IdentityResult _result = userManager.CreateAsync(admin, userPwd).Result;
                if (_result.Succeeded)
                {
                    //Link the admin user to the "Administrator" role
                    userManager.AddToRoleAsync(admin, roleNames[0]).Wait();
                }
            }

            //Create user thats a customer
            // MINIMUM INFO is UN,PW,Email
            userName = "peterc";
            userPwd = "Pa$$w0rd";
            ApplicationUser customer = new ApplicationUser
            {
                Name = "Peter Chew",
                PhoneNumber = "91158935",
                UserName = userName,
                Email = "peterchew@test.com"
            };

            //Check if customer user dont exist, create the user
            _user = userManager.FindByNameAsync(userName).Result;
            if (_user == null)
            {
                IdentityResult _result = userManager.CreateAsync(customer, userPwd).Result;
                if (_result.Succeeded)
                {
                    //Link the admin user to the "Administrator" role
                    userManager.AddToRoleAsync(customer, roleNames[1]).Wait();
                }
            }

            //Create user thats a customer
            // MINIMUM INFO is UN,PW,Email
            userName = "davidp";
            userPwd = "Pa$$w0rd";
            customer = new ApplicationUser
            {
                Name = "David Pau",
                PhoneNumber = "81158798",
                UserName = userName,
                Email = "davidpau@test.com"
            };

            //Check if customer user dont exist, create the user
            _user = userManager.FindByNameAsync(userName).Result;
            if (_user == null)
            {
                IdentityResult _result = userManager.CreateAsync(customer, userPwd).Result;
                if (_result.Succeeded)
                {
                    //Link the admin user to the "Administrator" role
                    userManager.AddToRoleAsync(customer, roleNames[1]).Wait();
                }
            }



        }

    }
}
