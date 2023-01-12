public class Weapon : Item
{

    public Weapon(int damage)
    {
        Damage = damage;
    }

    public int Damage { get; set; }
    protected override string Name => "Waffe";
    public override void Use()
    {

    }
}