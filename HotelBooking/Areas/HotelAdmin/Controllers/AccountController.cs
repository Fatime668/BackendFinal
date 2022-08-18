using DataAccess.Data;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
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
            AppUser existedUser = await _context.AppUser.FirstOrDefaultAsync(a=>a.Id==id);
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
            existedUser.Firstname=appUser.Firstname;
            existedUser.Lastname = appUser.Lastname;
            if (appUser.IsBlock==true)
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
    }
}
