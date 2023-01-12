public class Potion : Item
{

    public Potion(int healing)
    {
        Healing = healing;
    }

    public int Healing { get; set; }
    protected override string Name => "Heiltrank";

    public override void Use()
    {
        
    }
}
