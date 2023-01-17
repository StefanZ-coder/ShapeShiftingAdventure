using System.Reflection.Metadata;

public abstract class Item
{
   
    protected abstract string Name { get; }
    public void Print()
    {
        Console.WriteLine($" - {Name}");
    }
}


