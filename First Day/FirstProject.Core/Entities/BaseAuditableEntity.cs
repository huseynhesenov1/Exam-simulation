namespace FirstProject.Core.Entities;

public abstract class BaseAuditableEntity
{
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? CreateBy { get; set; }
    public string? UpdateBy { get; set; }
    public string? DeletedBy { get; set; }
}
