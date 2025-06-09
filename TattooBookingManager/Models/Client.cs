using System.Collections.Generic;

namespace TattooBookingManager.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
    }
}