using DataAccess.Data;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Contact> contacts = await _context.Contacts.ToListAsync();
            return View(contacts);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync(s => s.Id == id);
            if (contact == null) return NotFound();
           
            return View(contact);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync(s => s.Id == id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
