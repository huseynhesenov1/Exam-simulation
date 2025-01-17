using Listrace.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Listrace.BL.DTOs
{
	public class PlaceDto
	{
		[Required]
		[MinLength(5)]
		[Display(Prompt = "Title")]
		public string Title { get; set; }
		[Display(Prompt = "Description")]
		[Required]

		public string Description { get; set; }
		[Display(Prompt = "Rating")]
		[Required]

		public double Rating { get; set; }
		[Display(Prompt = "RatingCount")]
		[Required]

		public int RatingCount { get; set; }
		[Display(Prompt = "OldPrice")]
		[Required]

		public Decimal OldPrice { get; set; }
		[Display(Prompt = "NewPrice")]
		[Required]

		public Decimal NewPrice { get; set; }
		[Display(Prompt = "ImageUrl")]
		[Required]

		public IFormFile ImageUrl { get; set; }
		[Display(Prompt = "CatagoryId")]
		[Required]

		public int CatagoryId { get; set; }
		
	}
}