using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TattooBookingManager.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int StyleId { get; set; }
        public TattooStyle Style { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int Duration { get; set; }
    }

    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
    }

    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
        public string FullName => $"{FirstName} {LastName}";
    }

    public class TattooStyle
    {
        [Key]
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
    }
}