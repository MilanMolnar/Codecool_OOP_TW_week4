using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Menu
    {
        public static int index = 0;
        UserControl uc = new UserControl();
        public GameManager MainMenu()
        {
            //Menü elemeinek listája
            List<string> menuItems = new List<string>()
            {"PLAYERS VS PLAYERS",
            "PLAYERS VS BOTS",
            "SIMULATION",
            "DISPLAY ALL CARD",
            "EXIT"};
            //A kurzor eltüntetése a menü kiiratásnál
            Console.CursorVisible = false;

            //Menü ciklus
            while (true)
            {
                string selectedMenuItem = drawMenu(menuItems);
                if (selectedMenuItem == "PLAYERS VS PLAYERS")
                {
                    while(true)
                    { 
                        try
                        {
                            return new GameManager(uc.AskPlayersForNumOfPlayer(), 0);
                        }
                        catch(NotValidPlayerException)
                        {
                            uc.Error("Invalid player number format!");
                        }
                    }
                }
                else if (selectedMenuItem == "PLAYERS VS BOTS")
                {
                    while(true)
                    {
                        int numOfPlayers=0;
                        try
                        {
                            numOfPlayers = uc.AskPlayersForNumOfPlayer();
                        }
                        catch (NotValidPlayerException)
                        {
                            uc.Error("Invalid player number format!");
                            continue;
                        }

                        try
                        {
                            return new GameManager(numOfPlayers, uc.AskForBotPlayers(numOfPlayers));
                        }
                        catch(NotValidBotException)
                        {
                            uc.Error("Invalid bot number format!");
                        }
                    }
                }
                else if (selectedMenuItem == "SIMULATION")
                {
                    try
                    { 
                        int numOfBots = uc.AskForBotPlayers();
                        return new GameManager(numOfBots, numOfBots);
                    }
                    catch (NotValidBotException)
                    {
                        uc.Error("Invalid bot number format!");
                    }
                }
                else if (selectedMenuItem == "DISPLAY ALL CARD")
                {
                    GameManager gm = new GameManager();
                    uc.DisplayDeck(gm.GetCards());
                }

                else if (selectedMenuItem == "EXIT")
                {
                    Environment.Exit(0);
                }
            }
        }
        //Menü kirajzolásáért felelős függvény
        private static string drawMenu(List<string> items)
        {
            Console.WriteLine("\n\n\n\n");
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(">");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("      ");
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine($"      {items[i]}");
                }
                Console.ResetColor();
            }
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                {
                    index = 0; //Az elejére ugrik
                }
                else { index++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                    index = items.Count - 1;  //A végére ugrik
                }
                else { index--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[index];
            }
            else
            {
                return "";
            }
            Console.Clear();
            return "";
        }
    }
}


