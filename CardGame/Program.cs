using System;
using System.Collections.Generic;
using System.IO;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var cc = new CardComparer.SortByNumOfCards();
            var uc = new UserControl();
            var table = new Table();
            int roundNumber = 1;

            Menu menu = new Menu();
            GameManager gm;

            gm = menu.MainMenu();



            uc.PrintStarterInformation();
            while (true)
            {
                uc.PrintRoundNumber(roundNumber);
                try
                {
                    gm.RoundLogic(uc.ChooseAttribute(gm.PrevRoundWinner), gm.currentListOfCards, table);
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
                    uc.Error("Name not found!");
                }
                catch (NotEnoughCardException)
                {
                    uc.Error("Not enough cards for players!\n\n");
                }
                catch (WrongAttributeException)
                {
                    uc.Error("Wrong attribute!\n\n");
                }
                uc.PrintRoundWinner(gm.PrevRoundWinner, roundNumber);
                roundNumber++;
            }
            var result = gm.GetPlayers();
            result.Sort(cc);
            uc.PrintPlayersByRanks(result);
        }
    }
}
