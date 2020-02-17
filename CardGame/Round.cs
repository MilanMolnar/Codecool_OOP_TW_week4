using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CardGame
{
    class Round
    {
        public Round(List<Player> listOfPlayers)
        {
            this.listOfPlayers = listOfPlayers;
        }
        private List<Player> listOfPlayers = new List<Player>();
        public int StarterPlayer { get; set; }
        private List<Card> _listOfTopCards = new List<Card>();

        public List<Card> ListOfTopCards
        {
            get { return _listOfTopCards; }
            set { _listOfTopCards = value; }
        }
        public void GetTopCards(List<Player> players)
        {
            foreach (var player in players)
            {
                ListOfTopCards.Add(player.TopCard);
            }
        }
        public List<Player> GetRankList(List<Player> players)
        {
            IEnumerable<Player> ordered = players.OrderBy(player => player.GetCardCount());
            return ordered.ToList();
        }
        public bool IsNextRound(List<Player> players)
        {
            foreach (var player in players)
            {
                if (player.listOfCards.Count == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
