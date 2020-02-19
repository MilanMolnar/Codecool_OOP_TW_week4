using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class BotPlayer : Player
    {
        public BotPlayer(Deck deck, int numOfPlayers, string name)
            : base(deck, numOfPlayers, name)
        {
        }

        public override void TakeCards(List<Card> topCards)
        {
            foreach (var card in topCards)
            {
                this.listOfCards.Add(card);
            }
        }

        public override int GetCardCount()
        {
            return this.listOfCards.Count;
        }

        public override Card GetTopCard()
        {
            return this.topCard;
        }

        public override void RemoveCard()
        {
            listOfCards.Remove(GetTopCard());
        }
    }
}
