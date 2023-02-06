using Inta.Turizm.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inta.Turizm.Business.DataContext
{
    public class DefaultDataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DefaultDataContext()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultDataContext"));
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

             modelBuilder.Entity<Hotel>()
            .HasMany<HotelImage>(g => g.HotelImages)
            .WithOne(s => s.CurrentHotel)
            .HasForeignKey(s => s.HotelId);
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }



    }

}
