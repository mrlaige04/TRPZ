namespace Lab12.Models.EF;

using System.ComponentModel.DataAnnotations;


public abstract class BaseEntity
{
    [Key] public Guid Id { get; set; }
}
