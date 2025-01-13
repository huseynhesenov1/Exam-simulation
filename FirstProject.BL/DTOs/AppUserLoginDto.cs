﻿using System.ComponentModel.DataAnnotations;

namespace FirstProject.BL.DTOs
{
    public class AppUserLoginDto
    {
        [Required]
        [Display(Prompt = "UserName")]
        public string UserName { get; set;  }
        [Required]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
