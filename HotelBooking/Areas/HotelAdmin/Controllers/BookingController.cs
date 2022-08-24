using DataAccess.Data;
using Entities.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BookingController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Booking> bookings = await _context.Bookings.Include(b=>b.AppUser).ToListAsync();
            return View(bookings);
        }
        public async Task<IActionResult> Accept(int id)
        {

            Booking existedbooking = await _context
                .Bookings
                .Where(s => s.Id == id)
                .Include(s=>s.AppUser)
                .Include(s=>s.Room)
                .FirstOrDefaultAsync();
            existedbooking.BookingStatusId=2;
            await _context.SaveChangesAsync();
            var price = (existedbooking.DepartureDate - existedbooking.ArrivalDate).Days * existedbooking.Room.Price;
            string content = $"Salam {existedbooking.AppUser.UserName} rezerviniz testiq edildi \n" +
                $"baslangic tarixi: {existedbooking.ArrivalDate.Date} \n" +
                $"Bitme tarixi: {existedbooking.DepartureDate.Date} \n" +
                $"Umumi mebleg: {price}$";
            SendMail(existedbooking.AppUser.Email,content);
            return RedirectToAction(nameof(Index));
        }
        [NonAction]
        public void SendMail(string email,string content)
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("fatimahasanzade307@gmail.com", "Sochi");
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Reserv testiqlendi";
            

            mail.Body = content;

            mail.IsBodyHtml = true;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("fatimahasanzade307@gmail.com", "igxdjuerhpzemddc");
            smtp.Send(mail);
        }

        
    }
}
