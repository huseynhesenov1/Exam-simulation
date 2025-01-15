namespace Project.Core.Entities
{
    public class Catagory : BaseEntity
    {
        public string Title { get; set; }   
        public ICollection<News> News { get; set; }
    }
}
