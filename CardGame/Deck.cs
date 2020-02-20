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
            //int maxHp = 0;
            //int maxAttack = 0;
            //int maxDefense = 0;
            //int maxSpeed = 0;
            //foreach(var card in allCards)
            //{
            //    if(card.Attack>maxAttack)
            //    {
            //        maxAttack = card.Attack;
            //    }

            //    if(card.Defend>maxDefense)
            //    {
            //        maxDefense = card.Defend;
            //    }

            //    if(card.HP>maxHp)
            //    {
            //        maxHp = card.HP;
            //    }

            //    if(card.Speed>maxSpeed)
            //    {
            //        maxSpeed = card.Speed;
            //    }
            //}

            MaxValuesForAttributes = new List<int> { allCards.Max(Card => Card.HP), allCards.Max(Card => Card.Attack),
                allCards.Max(Card => Card.Defend), allCards.Max(Card => Card.Speed) };
        }
    }
}