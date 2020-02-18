using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CardGame
{
    public class Round
    {
     
        private List<Player> listOfPlayers;
        public int StarterPlayer { get; set; }
        private List<Card> _listOfTopCards;
        public List<Card> ListOfTopCards = new List<Card>();

        public Round(List<Player> playersList)
        {
            this.listOfPlayers = playersList;
            ListOfTopCards = new List<Card>();
        }
        public void GetTopCards(List<Player> players)
        {
            foreach (var player in players)
            {
                ListOfTopCards.Add(player.GetTopCard());
            }
        }
        public List<Player> GetRankList(List<Player> players)
        {
            IEnumerable<Player> ordered = players.OrderByDescending(player => player.GetCardCount());
            return ordered.ToList();
        }
        public bool IsNextRound(List<Player> players)
        {
            foreach (var player in players)
            {
                if (player.GetCardCount() == 0)
                {
                    return false;
                }
                return true;
            }
            throw new Exception("NoPlayerException");
        }
    }
}
