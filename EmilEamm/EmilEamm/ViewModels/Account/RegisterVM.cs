using System.ComponentModel.DataAnnotations;

namespace EmilEamm.ViewModels.Account
{
    public class RegisterVM
    {
        [Required,MinLength(3,ErrorMessage ="minimal uzunlug 3"),MaxLength(32,ErrorMessage ="maksimal uzunlug 32")]
        public string Username { get; set; }
        [Required, MinLength(3, ErrorMessage = "minimal uzunlug 3"), MaxLength(32, ErrorMessage = "maksimal uzunlug 32")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
        [Required, MinLength(3, ErrorMessage = "minimal uzunlug 3"), MaxLength(32, ErrorMessage = "maksimal uzunlug 32")]
        public string Name { get; internal set; }
        [Required, MinLength(3, ErrorMessage = "minimal uzunlug 3"), MaxLength(32, ErrorMessage = "maksimal uzunlug 32")]
        public string Surname { get; internal set; }
    }
}
