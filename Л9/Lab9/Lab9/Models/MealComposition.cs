using System;
using System.Collections.Generic;

namespace Lab9.Models;

public partial class MealComposition
{
    public int MealCompositionId { get; set; }

    public int ProductId { get; set; }

    public int MealId { get; set; }

    public double Count { get; set; }

    public string Measure { get; set; } = null!;

    public virtual Meal Meal { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
