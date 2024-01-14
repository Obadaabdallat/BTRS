using Microsoft.EntityFrameworkCore;

namespace BTRS.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <Trip> trips { get; set; }
        public DbSet <Admin> admains { get; set; }
        public DbSet <Bus> buses { get; set; }
        public DbSet <Passenger> passengers { get; set; }
        public DbSet <Booking > bookings { get; set; }

    }
}
