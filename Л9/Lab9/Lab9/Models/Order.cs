using System;
using System.Collections.Generic;

namespace Lab9.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int BillId { get; set; }

    public int MealId { get; set; }

    public int MealCount { get; set; }

    public virtual Bill Bill { get; set; } = null!;

    public virtual Meal Meal { get; set; } = null!;
}
