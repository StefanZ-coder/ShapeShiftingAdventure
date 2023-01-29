public class Healpotion : Item
{

    public Healpotion(int healing)
    {
        Healing = healing;
    }

    public int Healing { get; }
    protected override string Name => "Regenerationstrank";

}
