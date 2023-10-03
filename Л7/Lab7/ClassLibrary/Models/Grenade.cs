using ClassLibrary.Enums;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Models;
public class Grenade : MyObject, IThrowable
{
    public string Type { get; set; }
    public ExplosionType ExplosionType { get; set; }
    public int BlastRadius { get; set; }
    public Grenade(string info, int weight, string manufacturer, DateTime manufactured,
       string type, ExplosionType explosionType, int blastRadius)
        : base(info, weight, manufactured, manufacturer)
    {

        Type = type;
        ExplosionType = explosionType;
        BlastRadius = blastRadius;
    }

    public void Fire() => Throw();

    public void Throw()
    {
        Console.WriteLine("Grenade (poletelo): ");
    }

    public override string ToString()
        => $"{base.ToString()}; Type: {Type}; ExplosionType: {ExplosionType}; BlastRadius: {BlastRadius};";
}
