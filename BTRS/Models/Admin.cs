using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models

{
    [Index(nameof(Admin.UserName), IsUnique = true)]

    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
