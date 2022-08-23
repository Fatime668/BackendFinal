using DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeleteController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<string> DeleteReserv()
        {
            var bookings = await _context.Bookings.ToListAsync();
            _context.Bookings.RemoveRange(bookings);
            await _context.SaveChangesAsync();
            return "okey";
        }
    }
}
