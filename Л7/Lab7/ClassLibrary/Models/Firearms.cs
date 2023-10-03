using ClassLibrary.Enums;

namespace ClassLibrary.Models;
public class Firearms : Weapon
{
    public string Model { get; set; }
    public FireMode FireMode { get; set; }
    public int MagazineCapacity { get; set; }

    public Firearms(string info, int weight, string manufacturer,
        DateTime manufacturingDate, int ammoCount, string caliber,
        int range, int accuracy, string model, FireMode fireMode,
        int magazineCapacity)
        : base(info, weight, manufacturer, manufacturingDate, ammoCount, caliber, range, accuracy)
    {
        Model = model;
        FireMode = fireMode;
        MagazineCapacity = magazineCapacity;
    }

    public override string ToString()
        => $"{base.ToString()}; Model: {Model}; FireMode: {FireMode}; MagazineCapacity: {MagazineCapacity}";
}
