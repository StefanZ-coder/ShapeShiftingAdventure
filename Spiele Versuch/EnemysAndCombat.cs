

using ShapeshiftersAdventure;
using static System.Net.Mime.MediaTypeNames;

public class EnemysAndCombat
{
    public static Random rand = new Random();
    public static void FirstGuard()
    {
        Console.WriteLine(" Langsam dreht sich dein Wärter um, intuitiv bewegst du dich in seine richtung"+Environment.NewLine+
       " und greifst dir das rostige und schartige schwert das neben der tür lehnt....");
        Combat (false, "Wärter", 1, 6);
    }
    public static void BasicEnemy()
    {
        Console.Clear();
        Console.WriteLine(" Du rennst weiter durch das verwinkelte Gemäuer, plötzlich siehst du hinter der nächsten ecke wie sich ein Feind vor dir erhebt...");
        Console.ReadKey();
        Combat(true, "", 0, 0);
    }

    //Boss oder so noch nicht im Spiel
    public static void ShadowWizzardEnemy()
    {
        Console.Clear();
        Console.WriteLine(" Nach einigen Gängen im dunklem Gemäuer, öffnest du eine schwerfällige Tür..." + Environment.NewLine +
        " Der Raum den du betrittst wird von einer magischen Lichtkugel erhellt. " + Environment.NewLine +
        " An einer seite des Raumes erkennst du einen alten Mann mit einem Stab in der Hand der gerade ein Buch zurück in ein Regal schweben lässt." + Environment.NewLine +
        " Im nächsten moment erkennst du wie sein Schatten versucht nach dir zu greifen und du erkennst seinen Blick der nichts gutes verheißst " + Environment.NewLine +
        " den dort wo seine Augen sein sollte herrschte Leere, dennoch sieht er dich an als könnte er dich sehen.... ");
        Console.ReadKey();
        Combat(false, "Schatten Magier", 4, 8);
    }

    public static void WizzardEnemy()
    {
        Console.Clear();
        Console.WriteLine(" Nach einem weiterm Gang und einer weitern Tür steht in diesem Raum ein älter Mann vor dir.");
        Console.ReadKey ();
        Combat(false, "Dunkler Magier",0,0);
    }
    public static void RandomEnemy()
    {
        switch (rand.Next(0, 2))
        {
            case 0:
                BasicEnemy();
                break;

            case 1:
                WizzardEnemy();
                break;

        }
    }
    public static void Combat(bool random, string name, int power, int health)
    {
        string n = "";
        int p = 0;
        int h = 0;

        if (random)
        {
            n = GetName();
            p = DuongenProgramm.currentPlayer.GetPower();
            h = DuongenProgramm.currentPlayer.GetHealth();  
        }

        else
        {
            n = name;
            p = power;
            h = health;
        }
        while (h > 0)
        {
            Console.Clear();
            Console.WriteLine(n);
            Console.WriteLine("Angriffskraft "+p+" / Leben " + h );
            Console.WriteLine("============================");
            Console.WriteLine("| (A)ngriff (V)erteidigung |");
            Console.WriteLine("|  (F)liehen (H)eilung     |");
            Console.WriteLine("============================");
            Console.WriteLine(" Tränke: " + DuongenProgramm.currentPlayer.Potions + " Leben: " + DuongenProgramm.currentPlayer.Health);
            string input = Console.ReadLine();
            if (input.ToLower() == "a" || input.ToLower() == "angriff")
            {
                //Angriff
                Console.WriteLine(" Mit unerwarter gewandheit stürmst du mit dem alten Stahl auf deinen Gegner zu. Der " + n + "versucht ebenso dich zu treffen... ");
                int damage = p - DuongenProgramm.currentPlayer.Armor;
                if (damage < 0)
                    damage = 0;
                int attack = rand.Next(0, DuongenProgramm.currentPlayer.Weapon) + rand.Next(1, 4);
                Console.WriteLine(" Du verlierst " + damage + " Leben und machst " + attack + " Schaden.");
                DuongenProgramm.currentPlayer.Health -= damage;
                h -= attack;
            }
            else if (input.ToLower() == "v" || input.ToLower() == "verteidigung" || input.ToLower() == "Verteidigung" || input.ToLower() == "V")
            {
                //Verteidigung
                Console.WriteLine(" Dein gegner " +n+ " macht sich bereit zum angriff, früh genug erkennst was dieser vorhat und gehst in die Verteidigung...");
                int damage = (p/4) - DuongenProgramm.currentPlayer.Armor;
                if (damage < 0)
                    damage = 0;
                int attack = rand.Next(0, DuongenProgramm.currentPlayer.Weapon) / 2;
                Console.WriteLine(" Du verlierst " + damage + " Leben und machst " + attack + " Schaden.");
                DuongenProgramm.currentPlayer.Health -= damage;
                h -= attack;
            }
            else if (input.ToLower() == "f" || input.ToLower() == "fliehen" || input.ToLower() == "Fliehen" || input.ToLower() == "F")
            {
                //Fliehen
                if (rand.Next(0,2) == 0)
                {
                    Console.WriteLine(" In dem moment als du fliehen willst trifft dich " +n+ " mit einem Hieb in den rücken und du gehst zu boden.... ");
                    int damage = p - DuongenProgramm.currentPlayer.Armor;
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
                if(DuongenProgramm.currentPlayer.Potions==0)
                {
                    Console.WriteLine(" Als du in deine tasche nach einem Trank greifen willst, spürst du nur die endlosen weiten des nichts. ");
                    Console.WriteLine(" Du hast keine Tränke mehr! ");
                    int damage = p - DuongenProgramm.currentPlayer.Armor;
                    if(damage < 0)
                        damage=0;
                    Console.WriteLine(" Dein Feind kennt kein erbarmen und schlägt zu und du verlierst "+damage+" leben.");
                }
                else
                {
                    Console.WriteLine(" Du findest in deiner Tasche im richtigen augenblick einen Trank!");
                    int potionValue = 5;
                    Console.WriteLine(" Dein Leben wird aufgefrischt um " +potionValue+ " und fühlst dich besser.");
                    DuongenProgramm.currentPlayer.Health += potionValue;
                    DuongenProgramm.currentPlayer.Potions = -1;
                    Console.WriteLine(" Als du deinen Trank ansetzt nutzt dein gegener die Gelegenheit");
                    int damage = (p/2) - DuongenProgramm.currentPlayer.Armor;
                    if (damage < 0)
                        damage = 0;
                    Console.WriteLine(" Du sollest nicht im Kampf trinken, du verlierst " + damage + " Leben...");

                }
                Console.ReadKey();
            }
            if(DuongenProgramm.currentPlayer.Health<=0)
            {
                Console.WriteLine("Als "+n+" dich mit seinem letzten Schlag trifft fällst du besiegt zu Boden... ");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            Console.ReadKey();
        }
        int g = DuongenProgramm.currentPlayer.GetGold();
        Console.WriteLine(" Du steht über deinen besiegten Feind und findest bei ihm "+g+" Goldmünzen in seinen Taschen." + Environment.NewLine +
        " Hab Dank werter " +n+", spricht dein pelziger Begleiter.");
        DuongenProgramm.currentPlayer.Gold += g;
        Console.ReadKey();

    }

    public static string GetName()
    {
        switch (rand.Next(0,4))
        {
                case 0:
                return "Wärter";
                
                case 1:
                return "Soldat";
                
                case 2:
                return "Skelett";

                case 3:
                return "Zombie";
   
                case 4:
                return "Hexer";
   
        }
        return "Grab Räuber";
    }
}


