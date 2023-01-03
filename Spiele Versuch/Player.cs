using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class Player

    {
        public Player(int health, int mana, int potions, int dps, int armor, int weapon)
        {

            Health = health;
            Mana = mana;
            Potions = potions;
            Dps = dps;
            Armor = armor;
            Weapon = weapon;

        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Gold { get; set; }
        public int Potions { get; set; }
        public int Dps { get; set; }
        public int Armor { get; set; }
        public int Weapon { get; set; }

    }
