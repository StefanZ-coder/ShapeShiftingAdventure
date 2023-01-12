public class Armor : Item
{

    public Armor (int defense)
    {
        Defense = defense;
    }

    public int Defense { get; set; }
    protected override string Name => "Rüstung";
    public override void Use()
    {
       
    }
}