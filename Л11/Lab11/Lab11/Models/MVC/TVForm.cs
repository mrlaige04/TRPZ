namespace Lab11.Models.MVC;

public class TVForm
{
    public bool IsEditMode { get; set; } = false;
    public TvViewModel Tv { get; set; }
}

public record TvViewModel(Guid Id, string Name, string Brand, string Model, decimal Price, string Currency);
