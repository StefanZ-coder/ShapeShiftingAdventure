using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




public class Inventory
{
    public List<Item> Items { get; } = new List<Item>();


    public int Gold { get; set; }
    public int ArmorDefense
    {
        get
        {
            foreach(Item item in Items)
            {
                if (item is Armor armor)

                    return armor.Defense;

            }

            return 0;
        }
    }

    public int MeeleWeaponDamage
    {
        get
        {
            return Items.OfType<MeeleWeapon>().Select(x => x.Damage).DefaultIfEmpty(0).First();
        }
    }

    public int MagicWeaponDamage
    {
        get
        {
            return Items.OfType<MagicWeapon>().Select(x => x.Damage).DefaultIfEmpty(0).First();
        }
    }

    public int HealPotionCount => Items.OfType<Healpotion>().Count();
    public int ManaPotionCount => Items.OfType<Manapotion>().Count();

    public void Print()
    {

        Console.WriteLine($"Es sind {Gold} Goldmünzen im Inventar");
        Console.WriteLine("Du hast wünderschöne Gegenstände im Inventar und diese sind...");

       foreach(Item item in Items)
        {

            item.Print();
        }

    }

}

