using System.ComponentModel.DataAnnotations;

namespace Project.BL.DTOs
{
    public class AppUserLoginDto
    {
        [Display(Prompt = "UserName")]
        [Required]
        public string UserName { get; set; }
        [Display(Prompt = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}