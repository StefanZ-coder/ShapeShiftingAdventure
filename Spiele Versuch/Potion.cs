public class Potion : Item
{

    public Potion(int healing)
    {
        Healing = healing;
    }

    public int Healing { get; }
    protected override string Name => "Heiltrank";

}
