using ClassLibrary.Interfaces;

namespace ClassLibrary.Models;
public class Weapon : MyObject, IWeapon
{
    public int AmmoCount { get; set; }
    public string Caliber { get; set; }
    public int Range { get; set; }
    public int Accuracy { get; set; }
    public Weapon(
        string info, int weight, string manufacturer,
        DateTime manufactured, int ammoCount,
        string caliber, int range, int accuracy)
        : base(info, weight, manufactured, manufacturer)
    {
        AmmoCount = ammoCount;
        Caliber = caliber;
        Range = range;
        Accuracy = accuracy;
    }

    public void Fire()
    {
        Console.WriteLine("Weapon fire (pi-u)");
    }

    public override string ToString()
        => $"AmmoCount: {AmmoCount}; Caliber: {Caliber}; Range: {Range}; Accuracy: {Accuracy}";
}
