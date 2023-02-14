public class MeeleWeapon : Item
{

    public MeeleWeapon(int damage)
    {
        Damage = damage;
    }

    public int Damage { get; }
    protected override string Name => "stumpfes Schwert";

}