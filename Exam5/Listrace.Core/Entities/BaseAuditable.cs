namespace Listrace.Core.Entities
{
	public abstract class BaseAuditable
	{
		public DateTime CreateAt { get; set; }
		public DateTime? UpdateAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
