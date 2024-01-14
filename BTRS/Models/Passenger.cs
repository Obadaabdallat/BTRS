using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models

{
    [Index(nameof(Passenger.UserName), IsUnique = true)]

    public class Passenger
    {
        [Key]
        public int PassengerID { get; set; }

        public string Name { get; set; }    
        public string Email { get; set; }
        public string Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<Booking> ? Bookings { get; set; }

    }
}
