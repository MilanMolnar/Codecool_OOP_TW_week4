using System;
using System.Collections.Generic;
using System.IO;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck deck = new Deck();
            var cmp = new CardComparer.SortByNumOfCards();
            var usr = new UserControl();
            var table = new Table();
            var playerM = new PlayerManager(usr.AskPlayersForNumOfPlayer(), usr.AskForBotPlayers(), deck);

            while (true)
            {
                playerM.RoundLogic(usr.ChooseAttribute(playerM.PrevRoundWinner), playerM.currentListOfCards, table);
                if (playerM.IsNextRound())
                {
                    playerM.GetTopCards();
                }
                else
                {
                    break;
                }
            }

            var result = playerM.GetPlayers();
            result.Sort(cmp);
            usr.PrintPlayers(result);

            //while(true) : round


            //if(!Round.IsNextRound): break

            //printing winner
















        }
    }
}
