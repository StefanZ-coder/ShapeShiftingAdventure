public class MagicWeapon : Item
{

    public MagicWeapon(int damage)
    {
        Damage = damage;
    }

    public int Damage { get; }
    protected override string Name => "kleiner Magie Focus";

}