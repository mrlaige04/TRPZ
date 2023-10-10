using System.ComponentModel.DataAnnotations;

namespace Lab10.Validators;

public class NotEqualZeroAttribute : ValidationAttribute
{
    public override bool IsValid(object? value) => !double.TryParse(value?.ToString(), out var num) | num != 0;
}
