using System;
using System.Collections.Generic;

namespace Lab9.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public DateTime Birthday { get; set; }

    public string? BirthPlace { get; set; }

    public int PositionId { get; set; }

    public double Salary { get; set; }

    public double Bonus { get; set; }

    public DateTime PaymentDate { get; set; }

    public double Total { get; set; }

    public string Pib { get; set; } = null!;

    public DateTime? JoinDate { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual Position Position { get; set; } = null!;
}
