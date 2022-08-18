using DataAccess.Data;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            Contact contact = await _context.Contacts.FirstOrDefaultAsync();

            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (!ModelState.IsValid) return View();
            await _context.AddAsync(contact);
            await _context.SaveChangesAsync();
            TempData["SendMail"] = true;
            return RedirectToAction(nameof(Index));
        }
    }
}
