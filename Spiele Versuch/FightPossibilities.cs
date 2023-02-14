
using System;


public class FightPossibilities
{


    private Random _rand = new Random();
    private Player _player;
    private Inventory _inventory;
   
   

    public FightPossibilities(Player player, Inventory inventory)
    {
        _player = player;
        _inventory = inventory;
        
    }
    //Angriff
    public void Attak(Enemy enemy, string input)
    {
        if (input.ToLower() == "a" || input.ToLower() == "angriff")
        {

            Console.WriteLine($" Mit unerwarter gewandheit stürmst du mit dem alten Stahl auf deinen Gegner zu. Der {enemy.Name} versucht ebenso dich zu treffen... ");
            int damage = enemy.Attakpower - _inventory.ArmorDefense / 2;
            if (damage < 0)
                damage = 0;
            int attack = _rand.Next(0, _inventory.MeeleWeaponDamage) + _rand.Next(1, 4);
            Console.WriteLine($" Du verlierst {damage} Leben und machst {attack} Schaden.");
            _player.Health -= damage;
            enemy.Health -= attack;
        }

    }

    //Verteidigung
    public void Defense(Enemy enemy, string input)
    {
        if (input.ToLower() == "v" || input.ToLower() == "verteidigung")
        {

            Console.WriteLine($" Dein gegner {enemy.Name} macht sich bereit zum angriff, früh genug erkennst was dieser vorhat und gehst in die Verteidigung...");
            int damage = (enemy.Attakpower / 2) - _inventory.ArmorDefense / 2;
            if (damage < 0)
                damage = 0;
            int attack = _rand.Next(0, _inventory.MeeleWeaponDamage) / 2;
            Console.WriteLine($" Du verlierst {damage} Leben und machst {attack} Schaden.");
            _player.Health -= damage;
            enemy.Health -= attack;
        }
    }

    //Fliehen
    public void Escape(Enemy enemy,string input)
    {
        if (input.ToLower() == "f" || input.ToLower() == "fliehen")
        {

            if (_rand.Next(0, 2) == 0)
            {
                Console.WriteLine($" In dem moment als du fliehen willst trifft dich {enemy.Name} mit einem Hieb in den rücken und du gehst zu boden.... ");
                int damage = enemy.Attakpower - _inventory.ArmorDefense / 2;
                if (damage < 0)
                    damage = 0;
                Console.WriteLine($" Du verlierst {damage} Leben und jetzt kannst du nicht mehr fliehen! ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Du konntest erfolgreich fliehen vor {enemy.Name} und dein Abenteuer kann weiter gehen auch ohne Kampf!");
                Console.ReadKey();
                //später zur basis oder ähnliches
            }
        }
    }

    //Heilung mit Trank
    public void DrinkingHealpotion(Enemy enemy, string input)
    {
        if (input.ToLower() == "h" || input.ToLower() == "heilung")
        {

            if (_inventory.HealPotionCount == 0)
            {
                Console.WriteLine(" Als du in deine tasche nach einem Trank greifen willst, spürst du nur die endlosen weiten des nichts. ");
                Console.WriteLine(" Du hast keine Tränke mehr! ");
                int damage = enemy.Attakpower - _inventory.ArmorDefense / 2;
                if (damage < 0)
                    damage = 0;
                Console.WriteLine($" Dein Feind kennt kein erbarmen und schlägt zu und du verlierst {damage} leben.");
            }
            else
            {
                Console.WriteLine(" Du findest in deiner Tasche im richtigen augenblick einen Trank!");

                Console.WriteLine(" Dein Leben wird aufgefrischt und du fühlst dich besser.");
                Healpotion potion = _inventory.Items.OfType<Healpotion>().First();

                _player.Health += potion.Healing;
                _inventory.Items.Remove(potion);

                Console.WriteLine(" Als du deinen Trank ansetzt nutzt dein gegener die Gelegenheit");
                int damage = (enemy.Attakpower / 2) - _inventory.ArmorDefense / 2;
                if (damage < 0)
                    damage = 0;
                Console.WriteLine($" Du sollest nicht im Kampf trinken, du verlierst {damage} Leben...");

            }
            Console.ReadKey();
        }
    }
    //Mana wiederherstellen
    public void DrinkingManapotion(Enemy enemy, string input)
    {
        if (input.ToLower() == "m" || input.ToLower() == "mana")
        {

            if (_inventory.ManaPotionCount == 0)
            {
                Console.WriteLine(" Als du in deine tasche nach einem Trank greifen willst, spürst du nur die endlosen weiten des nichts. ");
                Console.WriteLine(" Du hast keine Manatränke mehr! ");
                int damage = enemy.Attakpower - _inventory.ArmorDefense / 2;
                if (damage < 0)
                    damage = 0;
                Console.WriteLine($" Dein Feind kennt kein erbarmen und schlägt zu und du verlierst {damage} leben.");
            }
            else
            {
                Console.WriteLine(" Du findest in deiner Tasche im richtigen augenblick einen Trank!");

                Console.WriteLine(" Dein Mana wird aufgefrischt und du fühlst dich besser.");
                Manapotion potion = _inventory.Items.OfType<Manapotion>().First();

                _player.Mana += potion.RestoreMana;
                _inventory.Items.Remove(potion);

                Console.WriteLine(" Als du deinen Trank ansetzt nutzt dein gegener die Gelegenheit");
                int damage = (enemy.Attakpower / 2) - _inventory.ArmorDefense / 2;
                if (damage < 0)
                    damage = 0;
                Console.WriteLine($" Du sollest nicht im Kampf trinken, du verlierst {damage} Leben...");

            }
            Console.ReadKey();
        }
    }

    //Magieangriff
    public void Magiccast(Enemy enemy, string input)
    {
        if (input.ToLower() == "z" || input.ToLower() == "zauber")
        {
            if (_player.Mana == 0)
            {
                Console.WriteLine(" Als du deinen Spruch weben willst, passiert nichts! Du solltest mehr auf dein Mana achten.");
            }
            else
            {

                Console.WriteLine($"  Ein helles Licht erfüllt den Raum und {_player.Name} sieht auf seine Hände herab aus denen gerade " + Environment.NewLine +
                $" ein Blitz aus Feuer schoss und den Gegner in Flammen hüllt die ihn versegen. Der {enemy.Name} versucht ebenso dich zu treffen... ");
                int damage = enemy.Attakpower - _inventory.ArmorDefense / 2;
                if (damage < 0)
                    damage = 0;
                int attack = _rand.Next(0, _inventory.MagicWeaponDamage) + _rand.Next(1, 4);
                Console.WriteLine($" Du verlierst {damage} Leben und machst {attack} Schaden.");
                _player.Health -= damage;
                _player.Mana -= 2;
                enemy.Health -= attack;
            }
        }
    }
    public void Death(Enemy enemy)
    {

        if (_player.Health <= 0)
        {
            Console.WriteLine($"Als {enemy.Name} dich mit seinem letzten Schlag trifft fällst du besiegt zu Boden... ");
            Console.ReadKey();
           
            PlayerDied?.Invoke(this, EventArgs.Empty);
        }
    }
    public event EventHandler PlayerDied;
}
