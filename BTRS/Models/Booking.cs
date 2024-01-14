using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class Booking
    {
             
        public int Id { get; set; }

        public int TripID { get; set; }
        public int PassengerID { get; set; }
        public Trip ? Trip {get; set;}
        public Passenger ? Passenger { get; set; }


    }
}
