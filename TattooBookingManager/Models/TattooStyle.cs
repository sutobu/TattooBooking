using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooBookingManager.Models
{
    /// <summary>
    /// Model stylu tatuażu.
    /// </summary>
    public class TattooStyle
    {
        /// <summary>
        /// Identyfikator stylu.
        /// </summary>
        public int StyleId { get; set; }

        /// <summary>
        /// Nazwa stylu tatuażu.
        /// </summary>
        public string StyleName { get; set; }

        /// <summary>
        /// Lista zapisów powiązanych z tym stylem.
        /// </summary>
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
