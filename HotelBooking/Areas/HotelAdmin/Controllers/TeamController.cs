using DataAccess.Data;
using Entities.Concrete;
using HotelBooking.Extensions;
using HotelBooking.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Team> teams = await _context.Teams.ToListAsync();
            return View(teams);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Team team)
        {
            if (!ModelState.IsValid) return View();
            if (team.Photo != null)
            {
                if (team.Photo.IsOkay(1))
                {
                    team.Image = await team.Photo.FileCreate(_env.WebRootPath, @"assets\images\team");
                    await _context.Teams.AddAsync(team);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa 1 mb-n altinda sekil daxil edin");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Photo", "Zehmet olmasa sekil secin");
                return View();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            Team exitesTeam = await _context.Teams.FirstOrDefaultAsync(s => s.Id == id);
            if (exitesTeam == null) return NotFound();
            return View(exitesTeam);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Team team)
        {
            if (!ModelState.IsValid) return View();
            Team exitestedTeam = await _context.Teams.FirstOrDefaultAsync(e => e.Id == id);
            if (team.Photo != null)
            {
                if (team.Photo.IsOkay(1))
                {
                    string path = _env.WebRootPath + @"\assets\images\team\" + exitestedTeam.Image;
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    exitestedTeam.Image = await team.Photo.FileCreate(_env.WebRootPath, @"assets\images\team");
                    exitestedTeam.Name = team.Name;
                    exitestedTeam.Position = team.Position;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Photo", "Zehmet olmasa 1 mb-n altinda sekil daxil edin");
                    return View();
                }
            }
            exitestedTeam.Name = team.Name;
            exitestedTeam.Position = team.Position;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int id)
        {
            Team team = await _context.Teams.FirstOrDefaultAsync(e => e.Id == id);
            return View(team);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Team existedTeam = await _context.Teams.FirstOrDefaultAsync(e => e.Id == id);
            return View(existedTeam);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            Team team = await _context.Teams.FirstOrDefaultAsync(p => p.Id == id);
            string path = _env.WebRootPath + @"\assets\images\team" + team.Image;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
