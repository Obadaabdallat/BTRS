using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please fill the username")]
        public string username { set; get; }

        [Required(ErrorMessage = "Please fill the password")]
        public string password { set; get; }
    }
}
