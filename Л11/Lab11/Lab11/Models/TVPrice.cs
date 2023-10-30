namespace Lab11.Models;

public class TVPrice : BaseEntity
{
    public TV TV { get; set; }
    public Guid TVId { get; set; }

    public Price Price { get; set; }
    public Guid PriceId { get; set; }

    public DateTime LastUpdated { get; set; }
}
