using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooBookingManager.Models
{
    /// <summary>
    /// Model klienta studia tatuażu.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Identyfikator klienta.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Imię klienta.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nazwisko klienta.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Numer telefonu klienta.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Adres e-mail klienta.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Lista zapisów powiązanych z klientem.
        /// </summary>
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
