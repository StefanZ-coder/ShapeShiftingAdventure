

public class Playerstuff
{

    public static Random rand = new Random();
    public Playerstuff(int health, int mana, int potions, int dps, int armor,int weapon)
    {

        Health = health;  
        Mana = mana;
        Potions = potions;
        Dps = dps;
        Armor = armor;
        Weapon = weapon;
        
    }

public string Name { get; set; }
public int Health { get; set; }
public int Mana { get; set; }
public int Gold { get; set; }
public int Potions { get; set; }
public int Dps { get; set; }
public int Armor { get; set; }
public int Weapon { get; set; }


    public int modifyer = 0;

    public int GetPower()
    {
        int upper = (2 * modifyer + 3);
        int lower = (modifyer + 2);
        return rand.Next(lower, upper);
    }

    public int GetHealth()
    {
        int upper = (2 * modifyer + 6);
        int lower = (modifyer + 2);
        return rand.Next(lower, upper);
    }

    public int GetGold()
    {
        int upper = (2 * modifyer + 8);
        int lower = (modifyer + 2);
        return rand.Next(lower, upper);
    }

}