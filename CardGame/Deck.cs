using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        public List<Card> allCards { get; private set; }
        private int numOfAllCards;

        public Deck()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "/CardGame/Cards.xml");
            allCards = new XmlLoader().LoadCards(path);
            numOfAllCards = allCards.Count();
            Shuffle();
        }


        private void Shuffle()
        {
            allCards = allCards.OrderBy(x => Guid.NewGuid()).ToList();
        }
        public List<Card> DealCards(int numOfPlayers)
        {
            if (numOfPlayers > numOfAllCards)
            {
                throw new Exception("NotEnoughCardException");
            }
            var result = new List<Card>();

            for (int i = 0; i < numOfAllCards / numOfPlayers; i++)
            {
                result.Add(allCards[i]);
            }

            allCards = allCards.Except(result).ToList(); //remove the player cards from the deck 
            return result;
        }
    }
}
