namespace Lab12.Models.EF;

public class Price : BaseEntity
{
    public decimal Value { get; set; }
    public string Currency { get; set; }
    public DateTime LastUpdated { get; set; }

    public TVPrice TVPrice { get; set; }
    public Guid TVPriceId { get; set; }
}