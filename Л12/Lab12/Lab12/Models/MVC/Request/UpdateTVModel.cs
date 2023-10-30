namespace Lab12.Models.MVC.Request;

public class UpdateTVModel
{
    public string? Name { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }

    public decimal? Price { get; set; }
    public string? Currency { get; set; }
}
