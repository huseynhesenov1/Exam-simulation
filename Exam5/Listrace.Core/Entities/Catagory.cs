namespace Listrace.Core.Entities
{
	public class Catagory : BaseEntity
	{
		public string Title { get; set; }	
		public ICollection<Place> Places { get; set; }
	}
}
