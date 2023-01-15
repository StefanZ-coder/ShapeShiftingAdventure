public class Potion : Item
{

    public Potion(int healing)
    {
        Healing = healing;
    }

    protected int Healing { get; }
    protected override string Name => "Heiltrank";

    public override void Use()
    {
        
    }
}
