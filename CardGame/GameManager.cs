using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class GameManager
    {
        List<Player> playerList = new List<Player>();
        int NumOfPlayers { get; set; }
        int NumOfBotPlayers { get; set; }
        Deck deck;
        public UserControl userControl = new UserControl();
        public Player PrevRoundWinner { get; set; }
        public List<Card> currentListOfCards;
        public GameManager() { }
        public GameManager(List<Player> plist)
        {
            this.playerList = plist;
        }
        public GameManager(int numOfPlayers, int NumOfBotPlayers)
        {
            this.NumOfPlayers = numOfPlayers;
            this.NumOfBotPlayers = NumOfBotPlayers;
            this.deck = new Deck();
            AddPlayers();
            GetTopCards();
        }
        public List<Card> GetCards()
        {
            Deck deck = new Deck();
            return deck.allCards;
        }
        public void AddPlayers()
        {
            for (int count = 0; count < NumOfPlayers; count++)
            {
                if (count < NumOfPlayers - NumOfBotPlayers)
                {
                    string name = userControl.GetName();
                    if (name.Equals(""))
                    {
                        name = "Player" + count;
                    }
                    HumanPlayer human = new HumanPlayer(deck, NumOfPlayers, name);
                    playerList.Add(human);
                }
                else
                {
                    BotPlayer bot = new BotPlayer(deck, NumOfPlayers,
                        "BOT" + (count - (NumOfPlayers - NumOfBotPlayers) + 1));
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
            else if (attribute.ToLower().Equals("speed"))
            {
                comparer = new CardComparer.SpeedComparer();
            }
            else
            {
                throw new WrongAttributeException();
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
                if (player.topCard.Equals(card))
                {
                    return player;
                }
            }
            throw new NullNameException();
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
