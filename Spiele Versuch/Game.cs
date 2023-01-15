public class Game
{
    private Player _currentPlayer = new Player(10, 5);
    private EnemyFactory _enemyFactory = new EnemyFactory();
    public Inventory _inventory = new Inventory();
    public Armor _armor = new Armor(1);
    public Potion _potion = new Potion(5);
    public Weapon _weapon = new Weapon(1);

    private bool _mainLoop = true;

    
    public void CreateStartInventory()
    {
        _inventory.Gold = 10;
        _inventory.Items.Add(new Armor(1));
        _inventory.Items.Add(new Weapon(2));

        for (int i = 0; i < 5; i++)
        {
            _inventory.Items.Add(new Potion(5));
        }
    }
    public void Run()
    {
        

        CreateStartInventory();
        Start();
        _inventory.Print();
        Enemy firstenemy = _enemyFactory.CreateFirstGuard();
        Combat firstcombat = new Combat();
        firstcombat.Fightclub(firstenemy, _currentPlayer, _inventory, _armor, _weapon, _potion);

        while (_mainLoop)
        {
            Enemy enemy = _enemyFactory.CreateRandomEnemy();
            Combat combat = new Combat();
            combat.Fightclub(enemy, _currentPlayer, _inventory ,_armor, _weapon, _potion);
        }
    }
 

    public void Start()
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

