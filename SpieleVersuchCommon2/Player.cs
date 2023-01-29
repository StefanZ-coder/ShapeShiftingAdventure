using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Player

    {
        public Player(int health, int mana)
        {

            Health = health;
            Mana = mana;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }


    }
