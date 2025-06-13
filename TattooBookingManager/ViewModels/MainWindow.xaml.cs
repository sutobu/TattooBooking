using System;
using System.Windows;
using TattooBookingManager.Data;
using TattooBookingManager.Models;
using Microsoft.EntityFrameworkCore;

namespace TattooBookingManager.ViewModels
{
    public partial class MainWindow : Window
    {
        private readonly TattooBookingContext _context;

        public MainWindow()
        {
            InitializeComponent();
            var options = new DbContextOptionsBuilder<TattooBookingContext>()
                .UseSqlite("Data Source=tattoo_booking.db")
                .Options;
            _context = new TattooBookingContext(options);
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _context.Database.EnsureCreated();

            if (!_context.Clients.Any())
            {
                var client = new Client
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Phone = "1234567890",
                    Email = "john@example.com"
                };
                _context.Clients.Add(client);
            }

            if (!_context.Artists.Any())
            {
                var artist = new Artist
                {
                    Name = "Artist One",
                    Specialization = "Traditional"
                };
                _context.Artists.Add(artist);
            }

            if (!_context.TattooStyles.Any())
            {
                var style = new TattooStyle
                {
                    StyleName = "Realism"
                };
                _context.TattooStyles.Add(style);
            }

            if (!_context.Appointments.Any())
            {
                var appointment = new Appointment
                {
                    ClientId = 1,
                    ArtistId = 1,
                    StyleId = 1,
                    AppointmentDateTime = DateTime.Now.AddDays(1),
                    Duration = 60
                };
                _context.Appointments.Add(appointment);
            }

            _context.SaveChanges();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}