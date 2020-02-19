using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CardGame
{
    public class Round
    {
        List<Card> currentListOfCards = new List<Card>();
        string selectedAttribute;
        Player prevRoundWinner;
        //playerManager.userControl.
        List<Player> listOfPlayers;
        GameManager playerManager;
        public Round(GameManager playerManager)
        {
            this.playerManager = playerManager;
            listOfPlayers = playerManager.GetPlayers();
            this.prevRoundWinner = playerManager.PrevRoundWinner;
            this.selectedAttribute = playerManager.userControl.ChooseAttribute(prevRoundWinner);
        }

        public void GetTopCards(List<Player> players)
        {

            foreach (var player in players)
            {
                currentListOfCards.Add(player.GetTopCard());
            }
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
            foreach (var player in listOfPlayers)
            {
                if (player.listOfCards.Contains(currentListOfCards[currentListOfCards.Count - 1]))
                {
                    return player;
                }
            }
            throw new Exception("NotValidSearch");
        }

        public bool IsNextRound()
        {
            foreach (var player in listOfPlayers)
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
