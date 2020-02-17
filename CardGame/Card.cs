using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Card
    {
        public int HP { get; }
        public int Attack { get; }
        public int Defend { get; }
        public int Speed { get; }

        public Card(int hp, int attack, int defend, int speed)
        {
            HP = hp;
            Attack = attack;
            Defend = defend;
            Speed = speed;
        }
    }
}
