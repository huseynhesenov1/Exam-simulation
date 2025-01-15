namespace Project.Core.Entities
{
    public class News: BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Desciption { get; set; }
        public Catagory Catagory { get; set; }
        public int  CatagoryId { get; set; }
    }
}
