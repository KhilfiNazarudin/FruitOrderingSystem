using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FOS_L1_201945D.Models.ViewModels;
using FOS_L1_201945D.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FOS_L1_201945D.Models;
using Microsoft.EntityFrameworkCore;

namespace FOS_L1_201945D.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        FOUserDBContext FOUDBC;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager, FOUserDBContext context)
        {
            
            _userManager = usermanager;
            _signInManager = signInManager;
            FOUDBC = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            RegisterVM rvm = new RegisterVM();
            return View(rvm);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM rvm)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = rvm.Username,
                    Email = rvm.Email,
                    Name = rvm.Name,
                };
                    

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(IdentityError error  in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(rvm);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            LoginVM lvm = new LoginVM();
            return View(lvm);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM lvm, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Username, lvm.Password, lvm.RememberMe, false);

                if(result.Succeeded)
                {
                    if (returnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        return LocalRedirect(returnUrl);
                }
                ModelState.AddModelError("", "Invalid Login Attempt");

            }
            return View(lvm);
            
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }
    
        [HttpGet]
        public IActionResult EditProfile(string id)
        {
            if (id != null)
            {
                
                AspNetUsers anu = new AspNetUsers();

               anu = (from User in FOUDBC.AspNetUsers
                           where User.Id == id
                           select User).FirstOrDefault();
                return View(anu);
            }

            return View();
        }

        [HttpPost]
        public IActionResult EditProfile(AspNetUsers anu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FOUDBC.AspNetUsers.Update(anu);
                    FOUDBC.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to edit the fruit record." +
                    "Please try again, and if the problem persists," +
                    "Please see your system administrator");
            }

            return View(anu);
        }
    }
}