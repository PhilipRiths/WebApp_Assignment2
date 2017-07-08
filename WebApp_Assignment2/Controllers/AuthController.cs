 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using GymBuddyWebApp.Data;
 using GymBuddyWebApp.Domain;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Identity;
 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 using Microsoft.AspNetCore.Mvc;
 using WebApp_Assignment2.ViewModels;

namespace WebApp_Assignment2.Controllers
{
    public class AuthController : Controller
    {
        private GymBuddyContext _context = new GymBuddyContext();
        private  SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;

   

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult>  Login()
        {
         
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ListAllPeople", "people");
            }
            return View();
        }

        public async Task<ActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Age = model.Age
                    
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            return RedirectToAction("Index", "Auth");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.Email,
                    vm.Password,
                    true, false);
                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("ListAllPeople", "people");
                }
                else
                {
                    return Redirect(returnUrl);
                }

            }

                ModelState.AddModelError("", "Username or password incorrect");

            }
            return Ok();
        }

    }
}