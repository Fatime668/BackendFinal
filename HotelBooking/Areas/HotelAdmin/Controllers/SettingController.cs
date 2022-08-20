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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Setting> settings = await _context.Settings.ToListAsync();
            return View(settings);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Setting setting)
        {
            if (!ModelState.IsValid) return View();
            if (setting.Photo != null)
            {
                if (setting.Photo.IsOkay(1))
                {
                    setting.Value = await setting.Photo.FileCreate(_env.WebRootPath, @"assets\images\logo");
                    await _context.Settings.AddAsync(setting);
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
                await _context.AddAsync(setting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            Setting existedSetting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            return View(existedSetting);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Setting setting)
        {
            if (!ModelState.IsValid) return View();
            Setting existedSetting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            if (setting.Photo != null)
            {
                if (!setting.Photo.IsOkay(1))
                {
                    string path = _env.WebRootPath + @"\assets\images\logo\" + existedSetting.Value;
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    existedSetting.Value = await setting.Photo.FileCreate(_env.WebRootPath, @"assets\images\logo");
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            existedSetting.Key = setting.Key;
            existedSetting.Value = setting.Value;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Detail(int id)
        {
            Setting existedSetting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            return View(existedSetting);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Setting existedSetting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            return View(existedSetting);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSetting(int id)
        {
            Setting existedSetting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            _context.Settings.Remove(existedSetting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
