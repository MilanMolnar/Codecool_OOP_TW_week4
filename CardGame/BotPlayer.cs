using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class BotPlayer : IPlayer
    {
        public List<Card> listOfCards;
        Card TopCard { get; set; }
        int ID { get; set; }
        bool isWinner { get; set; }

        public BotPlayer()
        {
            this.listOfCards = new List<Card>();
        }

        public int ChooseAttributes(Card topCard, string attribute)
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

        public void TakeCards(List<Card> topCards)
        {
            foreach (var card in topCards)
            {
                this.listOfCards.Add(card);
            }
        }
    }
}
