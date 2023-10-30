using System;
using System.Collections.Generic;

namespace Lab9.Models;

public partial class Position
{
    public int PositionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
