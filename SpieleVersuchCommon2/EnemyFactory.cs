﻿public class EnemyFactory
{
    private Random _rand = new Random();
    private int _modifyer = 0;
    private string CreateRandomName()
    {
        switch (_rand.Next(0, 4))
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

    private int CreateRandomAttakpower()
    {
        int upper = (2 * _modifyer + 3);
        int lower = (_modifyer + 2);
        return _rand.Next(lower, upper);
    }
    private int CreateRandomHealth()
    {
        int upper = (2 * _modifyer + 6);
        int lower = (_modifyer + 2);
        return _rand.Next(lower, upper);
    }
    private int CreateRandomGold()
    {
        int upper = (2 * _modifyer + 8);
        int lower = (_modifyer + 2);
        return _rand.Next(lower, upper);
    }
    public Enemy CreateRandomEnemy()
    {
        switch (_rand.Next(0, 2))
        {
            case 0:
                return CreateBasicEnemy();

            case 1:
                return CreateWizzardEnemy();
               
        }
        throw new InvalidOperationException("Invalid random number");

    }
   
    private Enemy CreateWizzardEnemy()
    {
        Console.Clear();
        Console.WriteLine(" Nach einem weiterm Gang und einer weitern Tür steht in diesem Raum ein älter Mann vor dir.");
        Console.ReadKey();

        Enemy enemy = new Enemy(CreateRandomAttakpower(), CreateRandomHealth(), "Dunkler Magier", CreateRandomGold());
        return enemy;

    }
    private Enemy CreateBasicEnemy()
    {
        Console.Clear();
        Console.WriteLine(" Du rennst weiter durch das verwinkelte Gemäuer, plötzlich siehst du hinter der nächsten ecke wie sich ein Feind vor dir erhebt...");
        Console.ReadKey();

        Enemy enemy = new Enemy(CreateRandomAttakpower(), CreateRandomHealth(), CreateRandomName(), CreateRandomGold());
        return enemy;
    }
    //Boss oder so noch nicht im Spiel
    public void ShadowWizzardEnemy()
    {
        Console.Clear();
        Console.WriteLine(" Nach einigen Gängen im dunklem Gemäuer, öffnest du eine schwerfällige Tür..." + Environment.NewLine +
        " Der Raum den du betrittst wird von einer magischen Lichtkugel erhellt. " + Environment.NewLine +
        " An einer seite des Raumes erkennst du einen alten Mann mit einem Stab in der Hand der gerade ein Buch zurück in ein Regal schweben lässt." + Environment.NewLine +
        " Im nächsten moment erkennst du wie sein Schatten versucht nach dir zu greifen und du erkennst seinen Blick der nichts gutes verheißst " + Environment.NewLine +
        " den dort wo seine Augen sein sollte herrschte Leere, dennoch sieht er dich an als könnte er dich sehen.... ");
        Console.ReadKey();

    }

    public Enemy CreateFirstGuard()
    {
        Console.WriteLine(" Langsam dreht sich dein Wärter um, intuitiv bewegst du dich in seine richtung" + Environment.NewLine +
       " und greifst dir das rostige und schartige schwert das neben der tür lehnt....");

        Enemy enemy = new Enemy(1, 6, "Wärter", CreateRandomGold());
        return enemy;

    }

}



