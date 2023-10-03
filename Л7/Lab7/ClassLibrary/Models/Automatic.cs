using ClassLibrary.Enums;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Models;
public class Automatic : Weapon, IAutomatic
{
    public int FireRate { get; set; }
    public FireMode FireMode { get; set; }
    public int MagazineCapacity { get; set; }
    public string ManufacturerCountry { get; set; }

    public Automatic(string info, int weight, string manufacturer, DateTime manufacturingDate,
        int ammoCount, string caliber, int range, int accuracy, int fireRate,
        FireMode fireMode, int magazineCapacity, string manufacturerCountry)
        : base(info, weight, manufacturer, manufacturingDate, ammoCount, caliber, range, accuracy)
    {
        FireRate = fireRate;
        FireMode = fireMode;
        MagazineCapacity = magazineCapacity;
        ManufacturerCountry = manufacturerCountry;
    }

    public void AutoFire()
    {
        Console.WriteLine("Auto fire: (Auto-pi-u) ");
    }

    public override string ToString()
        => $"{base.ToString()}; FireRate: {FireRate}; FireMode: {FireMode};" +
        $" Magazine Capacity: {MagazineCapacity}; Manufacturer Country: {ManufacturerCountry}";
}
