public class Armor : Item
{

    public Armor (int defense)
    {
        Defense = defense;
    }

    public int Defense { get; }
    protected override string Name => "Leder Wams";
   
}