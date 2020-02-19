using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class PlayerManager
    {
        List<Player> playerList = new List<Player>();
        int NumOfPlayers { get; set; }
        int NumOfBotPlayers { get; set; }
        Deck deck;
        public UserControl userControl = new UserControl();
        public Player PrevRoundWinner { get; set; }
        public List<Card> currentListOfCards;
        public PlayerManager(int numOfPlayers, int NumOfBotPlayers, Deck deck)
        {
            this.NumOfPlayers = numOfPlayers;
            this.NumOfBotPlayers = NumOfBotPlayers;
            this.deck = deck;
            AddPlayers();
            GetTopCards();
        }
        public void AddPlayers()
        {
            for (int count = 0; count < NumOfPlayers; count++)
            {
                if (count < NumOfPlayers - NumOfBotPlayers)
                {
                    string name = userControl.GetName();
                    HumanPlayer human = new HumanPlayer(deck, NumOfPlayers, name);
                    playerList.Add(human);
                }
                else
                {
                    BotPlayer bot = new BotPlayer(deck, NumOfPlayers,
                        "BOT" + (count - (NumOfPlayers - NumOfBotPlayers)));
                    playerList.Add(bot);
                }
            }
            this.PrevRoundWinner = playerList[0];
        }
        public List<Player> GetPlayers()
        {
            return playerList;
        }

        public void RoundLogic(string attribute, List<Card> listOfTopCards, Table table)
        {
            IComparer<Card> comparer;
            if (attribute.ToLower().Equals("hp"))
            {
                comparer = new CardComparer.HPComparer();
            }
            else if (attribute.ToLower().Equals("attack"))
            {
                comparer = new CardComparer.AttackComparer();
            }
            else if (attribute.ToLower().Equals("defend"))
            {
                comparer = new CardComparer.DefendComparer();
            }
            else
            {
                comparer = new CardComparer.SpeedComparer();
            }
            listOfTopCards.Sort(comparer);

            if (comparer.Compare(listOfTopCards[0], listOfTopCards[1]) == 0)
            {
                table.AddCardsToTable(listOfTopCards);
            }
            else
            {
                PrevRoundWinner = SearchWinner(listOfTopCards[0]);
                listOfTopCards.AddRange(table.GetCardsFromTable());
                table.EmptyTable();
                PrevRoundWinner.TakeCards(listOfTopCards);
            }
            foreach (var player in playerList)
            {
                player.RemoveCard();
            }
        }
        public Player SearchWinner(Card card)
        {
            foreach (var player in playerList)
            {
                Console.WriteLine($"Jatekos kartyaja: {player.topCard.Name} legmagasabb lap:{card.Name}");
                if (player.topCard.Equals(card))
                {
                    return player;
                }
            }
            throw new Exception("Not valid search");
        }
        public void GetTopCards()
        {
            currentListOfCards = new List<Card>();
            foreach (var player in playerList)
            {
                currentListOfCards.Add(player.GetTopCard());
            }
        }
        public bool IsNextRound()
        {
            foreach (var player in playerList)
            {
                if (player.GetCardCount() == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
