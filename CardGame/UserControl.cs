using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ConsoleTables;

namespace CardGame
{
    public class UserControl
    {
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("INFO: ");
            Console.ResetColor();
            Console.WriteLine(message);
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR: ");
            Console.ResetColor();
            Console.Write(DateTime.Now.ToString("yyyy-mm-ddThh:mm:ss: "));
            Console.WriteLine(message);
        }
        public void Input(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("INPUT: ");
            Console.ResetColor();
            Console.Write(message);
        }

        public void PrintPlayersByRanks(List<Player> players)
        {
            Console.Clear();
            Info("The game is over!\n");
            int count = 1;
            foreach (var player in players)
            {
                if (count == 1)
                {
                    Console.WriteLine($"The winner is: {player.Name}:\t\t{player.listOfCards.Count}");
                }
                else
                {
                    Console.WriteLine($"{count}.place is {player.Name}:\t\t{player.listOfCards.Count}");
                }
                count++;
            }
        }

        public void PrintCardWithAttributes(Card card)
        {
            Console.WriteLine($"Card Name: {card.Name}:");
            Console.WriteLine($"\tHP: {card.HP}");
            Console.WriteLine($"\tAttack: {card.Attack}");
            Console.WriteLine($"\tDeffense: {card.Defend}");
            Console.WriteLine($"\tSpeed: {card.Speed}");
        }
        public int AskPlayersForNumOfPlayer()
        {
            Info("Number must be a positive whole number");
            Input("Specify the number of players: ");

            int numOfPlayer;
            if (int.TryParse(Console.ReadLine(), out numOfPlayer))
            {
                if (numOfPlayer < 2)
                {
                    throw new NotValidPlayerException();
                }
                return numOfPlayer;
            }
            else
            {
                throw new NotValidPlayerException();
            }
        }
        public int AskForBotPlayers(int numberOfPlayers = int.MaxValue)
        {
            Console.WriteLine();
            if (numberOfPlayers != int.MaxValue)
            {
                Input($"Number must be fewer than {numberOfPlayers}.\n");
            }
            Input("How many of the players you want to be bot: ");

            int numOfBotPlayers;
            if (int.TryParse(Console.ReadLine(), out numOfBotPlayers))
            {
                if (numOfBotPlayers > numberOfPlayers)
                {
                    throw new NotValidBotException();
                }
                return numOfBotPlayers;
            }
            else
            {
                throw new NotValidBotException();
            }
        }
        public string ChooseAttribute(Player player)
        {
            Console.WriteLine($" {player.Name}'s turn: ");
            if (player is HumanPlayer)
            {
                PrintCardWithAttributes(player.topCard);
                Console.WriteLine();
                Console.Write($"Decide which attribute you want to fight with [hp/attack/defend/speed]: ");
                return Console.ReadLine();
            }
            else
            {
                BotPlayer botPlayer = (BotPlayer)player;

                Thread.Sleep(500);
                PrintCardWithAttributes(player.topCard);
                Thread.Sleep(500);
                Info($"{player.Name} is choosing...");
                Thread.Sleep(1000);

                string chosenAttribute = botPlayer.ChoosenAttribute(player);

                Info($"{player.Name} choose: {chosenAttribute}");
                Thread.Sleep(500);
                return chosenAttribute;
            }
        }

        public string GetName()
        {
            Input("What is your name: ");
            return Console.ReadLine();
        }

        public void PrintStarterInformation()
        {
            Info("Shuffeling cards...");
            Thread.Sleep(500);
            Info("Dealing cards to players...");
            Thread.Sleep(500);
        }
        public void DisplayDeck(List<Card> deck)
        {
            Console.Clear();
            var ct = new ConsoleTable("CARDNAME", "HEALTH", "ATTACK", "DEFENSE", "SPEED");
            foreach (var card in deck)
            {
                ct.AddRow(card.Name, card.HP, card.Attack, card.Defend, card.Speed);
            }
            ct.Write();
            Input("Press any button to close deck display...");
            Console.ReadLine();
            Console.Clear();
        }
        public void PrintRoundWinner(Player winner, int round)
        {
            Info($"Round [{round}] Winner is {winner.Name}\tCards: {winner.listOfCards.Count}\n");
        }
        public void PrintRoundNumber(int round)
        {
            Info($"Round[{round}]----------------\n");
            Thread.Sleep(1000);
        }
        public void GoToRankList(List<Player> players)
        {
            Console.WriteLine();
            string winner = players[0].Name;
            Info($"The winner is {winner}.\nPress ENTER to continue to ranklist.");
            Console.ReadLine();
        }
    }
}
