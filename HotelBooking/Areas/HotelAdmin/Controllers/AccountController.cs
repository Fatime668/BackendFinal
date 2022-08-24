﻿using DataAccess.Data;
using Entities.Concrete;
using HotelBooking.Areas.HotelAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> appUsers = await _context.AppUser.ToListAsync();
            return View(appUsers);
        }
        public async Task<IActionResult> Edit(string id)
        {
            AppUser existedUser = await _context.AppUser.FirstOrDefaultAsync(a => a.Id == id);
            if (existedUser == null) return NotFound();

            return View(existedUser);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(AppUser appUser)
        {
            if (!ModelState.IsValid) return View();
            AppUser existedUser = await _context.AppUser.FirstOrDefaultAsync(s => s.Id == appUser.Id);
            if (existedUser == null) return NotFound();

            existedUser.UserName = appUser.UserName;
            existedUser.Firstname = appUser.Firstname;
            existedUser.Lastname = appUser.Lastname;
            if (appUser.IsBlock == true)
            {
                await _signInManager.SignOutAsync();
                existedUser.IsBlock = true;
            }
            else if (appUser.IsBlock == false)
            {
                existedUser.IsBlock = true;
            }
            existedUser.IsBlock = appUser.IsBlock;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(AdminLoginVM login)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(login.Username);
            if (user == null) return View();
            IList<string> roles = await _userManager.GetRolesAsync(user);
            string adminRole = roles.FirstOrDefault(r => r.Trim().ToLower() == Roles.Admin.ToString().ToLower().Trim());
            string superAdminRole = roles.FirstOrDefault(r => r.Trim().ToLower() == Roles.SuperAdmin.ToString().ToLower().Trim());
            if (adminRole == null && superAdminRole == null)
            {
                ModelState.AddModelError("", "Something went wrong. Please try again");
                return View();
            }
            else
            {
                if (login.RememberMe)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);

                    if (!result.Succeeded)
                    {
                        if(result.IsLockedOut)
                        {
                            ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                            return View();
                        }
                        ModelState.AddModelError("", "Username or Password is incorrect");
                        return View();
                    }
                }
                else
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, false, true);
                    if (!result.Succeeded)
                    {
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                            return View();
                        }
                        ModelState.AddModelError("", "Username or Password is incorrect");
                        return View();
                    }
                }
                return RedirectToAction("Index", "Dashboard");
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //Create Admin
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Email = "tu7dkjdue@code.edu.az",
        //        UserName = "fatimacode",
        //        Firstname = "Fatima",
        //        Lastname = "Hasanzade",
        //        PhoneNumber = "0555555555",
        //        EmailConfirmed = true,
        //        IsAdmin = true,
        //    };
        //    await _userManager.CreateAsync(appUser, "fatima123a");
        //    await _userManager.AddToRoleAsync(appUser, Roles.SuperAdmin.ToString());
        //    return Content("Super Admin Was Successfully Created");
        //}
    }
}