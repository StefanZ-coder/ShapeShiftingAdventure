public class Manapotion : Item
{

    public Manapotion(int restoreMana)
    {
        RestoreMana = restoreMana;
    }

    public int RestoreMana { get; }
    protected override string Name => "Manatrank";

}