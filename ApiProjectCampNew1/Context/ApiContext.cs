using ApiProjectCampNew1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectCampNew1.Context
{
   
        public class ApiContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=GOKAY\\SQLEXPRESS;initial catalog = ApiYummyDb;integrated security=true;");
            }
            public DbSet<Category> Categories { get; set; } //Soldaki isim studioda olan isim sağdaki isim sql yansıcak isim
            public DbSet<Chef> Chef { get; set; }
            public DbSet<Contact> Contacts { get; set; }
            public DbSet<Feature> Features { get; set; }
            public DbSet<Image> Images { get; set; }
            public DbSet<Message> Messages { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Reservation> Reservations { get; set; }
            public DbSet<Service> services { get; set; }
            public DbSet<Testimonial> Testimonials { get; set; }
        }
}
