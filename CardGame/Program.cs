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
            var gm = new GameManager(usr.AskPlayersForNumOfPlayer(), usr.AskForBotPlayers(), deck);

            while (true)
            {
                try
                { 
                    gm.RoundLogic(usr.ChooseAttribute(gm.PrevRoundWinner), gm.currentListOfCards, table);
                    if (gm.IsNextRound())
                    {
                        gm.GetTopCards();
                    }
                    else
                    {
                        break;
                    }
                }
                catch(Exception e)
                {
                    usr.PrintErrorMessage(e);
                }
            }

            var result = gm.GetPlayers();
            result.Sort(cmp);
            usr.PrintPlayers(result);

            //while(true) : round


            //if(!Round.IsNextRound): break

            //printing winner
















        }
    }
}
