using System;
using System.Collections.Generic;

namespace Lab9.Models;

public partial class Meal
{
    public int MealId { get; set; }

    public string Name { get; set; } = null!;

    public double Volume { get; set; }

    public string Measure { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<MealComposition> MealCompositions { get; set; } = new List<MealComposition>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
