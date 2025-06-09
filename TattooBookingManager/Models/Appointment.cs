using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooBookingManager.Models
{
    /// <summary>
    /// Model zapisu na sesję tatuażu.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Identyfikator zapisu.
        /// </summary>
        public int AppointmentId { get; set; }

        /// <summary>
        /// Identyfikator klienta.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Obiekt klienta powiązany z zapisem.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Identyfikator artysty.
        /// </summary>
        public int ArtistId { get; set; }

        /// <summary>
        /// Obiekt artysty wykonującego tatuaż.
        /// </summary>
        public Artist Artist { get; set; }

        /// <summary>
        /// Identyfikator stylu tatuażu.
        /// </summary>
        public int StyleId { get; set; }

        /// <summary>
        /// Styl tatuażu wybrany na sesję.
        /// </summary>
        public TattooStyle Style { get; set; }

        /// <summary>
        /// Data i godzina sesji.
        /// </summary>
        public DateTime AppointmentDateTime { get; set; }

        /// <summary>
        /// Czas trwania sesji w minutach.
        /// </summary>
        public int Duration { get; set; }
    }
}
