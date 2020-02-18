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
        private List<Card> _listOfTopCards = new List<Card>();

        public List<Card> ListOfTopCards
        {
            get { return _listOfTopCards; }
            set { _listOfTopCards = value; }
        }
        public Round(List<Player> playersList)
        {
            PlayerManager playerManager = new PlayerManager();
            playerManager
            this.listOfPlayers =
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
