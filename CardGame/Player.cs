using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public abstract class Player
    {

        public List<Card> listOfCards;

        protected Player(Deck deck,int numOfPlayer, List<Card> listOfCards, Card topCard, int iD, bool isWinner)
        {
            this.listOfCards = deck.DealCards(numOfPlayer);
            this.TopCard = topCard;
            this.ID = iD;
            this.isWinner = isWinner;
        }

        public Card TopCard { get; set; }
        int ID { get; set; }
        bool isWinner { get; set; }
        abstract public int ChooseAttributes(Card topCard,string attribute);
        abstract public void TakeCards(List<Card> topCards);
        abstract public int GetCardCount();
    }
}
