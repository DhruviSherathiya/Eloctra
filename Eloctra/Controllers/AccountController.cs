using Eloctra.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Controllers
{
    public class AccountController : Controller
    {
        // Provided by Microsoft.AspNetCore.Identity
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //To impelement return function Task<IActionResult>
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //My model is valid or not
            if (ModelState.IsValid)
            {
                //Copy data fron RegisterViewModel to IdentityUser
                var user = new IdentityUser()
                {
                    UserName = model.Username,
                    Email = model.Email
                };

                //Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                //If user is successfully created, sign-in the user using
                //SignInManager and redirect to index action of ClassroomController
                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("UserName", model.Username);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("login", "account");
                }

                //If there are any errors, and then to the ModelState object
                //which will be displayed by the validation summary tag hhelper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("login", "account");
            /*return RedirectToPage("index");*/
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //If there is a return url then want to back the user to return url for this pass parameter
        public async Task<IActionResult> Login(LoginViewModel model, String returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("UserName", model.Username);
                   
                    
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "Product");
                    }
                }



                //Error
                ModelState.AddModelError(String.Empty, "Incorrect Username or Password.");
            }

            return View(model);
        }

       

    }
}