using Project.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.BL.DTOs;

public class TechnicianDTO
{
    [Display(Prompt = "FullName")]
    public string FullName { get; set; }
    [Display(Prompt = "Age")]

    public int Age { get; set; }
    [Display(Prompt = "Imageurl")]

    public string Imageurl { get; set; }
    [Display(Prompt = "ServiceId")]
    public int ServiceId { get; set; }

    
}
