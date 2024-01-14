using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    [Index(nameof(Trip.BusNumber), IsUnique = true)]

    public class Trip
    {
        [Key]
        public int TripID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BusNumber { get; set; }
        public string TripDis {  get; set; }
        public Bus ? Bus { get; set; }
        public int ? BusID { get; set; }

        public ICollection<Booking> ? Bookings { get; set; }
    }
}
