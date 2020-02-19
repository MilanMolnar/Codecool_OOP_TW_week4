using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class GameManager
    {
        List<Player> playerList= new List<Player>();
        int NumOfPlayers { get; set; }
        int NumOfBotPlayers { get; set; }
        Deck deck;
        public UserControl userControl = new UserControl();
        public Player PrevRoundWinner { get; set; }
        List<Card> currentListOfCards;
        string selectedAttribute;
        public GameManager(int numOfPlayers, int NumOfBotPlayers, Deck deck)
        {
            this.NumOfPlayers = numOfPlayers;
            this.NumOfBotPlayers = NumOfBotPlayers;
            this.deck = deck;
            this.currentListOfCards = new List<Card>();
        }
        public void AddPlayers(int numOfPlayers, int NumOfBotPlayers, Deck deck)
        {
            for(int count=0;count<numOfPlayers;count++)
            {
                if(count<numOfPlayers-NumOfBotPlayers)
                {
                    string name = userControl.GetName();
                    HumanPlayer human = new HumanPlayer(deck, numOfPlayers, name);
                    playerList.Add(human);
                }
                else
                {
                    BotPlayer bot = new BotPlayer(deck, numOfPlayers,
                        "BOT"+(count-(numOfPlayers-NumOfBotPlayers)));
                    playerList.Add(bot);
                }
            }
            this.PrevRoundWinner = playerList[0];
        }
        public List<Player> GetPlayers()
        {
            return playerList;
        }

        public List<Card> SortByAttribute(string attribute, List<Card> listOfTopCards)
        {
            if (attribute.ToLower().Equals("hp"))
            {
                CardComparer.HPComparer comparer = new CardComparer.HPComparer();
                listOfTopCards.Sort(comparer);

                return listOfTopCards;
            }

            else if (attribute.ToLower().Equals("attack"))
            {
                CardComparer.AttackComparer comparer = new CardComparer.AttackComparer();
                listOfTopCards.Sort(comparer);

                return listOfTopCards;
            }

            else if (attribute.ToLower().Equals("defend"))
            {
                CardComparer.DefendComparer comparer = new CardComparer.DefendComparer();
                listOfTopCards.Sort(comparer);

                return listOfTopCards;
            }

            else
            {
                CardComparer.SpeedComparer comparer = new CardComparer.SpeedComparer();
                listOfTopCards.Sort(comparer);

                return listOfTopCards;
            }
        }










        public void StartNewRound()
        {
            GetTopCards();
            this.selectedAttribute=userControl.ChooseAttribute(PrevRoundWinner);
        }


        public void GetTopCards()
        {

            foreach (var player in playerList)
            {
                currentListOfCards.Add(player.GetTopCard());
            }
        }


        public void Compare()
        {
            //sorting
            currentListOfCards = SortByAttribute(selectedAttribute, currentListOfCards);
        }

        public bool IsDraw()
        {
            if (selectedAttribute.Equals("hp"))
            {
                if (currentListOfCards[currentListOfCards.Count - 1].HP ==
                    currentListOfCards[currentListOfCards.Count - 2].HP)
                {
                    return true;
                }
            }
            else if (selectedAttribute.Equals("attack"))
            {
                if (currentListOfCards[currentListOfCards.Count - 1].Attack ==
                    currentListOfCards[currentListOfCards.Count - 2].Attack)
                {
                    return true;
                }
            }
            else if (selectedAttribute.Equals("defend"))
            {
                if (currentListOfCards[currentListOfCards.Count - 1].Defend ==
                    currentListOfCards[currentListOfCards.Count - 2].Defend)
                {
                    return true;
                }
            }
            else
            {
                if (currentListOfCards[currentListOfCards.Count - 1].Speed ==
                    currentListOfCards[currentListOfCards.Count - 2].Speed)
                {
                    return true;
                }
            }
            return false;
        }


        public Player SearchWinner()
        {
            foreach (var player in playerList)
            {
                if (player.listOfCards.Contains(currentListOfCards[0]))
                {
                    return player;
                }
            }
            throw new Exception("NotValidSearch");
        }

        public bool IsNextRound()
        {
            foreach (var player in playerList)
            {
                if (player.GetCardCount() == 0)
                {
                    return false;
                }
                return true;
            }
            throw new Exception("NoPlayerException");
        }

        //winner choosing attribute
        //choose the winner (if draw do an another round)
        //then empty the table

    }
}
}
