namespace ShapeshiftersAdventure
{
    public class DuongenProgramm
    {
        public static Playerstuff currentPlayer = new Playerstuff(10,5,4,1,0,1);
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Start();
            EnemysAndCombat.FirstGuard();
            while (mainLoop)
            {
                EnemysAndCombat.RandomEnemy();
            }
        }

        static void Start()
        {
            Console.WriteLine(" Willkommen du Narr, nun da ihr hier seid nennt mir als erstes euren Namen....");
            Console.WriteLine(" Name:");
            currentPlayer.Name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine(" Du erwachst in einem dunkeln Zelle und kannst dich nicht dran erinnern wie du hier hingelangt bist oder wer du bist."+Environment.NewLine+
            " Dein Kopf scheint leer zu sein du siehst dich um und eine Ratte begrüßt dich!");

            if (currentPlayer.Name =="")
                Console.WriteLine(" Seid grüßt Recke ohne Namen... spricht das kleine pelzige Biest!");
            else
            Console.WriteLine(" Seid grüßt mein Recke " + currentPlayer.Name + " spricht das kleine pelzige Biest!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Dein neuer pelziger Freund setzt sich auf deine Schulter und drängt dich die Tür deiner Zelle zu öffnen."+Environment.NewLine+
            " Diese ist nicht verschlossen und mit etwas druck auf die rostige Klinke lässt sie sich nach innen öffen"+ Environment.NewLine+
            " Du und dein Pelziger Freund gebt keinen ton von euch denn 5 schritt vor dir entfernt steht dein Wärter."+ Environment.NewLine+
            " mit den rücken zur Tür gewand.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
