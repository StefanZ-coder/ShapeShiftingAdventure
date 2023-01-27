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
    
    public void Fightclub(Enemy enemy)
    {
        
        string name = enemy.Name;
        int attakpower = enemy.Attakpower;
        int health = enemy.Health;
        int gold = enemy.Gold;
        int armordefense = _inventory.ArmorDefense;
        int weapondps = _inventory.WeaponDamage;
        string combatOptions = File.ReadAllText("D:\\Interface01.txt");


        while (health > 0)
        {
            Console.Clear();
            _inventory.Print();
            Console.WriteLine(name);
            Console.WriteLine($"Angriffskraft {attakpower} / Leben {health}");
            Console.Write(combatOptions);
            Console.WriteLine();
            Console.WriteLine($" Tränke: {_inventory.PotionCount}      Leben: {_player.Health}");

            string input = Console.ReadLine();

            Attak(input);
            Death();
            Defense(input);
            Escape(input);
            DrinkingHealpotion(input);
            Magiccast();
            
            Console.ReadKey();
        }

        

        void Attak(string input)
        {
            if (input.ToLower() == "a" || input.ToLower() == "angriff")
            {
                //Angriff
                Console.WriteLine($" Mit unerwarter gewandheit stürmst du mit dem alten Stahl auf deinen Gegner zu. Der {name} versucht ebenso dich zu treffen... ");
                int damage = attakpower - armordefense;
                if (damage < 0)
                    damage = 0;
                int attack = _rand.Next(0, weapondps) + _rand.Next(1, 4);
                Console.WriteLine($" Du verlierst {damage} Leben und machst {attack} Schaden.");
                _player.Health -= damage;
                health -= attack;
            }
        }

         void Defense(string input)
        {
            if (input.ToLower() == "v" || input.ToLower() == "verteidigung" || input.ToLower() == "Verteidigung" || input.ToLower() == "V")
            {
                //Verteidigung
                Console.WriteLine($" Dein gegner {name} macht sich bereit zum angriff, früh genug erkennst was dieser vorhat und gehst in die Verteidigung...");
                int damage = (attakpower / 4) - armordefense;
                if (damage < 0)
                    damage = 0;
                int attack = _rand.Next(0, weapondps) / 2;
                Console.WriteLine($" Du verlierst {damage} Leben und machst {attack} Schaden.");
                _player.Health -= damage;
                health -= attack;
            }
        }

         void Escape(string input)
        {
            if (input.ToLower() == "f" || input.ToLower() == "fliehen" || input.ToLower() == "Fliehen" || input.ToLower() == "F")
            {
                //Fliehen
                if (_rand.Next(0, 2) == 0)
                {
                    Console.WriteLine($" In dem moment als du fliehen willst trifft dich {name} mit einem Hieb in den rücken und du gehst zu boden.... ");
                    int damage = attakpower - armordefense;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine($" Du verlierst {damage} Leben und jetzt kannst du nicht mehr fliehen! ");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"Du konntest erfolgreich fliehen vor {name} und dein Abenteuer kann weiter gehen auch ohne Kampf!");
                    Console.ReadKey();
                    //später zur basis oder ähnliches
                }
            }
        }

        void DrinkingHealpotion(string input)
        {
        if (input.ToLower() == "h" || input.ToLower() == "heilung" || input.ToLower() == "Heilung" || input.ToLower() == "H")
            {
                //Heilung
                if (_inventory.PotionCount == 0)
                {
                    Console.WriteLine(" Als du in deine tasche nach einem Trank greifen willst, spürst du nur die endlosen weiten des nichts. ");
                    Console.WriteLine(" Du hast keine Tränke mehr! ");
                    int damage = attakpower - armordefense;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine($" Dein Feind kennt kein erbarmen und schlägt zu und du verlierst {damage} leben.");
                }
                else
                {
                    Console.WriteLine(" Du findest in deiner Tasche im richtigen augenblick einen Trank!");

                    Console.WriteLine(" Dein Leben wird aufgefrischt und du fühlst dich besser.");
                    Potion potion = _inventory.Items.OfType<Potion>().First();

                    _player.Health += potion.Healing;
                    _inventory.Items.Remove(potion);

                    Console.WriteLine(" Als du deinen Trank ansetzt nutzt dein gegener die Gelegenheit");
                    int damage = (attakpower / 2) - armordefense;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine($" Du sollest nicht im Kampf trinken, du verlierst {damage} Leben...");

                }
                Console.ReadKey();
            }
        }
        void Death()
        {

            if (_player.Health <= 0)
            {
                Console.WriteLine($"Als {name} dich mit seinem letzten Schlag trifft fällst du besiegt zu Boden... ");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
        }

        void Magiccast()
        {

        }


        Console.WriteLine($" Du steht über deinen besiegten Feind und findest bei ihm {gold} Goldmünzen in seinen Taschen." + Environment.NewLine +
        $" Hab Dank werter {name}, spricht dein pelziger Begleiter und nimmt das Gold an sich.");

        Console.ReadKey();
    }



  


}