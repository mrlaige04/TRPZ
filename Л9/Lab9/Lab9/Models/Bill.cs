using System;
using System.Collections.Generic;

namespace Lab9.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int EmployeeId { get; set; }

    public int Table { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public double Sum { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
