using Lab10.Validators;
using System.ComponentModel.DataAnnotations;

namespace Lab10.Models;

public class QuardaticEquation
{
    [Required, NotEqualZero(ErrorMessage="'A' must not be equal to 0")]
    public double a { get; set; }
    [Required] public double b { get; set; }
    [Required] public double c { get; set; }

    public Result? Result { get; set; }
}


public class Result
{
    public double D { get; set; }
    public double? X1 { get; set; }
    public double? X2 { get; set; }
}