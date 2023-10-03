namespace ClassLibrary.Interfaces;
public abstract class MyObject
{
    public string Info { get; set; }
    public int Weight { get; set; }
    public DateTime Manufactured { get; set; }
    public string Manufacturer { get; set; }

    public MyObject(string info, int weight, DateTime manufactured, string manufacturer)
    {
        Info = info;
        Weight = weight;
        Manufactured = manufactured;
        Manufacturer = manufacturer;
    }

    public override string ToString()
        => $"Info: {Info}; Weight: {Weight}; Manufactured: {Manufactured}; Manufacturer: {Manufacturer}";
}
