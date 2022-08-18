using DataAccess.Data;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.Include("RoomPictures").Include("RoomAmentiys.Amenity").Include("Bookings").ToListAsync();
        }
        public async Task<Room> GetRoomById(int id)
        {
            return await _context.Rooms.Include("RoomPictures").Include("RoomAmentiys.Amenity").Include("Bookings").FirstOrDefaultAsync(r => r.Id == id);
        }
        public int FindRoomMaxPrice()
        {
            int maxPrice = Convert.ToInt32(_context.Rooms.Max(x => x.Price));
            return maxPrice;
        }
        public List<Room> SearchRoomFilter(int? roomTypeId,int? minPrice,int? maxPrice,int? sortBy)
        {
            IQueryable<Room> rooms = _context.Rooms.AsQueryable();
            if (roomTypeId.HasValue)
            {
                rooms = rooms.Where(r => r.RoomTypeId == roomTypeId);
            }
            if (minPrice.HasValue && maxPrice.HasValue)
            {
                rooms = rooms.Where(r => r.Price >= minPrice && r.Price <= maxPrice);
            }
            if (sortBy.HasValue)
            {
                switch (sortBy)
                {
                    case 1:
                        rooms = rooms.OrderByDescending(x => x.Price);
                        break;
                    case 2:
                        rooms = rooms.OrderBy(x => x.Price);
                        break;
                    case 3:
                        rooms = rooms.OrderBy(x => x.Id);
                        break;
                    case 4:
                        rooms = rooms.OrderByDescending(x => x.Id);
                        break;  
                    default:
                        break;
                }
            }

            return rooms.Include("RoomPictures").ToList();
        }
        public async Task<List<RoomType>> GetTypes()
        {
            return await _context.RoomTypes.Include(r=>r.Rooms).ToListAsync();
        }
        public async Task<RoomType> GetRoomTypeById(int id)
        {
            return await _context.RoomTypes.FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<List<Amenity>> GetAmenity()
        {
            return await _context.Amenities.ToListAsync();
        }
        public async Task<Amenity> GetAmenityById(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => a.Id == id);
        }
       
    }
}
