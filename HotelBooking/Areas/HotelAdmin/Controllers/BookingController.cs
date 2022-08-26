using ClosedXML.Excel;
using DataAccess.Data;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using X.PagedList;

namespace HotelBooking.Areas.HotelAdmin.Controllers
{
    [Area("HotelAdmin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BookingController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            List<Booking> bookings = await _context.Bookings
                .Include(b => b.AppUser)
                .Include(b=>b.Status)
                .Where(b=>b.Status.Status != "Delete")
                .ToListAsync();
            return View(bookings.ToPagedList(page, 5));
        }
        //AcceptReservation

        public async Task<IActionResult> Accept(int id)
        {
            Booking existedbooking = await _context
                .Bookings
                .Where(s => s.Id == id)
                .Include(s => s.Room)
                .FirstOrDefaultAsync();
            existedbooking.BookingStatusId = 2;
            await _context.SaveChangesAsync();
            

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/admin/reservcomfirmed/index.html"))
            {
                body = reader.ReadToEnd();
            }

            var price = (existedbooking.DepartureDate - existedbooking.ArrivalDate).Days * existedbooking.Room.Price;
            var user = existedbooking.AppUser.Firstname + " " + existedbooking.AppUser.Lastname;
            var startdate = existedbooking.ArrivalDate.Date;
            var enddate = existedbooking.DepartureDate.Date;
            var adult = existedbooking.Adults;
            var children = existedbooking.Children;

            body = body.Replace("{{price}}", price.ToString());
            body = body.Replace("{{user}}", user);
            body = body.Replace("{{startdate}}", startdate.ToString());
            body = body.Replace("{{enddate}}", enddate.ToString());
            body = body.Replace("{{adult}}", adult.ToString());
            body = body.Replace("{{children}}", children.ToString());

            SendMail(existedbooking.AppUser.Email, body);
            return RedirectToAction(nameof(Index));
        }
        //CancelReservation
        public async Task<IActionResult> Cancel(int id)
        {
            Booking existedbooking = await _context
               .Bookings
               .Where(s => s.Id == id)
               .Include(s => s.AppUser)
               .Include(s => s.Room)
               .FirstOrDefaultAsync();
            existedbooking.BookingStatusId = 2;
            string body = string.Empty;
            CancelSendMail(existedbooking.AppUser.Email, body);
            return RedirectToAction(nameof(Index));
        }


        //DeleteReservation
        public async Task<IActionResult> Delete(int id)
        {
            Booking existedbooking = await _context
                .Bookings
                .Where(s => s.Id == id)
                .Include(s => s.AppUser)
                .Include(s => s.Room)
                .FirstOrDefaultAsync();
            existedbooking.BookingStatusId = 3;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        [NonAction]
        public void CancelSendMail(string email, string body)
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("fatimahasanzade954@gmail.com", "Sochi");
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Reservasiyaniz legv olundu!";



            mail.Body = body;

            mail.IsBodyHtml = true;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("fatimahasanzade954@gmail.com", "rjyrdjhayyzmywez");
            smtp.Send(mail);
        }
        [NonAction]
        public void SendMail(string email, string body)
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("fatimahasanzade954@gmail.com", "Sochi");
            mail.To.Add(new MailAddress(email));
            mail.Subject = "Reserviniz testiq olundu!";



            mail.Body = body;

            mail.IsBodyHtml = true;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("fatimahasanzade954@gmail.com", "rjyrdjhayyzmywez");
            smtp.Send(mail);
        }


        #region Export Excel

        public async Task<IActionResult> ExportToExcelToday()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reservations");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Firstname";
                worksheet.Cell(currentRow, 3).Value = "LastName";
                worksheet.Cell(currentRow, 4).Value = "PhoneNumber";
                worksheet.Cell(currentRow, 5).Value = "Email";
                worksheet.Cell(currentRow, 6).Value = "Room";
                worksheet.Cell(currentRow, 7).Value = "ReservDate";
                worksheet.Cell(currentRow, 8).Value = "ReservEndDate";
                worksheet.Cell(currentRow, 9).Value = "Status";

                worksheet.Cell(currentRow, 1).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 2).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 3).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 4).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 5).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 6).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 7).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 8).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 9).Style.Fill.SetBackgroundColor(XLColor.LightGray);


                foreach (var report in (await _context.Bookings
                    .Include(p => p.AppUser)
                    .Include(p => p.Status)
                    .Include(p => p.Room).ToListAsync()))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = report.Id;
                    worksheet.Cell(currentRow, 2).Value = report.AppUser.Firstname;
                    worksheet.Cell(currentRow, 3).Value = report.AppUser.Lastname;
                    worksheet.Cell(currentRow, 4).Value = report.AppUser.PhoneNumber;
                    worksheet.Cell(currentRow, 5).Value = report.AppUser.Email;
                    worksheet.Cell(currentRow, 6).Value = report.RoomId;
                    worksheet.Cell(currentRow, 7).Value = report.ArrivalDate;
                    worksheet.Cell(currentRow, 8).Value = report.DepartureDate;

                    worksheet.Cell(currentRow, 9).Value = report.Status.Status;


                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"Booking_{DateTime.Now.ToString()}.xlsx");
                }
            }
            #endregion

        }
    }
}
