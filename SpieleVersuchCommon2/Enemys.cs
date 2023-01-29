using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Enemy
{
  
    public Enemy (int attakpower, int health, string name,int gold)
    {
        Health = health;
        Attakpower = attakpower;
        Name = name;
        Gold = gold;
    }
    public string Name { get; }
    public int Health { get; set; }
    public int Attakpower { get;}
    public int Gold { get; set; }

}



