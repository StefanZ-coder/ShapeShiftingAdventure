public class Armor : Item
{

    public Armor (int defense)
    {
        Defense = defense;
    }

    protected int Defense { get; }
    protected override string Name => "Rüstung";
    public override void Use()
    {
       
    }
}