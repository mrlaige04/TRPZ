using System;
using System.Collections.Generic;

namespace Lab9.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<MealComposition> MealCompositions { get; set; } = new List<MealComposition>();
}
