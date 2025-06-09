using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooBookingManager.Models
{
    /// <summary>
    /// Model stylisty tatuażu.
    /// </summary>
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
