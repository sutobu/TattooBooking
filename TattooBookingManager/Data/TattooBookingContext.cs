using System.Data.Entity;
using TattooBookingManager.Models;

namespace TattooBookingManager.Data
{
    public class TattooBookingContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<TattooStyle> TattooStyles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public TattooBookingContext() : base("name=TattooBookingContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TattooStyle>().HasKey(ts => ts.StyleId);
            modelBuilder.Entity<Client>().HasKey(c => c.ClientId);
            modelBuilder.Entity<Artist>().HasKey(a => a.ArtistId);
            modelBuilder.Entity<Appointment>().HasKey(a => a.AppointmentId);

            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Client)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.ClientId);

            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Artist)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Style)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.StyleId);
        }
    }
}