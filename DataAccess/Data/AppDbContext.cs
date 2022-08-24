using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Setting
            modelBuilder.Entity<Setting>().HasData(
                new Setting { Id = 1, Key = "HeaderWhiteLogo", Value = "logo-white.svg" },
                new Setting { Id = 2, Key = "HeaderBlackLogo", Value = "logo-black.svg" },
                new Setting { Id = 3, Key = "StreetAddress", Value = "23400 S Western Ave," },
                new Setting { Id = 4, Key = "CityAddress", Value = "Harbor City, CA 90710" },
                new Setting { Id = 5, Key = "ContactEmail", Value = "hello@example.com" },
                new Setting { Id = 6, Key = "ContactPhone", Value = "+1 514.123.4567" },
                new Setting { Id = 7, Key = "HeaderTitle", Value = "Feeling cool like your favorite place." },
                new Setting { Id = 8, Key = "HeaderSubtitle", Value = "WELCOME TO SOCHI HOTEL" },
                new Setting { Id = 9, Key = "VideoLink", Value = "https://www.youtube.com/embed/HSsqzzuGTPo" },
                new Setting { Id = 10, Key = "VieoNote", Value = "Start your amazing journey." },
                new Setting { Id = 11, Key = "AboutTitle", Value = "About Sochi." },
                new Setting { Id = 12, Key = "AboutSubTitle", Value = "WELCOME TO SOCHI HOTEL" },
                new Setting { Id = 13, Key = "AboutLeftImage", Value = "about_image_01.jpg" },
                new Setting { Id = 14, Key = "AboutRightImage", Value = "about_image_02.jpg" },
                new Setting { Id = 15, Key = "QuestionEmail", Value = "hello@hotelsochi.com" },
                new Setting { Id = 16, Key = "AboutPartnerEmail", Value = "partners@hotelsochi.com" },
                new Setting { Id = 17, Key = "SpaOffers", Value = "32" },
                new Setting { Id = 18, Key = "Rooms", Value = "3" },
                new Setting { Id = 19, Key = "Beaches", Value = "7" },
                new Setting { Id = 20, Key = "HappyClients", Value = "10" });
            #endregion
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Approach> Approaches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomPicture> RoomPictures { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmentiy> RoomAmentiys { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
    }
}
