using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CardGame
{
    public class CardComparer
    {
        public class HPComparer : IComparer<Card>
        {
            public int Compare(Card x, Card y)
            {
                if (x.HP < y.HP)
                {
                    return 1;
                }
                else if (x.HP > y.HP)
                {
                    return -1;
                }
                else
                    return 0;
            }
        }
        public class AttackComparer : IComparer<Card>
        {
            public int Compare(Card x, Card y)
            {
                if (x.Attack < y.Attack)
                {
                    return 1;
                }
                else if (x.Attack > y.Attack)
                {
                    return -1;
                }
                else
                    return 0;
            }
        }
        public class DefendComparer : IComparer<Card>
        {
            public int Compare(Card x, Card y)
            {
                if (x.Defend < y.Defend)
                {
                    return 1;
                }
                else if (x.Defend > y.Defend)
                {
                    return -1;
                }
                else
                    return 0;
            }
        }
        public class SpeedComparer : IComparer<Card>
        {
            public int Compare(Card x, Card y)
            {
                if (x.Speed < y.Speed)
                {
                    return 1;
                }
                else if (x.Speed > y.Speed)
                {
                    return -1;
                }
                else
                    return 0;
            }
        }
        public class SortByNumOfCards : IComparer<Player>
        {
            public int Compare(Player x, Player y)
            {
                if (x.GetCardCount() < y.GetCardCount())
                {
                    return 1;
                }
                else if (x.GetCardCount() > y.GetCardCount())
                {
                    return -1;
                }
                else
                    return 0;
            }
        }
    }
}
