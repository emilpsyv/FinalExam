using System.ComponentModel.DataAnnotations;

namespace EmilEamm.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        public string UserNameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
