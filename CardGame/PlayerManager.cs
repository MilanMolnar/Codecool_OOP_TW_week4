using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class PlayerManager
    {
        List<Player> playerList= new List<Player>();
        int NumOfPlayers { get; set; }
        int NumOfBotPlayers { get; set; }
        Deck deck;
        public UserControl userControl = new UserControl();
        public Player PrevRoundWinner { get; set; }
        public PlayerManager(int numOfPlayers, int NumOfBotPlayers, Deck deck)
        {
            this.NumOfPlayers = numOfPlayers;
            this.NumOfBotPlayers = NumOfBotPlayers;
            this.deck = deck;
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

    }
}
