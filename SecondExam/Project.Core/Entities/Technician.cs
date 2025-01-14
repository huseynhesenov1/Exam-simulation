namespace Project.Core.Entities
{
    public class Technician :  BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Imageurl { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
