using System;
using System.Collections.Generic;

namespace TattooBookingManager.Models
{
    /// <summary>
    /// Represents an appointment for a tattoo session.
    /// </summary>
    public class Appointment
    {
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

    /// <summary>
    /// Represents a tattoo artist.
    /// </summary>
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
    }

    /// <summary>
    /// Represents a client booking a tattoo.
    /// </summary>
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
        public string FullName => $"{FirstName} {LastName}";
    }

    /// <summary>
    /// Represents a tattoo style.
    /// </summary>
    public class TattooStyle
    {
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
    }
}