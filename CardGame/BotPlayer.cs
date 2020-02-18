﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class BotPlayer : Player
    {
        public List<Card> listOfCards;
        Card TopCard { get; set; }
        int ID { get; set; }
        bool isWinner { get; set; }

        public BotPlayer(Deck deck, int numOfPlayers, List<Card> listOfCards, Card topCard, int iD, bool isWinner) 
            : base(deck, numOfPlayers, listOfCards, topCard, iD, isWinner)
        {
        }

        public override int ChooseAttributes(Card topCard, string attribute)
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
            return this.listOfCards.Count;
        }
    }
}
