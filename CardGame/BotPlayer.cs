using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class BotPlayer : Player
    {
        List<int> maxValuesOfTheGame;
        public int Hp { get { return maxValuesOfTheGame[0]; } }
        public int Attack { get { return maxValuesOfTheGame[1]; } }
        public int Defense { get { return maxValuesOfTheGame[2]; } }
        public int Speed { get { return maxValuesOfTheGame[3]; } }
        public BotPlayer(Deck deck, int numOfPlayers, string name)
            : base(deck, numOfPlayers, name)
        {
            maxValuesOfTheGame = deck.MaxValuesForAttributes;
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
