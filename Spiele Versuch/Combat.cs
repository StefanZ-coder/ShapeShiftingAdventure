using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Combat
{
    private Random _rand = new Random();
    private Player _player;
    private Inventory _inventory;
  

    public Combat(Player player, Inventory inventory)
    {
        _player = player;
        _inventory = inventory;
        
    }
    
    public void FightRun(Enemy enemy,FightPossibilities fightPossibilities)
    {

        string combatOptions = File.ReadAllText("D:\\Interface01.txt");

        while (enemy.Health > 0)
        {
            Console.Clear();
            _inventory.Print();
            Console.WriteLine(enemy.Name);
            Console.WriteLine($"Angriffskraft {enemy.Attakpower} / Leben {enemy.Health}");
            Console.Write(combatOptions);
            Console.WriteLine();
            Console.WriteLine($"Leben: {_player.Health} Mana: { _player.Mana} ");
            Console.WriteLine($"Regenerationstrank: {_inventory.HealPotionCount} Manatrank: {_inventory.ManaPotionCount}");
            string input = Console.ReadLine();

            fightPossibilities.Attak(enemy,input);
            fightPossibilities.Defense(enemy, input);
            fightPossibilities.Escape(enemy, input);
            fightPossibilities.DrinkingHealpotion(enemy, input);
            fightPossibilities.DrinkingManapotion(enemy, input);
            fightPossibilities.Magiccast(enemy, input);
            fightPossibilities.Death(enemy);

            Console.ReadKey();
        }

        Console.WriteLine($" Du steht über deinen besiegten Feind und findest bei ihm {enemy.Gold} Goldmünzen in seinen Taschen." + Environment.NewLine +
        $" Hab Dank werter {enemy.Name}, spricht dein pelziger Begleiter und nimmt das Gold an sich.");

        Console.ReadKey();
    }



  


}