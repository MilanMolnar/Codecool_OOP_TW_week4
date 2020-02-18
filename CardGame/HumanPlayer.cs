using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(Deck deck, int numOfPlayers, string name, bool isWinner) 
            : base(deck, numOfPlayers, name, isWinner)
        {
        }

        public override int ChooseAttributes(string attribute)
        {
            if (attribute.ToLower().Equals("hp"))
            {
                return topCard.HP;
            }
            else if (attribute.ToLower().Equals("attack"))
            {
                return topCard.Attack;
            }
            else if (attribute.ToLower().Equals("defend"))
            {
                return topCard.Defend;
            }
            else if (attribute.ToLower().Equals("speed"))
            {
                return topCard.Speed;
            }
            else
            {
                throw new Exception("NotValidAttribute");
            }
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
            return listOfCards.Count;
        }

        public override Card GetTopCard()
        {
            Card cardToRemove = this.listOfCards[0];
            this.listOfCards.Remove(cardToRemove);
            return cardToRemove;
        }
    }
}
