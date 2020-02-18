using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public abstract class Player
    {

        public List<Card> listOfCards;
        public string SelectedAttribute { get; set; }
        public Card topCard { get { return listOfCards[0]; } }
        public string Name { get; set; }
        protected Player(Deck deck, int numOfPlayer, string name)
        {
            this.listOfCards = deck.DealCards(numOfPlayer);
            this.Name = name;;
        }

        abstract public void TakeCards(List<Card> topCards);
        abstract public int GetCardCount();
        abstract public Card GetTopCard();
        abstract public void RemoveCard(Card card);
    }
}
