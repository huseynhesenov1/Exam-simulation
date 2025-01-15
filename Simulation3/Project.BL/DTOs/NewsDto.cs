using Microsoft.AspNetCore.Http;
using Project.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.BL.DTOs
{
    public class NewsDto
    {
        [Required]
        [Display(Prompt = "ImageUrl")]  
        
        public IFormFile ImageUrl { get; set; }
        [Required]
        [Display(Prompt = "Desciption")]

        public string Desciption { get; set; }
        [Required]
        [Display(Prompt = "CatagoryId")]

        public int CatagoryId { get; set; }
    }
    public class NewsUpdateDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Prompt = "ImageUrl")]

        public IFormFile ImageUrl { get; set; }
        [Required]
        [Display(Prompt = "Desciption")]

        public string Desciption { get; set; }
        [Required]
        [Display(Prompt = "CatagoryId")]

        public int CatagoryId { get; set; }
    }
}
