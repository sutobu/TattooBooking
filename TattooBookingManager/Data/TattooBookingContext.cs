using Microsoft.EntityFrameworkCore;
using TattooBookingManager.Models;

namespace TattooBookingManager.Data
{
    public class TattooBookingContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<TattooStyle> TattooStyles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tattoo_booking.db");
        }
    }
}