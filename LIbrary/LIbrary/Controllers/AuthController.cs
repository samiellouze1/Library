﻿using LIbrary.Data;
using LIbrary.Models;
using LIbrary.ViewModels.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LIbrary.Controllers
{
    public class AuthController: Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Login()
        {
            var loginvm = new LoginVM();
            return View(loginvm);

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (!ModelState.IsValid)
            {
                return (View(loginvm));
            }
            var user = await _userManager.FindByEmailAsync(loginvm.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginvm.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginvm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            TempData["Error"] = "Wrong Credentials! Try Again";
            return View(loginvm);
        }

        public IActionResult Register()
        {
            var response = new RegisterVM();

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registervm)
        {
            if (!ModelState.IsValid)
            {
                return View(registervm);
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(registervm.Email);
                if (user != null)
                {
                    TempData["Error"] = "This Email Address has already been taken!";
                    return View(registervm);
                }
                else
                {
                    if (registervm.Password != registervm.ConfirmationPassword)
                    {
                        TempData["Error"] = "Password and Confirmation Password are not the same!";
                        return View(registervm);
                    }
                    else
                    {
                        var newUser = new Reader()
                        {
                            Email = registervm.Email
                        };
                        var newUserResponse = await _userManager.CreateAsync(newUser, registervm.Password);
                        if (newUserResponse.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(newUser, UserRoles.Reader);
                            var result = await _signInManager.PasswordSignInAsync(newUser, registervm.Password, false, false);
                            if (result.Succeeded)
                            {
                                return RedirectToAction("Index", "Product");
                            }
                            else
                            {
                                TempData["Error"] = "There has been an error, please try again!";
                                return View(registervm);
                            }
                        }
                        else
                        {
                            return View(registervm);
                        }
                    }
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Product");
        }
    }
}
