using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    class Deck
    {
        private List<Card> allCards;

        public Deck()
        {
            allCards = new List<Card>();
            LoadCards();
            Shuffle();
        }

        private void LoadCards()
        {

        }

        private void Shuffle()
        {
            var shuffled = allCards.OrderBy(x => Guid.NewGuid()).ToList();
        }
        public List<Card> DealCards(int numOfPlayers)
        {
            var result = new List<Card>();

            for (int i = 0; i < allCards.Count / numOfPlayers; i++)
            {
                result.Add(allCards[i]);
            }

            allCards = allCards.Except(result).ToList(); //remove the player cards from the deck 
            return result;
        }
    }
}
