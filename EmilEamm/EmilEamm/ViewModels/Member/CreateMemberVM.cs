using System.ComponentModel.DataAnnotations;

namespace EmilEamm.ViewModels.Member
{
    public class CreateMemberVM
    {
        [MinLength(3,ErrorMessage ="minimal uzunlug 3 simvol"),MaxLength(32,ErrorMessage ="maksimal uzunlug 32 simvoldur"),Required]
        public string FullName { get; set; }
        [MinLength(2, ErrorMessage = "minimal uzunlug 3 simvol"), MaxLength(128, ErrorMessage = "maksimal uzunlug 128 simvoldur"),Required]
        public string JobTitle { get; set; }
        [MinLength(3, ErrorMessage = "minimal uzunlug 3 simvol"), MaxLength(128, ErrorMessage = "maksimal uzunlug 128 simvoldur"),Required]
        public string Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
