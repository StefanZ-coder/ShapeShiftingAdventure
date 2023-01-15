public class Weapon : Item
{

    public Weapon(int damage)
    {
        Damage = damage;
    }

    protected int Damage { get; }
    protected override string Name => "Waffe";
    public override void Use()
    {

    }
}