using System.ComponentModel.DataAnnotations;

namespace Lab11.Models;

public abstract class BaseEntity
{
    [Key] public Guid Id { get; set; }
}
