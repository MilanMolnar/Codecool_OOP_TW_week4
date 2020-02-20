using System;
using System.Collections.Generic;
using System.IO;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmp = new CardComparer.SortByNumOfCards();
            var usr = new UserControl();
            var table = new Table();

            Menu menu = new Menu();
            GameManager gm;

            gm = menu.MainMenu();



            usr.PrintStarterInformation();
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
                catch (NullNameException)
                {
                    usr.Error("Name not found!");
                }
                catch (NotEnoughCardException)
                {
                    usr.Error("Not enough cards for players!\n\n");
                }
                catch (WrongAttributeException)
                {
                    usr.Error("Wrong attribute!\n\n");
                }
            }
            var result = gm.GetPlayers();
            result.Sort(cmp);
            usr.PrintPlayersByRanks(result);
        }
    }
}
