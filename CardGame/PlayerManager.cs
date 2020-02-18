using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class PlayerManager
    {
        List<Player> playerList;
        int NumOfPlayers { get; set; }
        int NumOfBotPlayers { get; set; }
        Deck deck;
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
                if(count<=numOfPlayers-NumOfBotPlayers)
                {
                    UserControl userControl = new UserControl();
                    string name=userConstrol
                    HumanPlayer human = new HumanPlayer(deck, numOfPlayers, name, false);
                    playerList.Add(human);
                }
                else
                {
                    BotPlayer bot = new BotPlayer(deck, numOfPlayers, "BOT"+count, false);
                    playerList.Add(bot);
                }
            }
        }
    }
}
