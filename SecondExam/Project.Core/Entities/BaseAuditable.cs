namespace Project.Core.Entities
{
    public abstract class BaseAuditable
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set;}
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public string? DeleteBy { get; set; }
    }
}
