using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        public List<int> MaxValuesForAttributes { get; set; }
        public List<Card> allCards { get; private set; }
        private int numOfAllCards;
        public Deck()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "/CardGame/Cards.xml");
            allCards = new XmlLoader().LoadCards(path);
            numOfAllCards = allCards.Count();
            Shuffle();
            SetMaxValues();
        }

        private void Shuffle()
        {
            allCards = allCards.OrderBy(x => Guid.NewGuid()).ToList();
        }
        public List<Card> DealCards(int numOfPlayers)
        {
            if (numOfPlayers > numOfAllCards)
            {
                throw new NotEnoughCardException();
            }
            var result = new List<Card>();

            for (int i = 0; i < numOfAllCards / numOfPlayers; i++)
            {
                result.Add(allCards[i]);
            }
            allCards = allCards.Except(result).ToList(); //remove the player cards from the deck 
            return result;
        }

        public void SetMaxValues()
        {
            MaxValuesForAttributes = new List<int> { allCards.Max(Card => Card.HP), allCards.Max(Card => Card.Attack),
                allCards.Max(Card => Card.Defend), allCards.Max(Card => Card.Speed) };
        }
    }
}