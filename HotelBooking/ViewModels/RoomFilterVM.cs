using Entities.Concrete;
using HotelBooking.Helper;
using System.Collections.Generic;

namespace HotelBooking.ViewModels
{
    public class RoomFilterVM
    {
        public List<Room> Rooms { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public int? RoomTypeId { get; set; }
        public int? SortBy { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MaxAllPrice { get; set; }

    }
}
