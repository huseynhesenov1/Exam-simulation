namespace Listrace.Core.Entities
{
	public class Place : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public double Rating { get; set; }
		public int RatingCount { get; set; }
		public Decimal OldPrice { get; set; }
		public Decimal NewPrice { get; set; }
		public string ImageUrl { get; set; }
		public Catagory Catagory { get; set; }
		public int CatagoryId { get; set; }
		public bool IsActive { get; set; }
	}
}
