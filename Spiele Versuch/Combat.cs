using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Combat
{
    private Random _rand = new Random();

    public void Fightclub(Enemy enemy, Player player)
    {
        string n = enemy.Name;
        int p = enemy.Attakpower;
        int h = enemy.Health;
        int g = enemy.Gold;


        while (h > 0) 
        {
            Console.Clear();
            Console.WriteLine(n);
            Console.WriteLine("Angriffskraft " + p + " / Leben " + h);
            Console.WriteLine("============================");
            Console.WriteLine("| (A)ngriff (V)erteidigung |");
            Console.WriteLine("|  (F)liehen (H)eilung     |");
            Console.WriteLine("============================");
            Console.WriteLine(" Tränke: " + player.Potions + " Leben: " + player.Health);
            string input = Console.ReadLine();
            if (input.ToLower() == "a" || input.ToLower() == "angriff")
            {
                //Angriff
                Console.WriteLine(" Mit unerwarter gewandheit stürmst du mit dem alten Stahl auf deinen Gegner zu. Der " + n + "versucht ebenso dich zu treffen... ");
                int damage = p - player.Armor;
                if (damage < 0)
                    damage = 0;
                int attack = _rand.Next(0, player.Weapon) + _rand.Next(1, 4);
                Console.WriteLine(" Du verlierst " + damage + " Leben und machst " + attack + " Schaden.");
                player.Health -= damage;
                h -= attack;
            }
            else if (input.ToLower() == "v" || input.ToLower() == "verteidigung" || input.ToLower() == "Verteidigung" || input.ToLower() == "V")
            {
                //Verteidigung
                Console.WriteLine(" Dein gegner " + n + " macht sich bereit zum angriff, früh genug erkennst was dieser vorhat und gehst in die Verteidigung...");
                int damage = (p / 4) - player.Armor;
                if (damage < 0)
                    damage = 0;
                int attack = _rand.Next(0, player.Weapon) / 2;
                Console.WriteLine(" Du verlierst " + damage + " Leben und machst " + attack + " Schaden.");
                player.Health -= damage;
                h -= attack;
            }
            else if (input.ToLower() == "f" || input.ToLower() == "fliehen" || input.ToLower() == "Fliehen" || input.ToLower() == "F")
            {
                //Fliehen
                if (_rand.Next(0, 2) == 0)
                {
                    Console.WriteLine(" In dem moment als du fliehen willst trifft dich " + n + " mit einem Hieb in den rücken und du gehst zu boden.... ");
                    int damage = p - player.Armor;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine(" Du verlierst " + damage + " Leben und jetzt kannst du nicht mehr fliehen! ");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(" Du konntest erfolgreich fliehen vor " + n + " und dein Abenteuer kann weiter gehen auch ohne Kampf!");
                    Console.ReadKey();
                    //später zur basis oder ähnliches
                }
            }
            else if (input.ToLower() == "h" || input.ToLower() == "heilung" || input.ToLower() == "Heilung" || input.ToLower() == "H")
            {
                //Heilung
                if (player.Potions == 0)
                {
                    Console.WriteLine(" Als du in deine tasche nach einem Trank greifen willst, spürst du nur die endlosen weiten des nichts. ");
                    Console.WriteLine(" Du hast keine Tränke mehr! ");
                    int damage = p - player.Armor;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine(" Dein Feind kennt kein erbarmen und schlägt zu und du verlierst " + damage + " leben.");
                }
                else
                {
                    Console.WriteLine(" Du findest in deiner Tasche im richtigen augenblick einen Trank!");
                    int potionValue = 5;
                    Console.WriteLine(" Dein Leben wird aufgefrischt um " + potionValue + " und fühlst dich besser.");
                    player.Health += potionValue;
                    player.Potions = -1;
                    Console.WriteLine(" Als du deinen Trank ansetzt nutzt dein gegener die Gelegenheit");
                    int damage = (p / 2) - player.Armor;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine(" Du sollest nicht im Kampf trinken, du verlierst " + damage + " Leben...");

                }
                Console.ReadKey();
            }
            if (player.Health <= 0)
            {
                Console.WriteLine("Als " + n + " dich mit seinem letzten Schlag trifft fällst du besiegt zu Boden... ");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            Console.ReadKey();
        }

        Console.WriteLine(" Du steht über deinen besiegten Feind und findest bei ihm " + g + " Goldmünzen in seinen Taschen." + Environment.NewLine +
        " Hab Dank werter " + n + ", spricht dein pelziger Begleiter.");
        player.Gold += g;
        Console.ReadKey();

    }
}


    

