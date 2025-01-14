namespace Project.Core.Entities
{
    public class Service:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Technician> Technicians { get; set; }
    }
}
