using System.ComponentModel.DataAnnotations;

namespace Listrace.BL.DTOs
{
    public class AppUserDto
    {
        [Required]
        [Display(Prompt= "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Prompt = "LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(Prompt = "UserName")]
        public string UserName { get; set; }
        [Required]
        [Display(Prompt = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Prompt = "PasswordConfirmed")]
        [DataType(DataType.Password)]
        public string PasswordConfirmed { get; set; }
    }
}