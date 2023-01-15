using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




public class Inventory
{
    public List<Item> Items { get; } = new List<Item>();


    public int Gold { get; set; }
    public int Count { get; }

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

