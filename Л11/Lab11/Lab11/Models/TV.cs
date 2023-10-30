namespace Lab11.Models;

public class TV : BaseEntity
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }

    public TVPrice TVPrice { get; set; }
    public Guid TVPriceId { get; set; }
}
