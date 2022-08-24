using DataAccess.Data;
using Entities.Concrete;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    //[AllowAnonymous]

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new AppUser
            {
                UserName = register.Username,
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber
                
            };
            if (!register.TermCondition)
            {
                ModelState.AddModelError("", "Please accept term and condition");
                return View();
            }
            if (register.Password == register.ConfirmPassword)
            {
                IdentityResult result = await _userManager.CreateAsync(user, register.Password);
                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
                
            }

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string link = Url.Action(nameof(VerifyEmail), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("fatimahasanzade307@gmail.com", "Sochi");
            mail.To.Add(new MailAddress(user.Email));
            mail.Subject = "Verify Email";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/assets/template/verifyemail.html"))
            {
                body = reader.ReadToEnd();
            }
            string about = $"Hi <strong>{user.Firstname + " " + user.Lastname}</strong> In order to start using your  account, you need to confirm your email address.";

            body = body.Replace("{{link}}", link);
            mail.Body = body.Replace("{{About}}", about);

            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("fatimahasanzade307@gmail.com", "igxdjuerhpzemddc");
            smtp.Send(mail);
            TempData["Verify"] = true;

            await _userManager.AddToRoleAsync(user, Roles.Member.ToString());

            //await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> VerifyEmail(string email,string token)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();
            await _userManager.ConfirmEmailAsync(user, token);
            await _signInManager.SignInAsync(user, true);
            TempData["Verified"] = true;

            return RedirectToAction("Index","Home");
        }
        public IActionResult ForgotPassword()
        {
            
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ForgotPassword(AccountVM account)
        {
            if (!ModelState.IsValid) return View();
            
            AppUser user = await _userManager.FindByEmailAsync(account.AppUser.Email);
            if (user == null) return BadRequest();
            TempData["ForgotPassword"] = true;
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action(nameof(ResetPassword),"Account",new {email = user.Email,token },Request.Scheme,Request.Host.ToString());
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("fatimahasanzade307@gmail.com", "Sochi");
            mail.To.Add(new MailAddress(user.Email));
            mail.Subject = "Reset Password";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/assets/template/resedpassword.html"))
            {
                body = reader.ReadToEnd();
            }

            mail.Body = body.Replace("{{link}}", link);

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("fatimahasanzade307@gmail.com", "igxdjuerhpzemddc");
            smtp.Send(mail);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> ResetPassword(string email,string token)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();
            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = token
            };
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ResetPassword(AccountVM account)
        {
            AppUser user = await _userManager.FindByEmailAsync(account.AppUser.Email);

            AccountVM model = new AccountVM
            {
                AppUser = user,
                Token = account.Token
            };
            if (ModelState.IsValid) return View(model);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, account.Token, account.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
            TempData["PasswordResed"] = true;

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(login.Username);
            if (user == null) return View();
            IList<string> roles = await _userManager.GetRolesAsync(user);
            string role = roles.FirstOrDefault(r => r.Trim().ToLower() == Roles.Member.ToString().ToLower().Trim());
            if (role==null)
            {
                ModelState.AddModelError("", "Something went wrong.Please contact with admins");
                return View();
            }
            else
            {
                if (user.IsBlock==false)
                {
                    if (login.RememberMe)
                    {
                        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
                        if (!result.Succeeded)
                        {
                            if (result.IsLockedOut)
                            {
                                ModelState.AddModelError("", "Due to overtrying you have been blocked about 10 minutes");
                                return View();
                            }
                            ModelState.AddModelError("", "Username or password is incorrect");
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
                                ModelState.AddModelError("", "You have been for dismissed 5 minutes");
                                return View();
                            }
                            ModelState.AddModelError("", "Username or password is incorrect");
                            return View();
                        }
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Your access to this page is prohibited!");
                    return View();
                }
                
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            EditVM userEdit = new EditVM();
            userEdit.firstname = user.Firstname;
            userEdit.lastname = user.Lastname;
            userEdit.phonenumber = user.PhoneNumber;
            userEdit.email = user.Email;
            return View(userEdit);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditVM editVM)
        {
            AppUser existeduser = await _userManager.FindByNameAsync(User.Identity.Name);
            EditVM edit = new EditVM
            {
                firstname = existeduser.Firstname,
                lastname = existeduser.Lastname,
                phonenumber = existeduser.PhoneNumber,
                email = existeduser.Email,
                username = existeduser.UserName
            };

            if (!ModelState.IsValid) return View(edit);
            bool result = editVM.password == null && editVM.confirmpassword == null && editVM.currentpassword != null;
            if (editVM.email == null || editVM.email != existeduser.Email)
            {
                ModelState.AddModelError("", "You can not change your email");
                return View(edit);
            }
            if (result)
            {
                existeduser.UserName = editVM.username;
                existeduser.Firstname = editVM.firstname;
                existeduser.Lastname = editVM.lastname;
                existeduser.PhoneNumber = editVM.phonenumber;
                await _userManager.UpdateAsync(existeduser);
            }
            else
            {
                existeduser.UserName = editVM.username;
                existeduser.Firstname = editVM.firstname;
                existeduser.Lastname = editVM.lastname;
                existeduser.PhoneNumber = editVM.phonenumber;

                if (editVM.currentpassword == editVM.password)
                {
                    ModelState.AddModelError("", "You can not change password with the same password");
                    return View();
                }
                IdentityResult resultEdit = await _userManager.ChangePasswordAsync(existeduser, editVM.currentpassword, editVM.password);
                if (!resultEdit.Succeeded)
                {
                    foreach (IdentityError error in resultEdit.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(edit);
                }
            }
            TempData["EditPassword"] = true;
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Show()
        {
            return Content(User.Identity.IsAuthenticated.ToString());
        }
        public async Task CreateRoles()
        {
            await _roleManager.CreateAsync(new  IdentityRole {Name =  Roles.Member.ToString() });
            await _roleManager.CreateAsync(new  IdentityRole {Name =  Roles.Admin.ToString() });
            await _roleManager.CreateAsync(new  IdentityRole {Name = Roles.SuperAdmin.ToString() });
        }
        
    }
}
