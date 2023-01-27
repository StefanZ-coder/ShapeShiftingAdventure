public class Weapon : Item
{

    public Weapon(int damage)
    {
        Damage = damage;
    }

    public int Damage { get; }
    protected override string Name => "Rostiges Schwert";
 
}