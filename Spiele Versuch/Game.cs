public class Game
{
    private Player _currentPlayer = new Player(10, 3);
    private EnemyFactory _enemyFactory = new EnemyFactory();
    private Inventory _inventory = new Inventory();
   
    private bool _mainLoop = true;

    
    private void CreateStartInventory()
    {
        _inventory.Gold = 10;
        _inventory.Items.Add(new Armor(1));
        _inventory.Items.Add(new MeeleWeapon(2));
        _inventory.Items.Add(new MagicWeapon(3));

        for (int i = 0; i < 5; i++)
        {
            _inventory.Items.Add(new Healpotion(4));
        }

        for (int i = 0; i < 4; i++)
        {
            _inventory.Items.Add(new Manapotion(3));
        }
    }
    public void Run()
    {
        
        CreateStartInventory();
        Start();
        
        Enemy firstenemy = _enemyFactory.CreateFirstGuard();
        Combat firstcombat = new Combat(_currentPlayer,_inventory);
        firstcombat.Fightclub(firstenemy);

        while (_mainLoop)
        {
            Enemy enemy = _enemyFactory.CreateRandomEnemy();
            Combat combat = new Combat(_currentPlayer,_inventory);
            combat.Fightclub(enemy);
        }
    }
 

    private void Start()
    {
        Console.WriteLine(" Willkommen du Narr, nun da ihr hier seid nennt mir als erstes euren Namen....");
        Console.WriteLine(" Name:");
        _currentPlayer.Name = Console.ReadLine();
        Console.Clear();
       
        Console.WriteLine(" Du erwachst in einem dunkeln Zelle und kannst dich nicht dran erinnern wie du hier hingelangt bist oder wer du bist." + Environment.NewLine +
        " Dein Kopf scheint leer zu sein du siehst dich um und eine Ratte begrüßt dich!");

        if (_currentPlayer.Name == "")
            Console.WriteLine(" Seid grüßt Recke ohne Namen... spricht das kleine pelzige Biest!");
        else
            Console.WriteLine(" Seid grüßt mein Recke " + _currentPlayer.Name + " spricht das kleine pelzige Biest!");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(" Dein neuer pelziger Freund setzt sich auf deine Schulter und drängt dich die Tür deiner Zelle zu öffnen." + Environment.NewLine +
        " Diese ist nicht verschlossen und mit etwas druck auf die rostige Klinke lässt sie sich nach innen öffen" + Environment.NewLine +
        " Du und dein Pelziger Freund gebt keinen ton von euch denn 5 schritt vor dir entfernt steht dein Wärter." + Environment.NewLine +
        " mit den rücken zur Tür gewand.");
        Console.ReadKey();
        Console.Clear();
    }



}

