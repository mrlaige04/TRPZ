using System.ComponentModel.DataAnnotations;

namespace Lab12.Models.MVC.Request;

public class CreateTVModel
{
    [Required] public string Name { get; set; }
    [Required] public string Brand { get; set; }
    public string? Model { get; set; }

    [Required] public decimal Price { get; set; }
    [Required] public string Currency { get; set; }
}
