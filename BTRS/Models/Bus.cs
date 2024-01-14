using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    [Index(nameof(Bus.CaptinName), IsUnique = true)]

    public class Bus
    {
        [Key]
        public int BusID { get; set; }

        public string CaptinName { get; set; }

        public int NumberOfSeets { get; set; }
        public Trip ? Trip { get; set; } //

    }
}
