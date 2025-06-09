using System.Collections.Generic;

namespace TattooBookingManager.Models
{
    public class TattooStyle
    {
        public int StyleId { get; set; }
        public string StyleName { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
    }
}