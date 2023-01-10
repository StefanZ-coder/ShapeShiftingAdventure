using System.Reflection.Metadata;

public abstract class Item
{
    public abstract void Use();

    protected abstract string Name { get; }
    public void Print()
    {
        Console.WriteLine($" - {Name}");
    }
}


