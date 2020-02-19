using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Table
    {
        public List<Card> topCards;
        public Table()
        {
            topCards = new List<Card>();
        }

        public void EmptyTable()
        {
            topCards = new List<Card>();
        }

        public List<Card> GetCardsFromTable()
        {
            return topCards;
        }

        public void AddCardsToTable(List<Card> cards)
        {
            topCards.AddRange(cards);
        }
    }
}
