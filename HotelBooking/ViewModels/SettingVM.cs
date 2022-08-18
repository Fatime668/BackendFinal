using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.ViewModels
{
    public class SettingVM
    {
        public IEnumerable<Setting> Settings { get; set; }
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
    }
}
