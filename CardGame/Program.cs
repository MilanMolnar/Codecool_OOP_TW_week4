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

            int numberOfPlayers;
            int numberOfBots;
            GameManager gm;
            while (true)
            {
                try
                {
                    numberOfPlayers = usr.AskPlayersForNumOfPlayer();
                    break;
                }
                catch (NotValidPlayerException)
                {
                    usr.Error("Players number must be 2 or greater!\n\n");
                }
            }

            while(true)
            { 
                try
                {
                    numberOfBots = usr.AskForBotPlayers(numberOfPlayers);
                    break;
                }
                catch (NotValidBotException)
                {
                    usr.Error("Bots number are greater than playable slots!\n\n");
                }
            }

           
            deck = new Deck();
            gm = new GameManager(numberOfPlayers, numberOfBots, deck);
           

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
                catch(NullNameException)
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
        }
    }
}
