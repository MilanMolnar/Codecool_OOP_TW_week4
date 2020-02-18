﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public abstract class Player
    {

        public List<Card> listOfCards;

        protected Player(Deck deck,int numOfPlayer, string name, bool isWinner)
        {
            this.listOfCards = deck.DealCards(numOfPlayer);
            this.Name = name;
            this.isWinner = isWinner;
        }
        public Card topCard { get { return listOfCards[0]; } }
        string Name { get; set; }
        bool isWinner { get; set; }
        abstract public int ChooseAttributes(string attribute);
        abstract public void TakeCards(List<Card> topCards);
        abstract public int GetCardCount();
        abstract public Card GetTopCard(); 
    }
}
