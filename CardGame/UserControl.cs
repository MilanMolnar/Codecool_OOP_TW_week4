using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        public void PrintRankedPlayers(List<Player> players)
        {
            int count = 1;
            foreach (var player in players)
            {
                Console.WriteLine($"[{count}.] PlayerName: {player.Name}");
                count++;
            }
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
                    Console.WriteLine($"The winner is: {player.Name}!");
                }
                else
                {
                    Console.WriteLine($"{count}.place is {player.Name}");
                }

                count++;
            }
        }
        public void PrintPlayersTopCard(string name, List<Player> players)
        {
            foreach (var player in players)
            {
                if (player.Name == name)
                {
                    Console.WriteLine($"Player's ({player.Name}) top card: {player.topCard}");
                }
                else
                {
                    Console.WriteLine("There is no naem that corresponds to the input");
                }
            }
        }
        public void PrintCards(List<Card> cards)
        {
            int count = 1;
            foreach (var card in cards)
            {
                Console.WriteLine($"[{count}] Card's name: {card.Name}");
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
            Info("Number must be lesser than the number of players");
            Input("How many players wants to play: ");
            int numOfPlayer = Convert.ToInt32(Console.ReadLine());
            if (numOfPlayer < 2)
            {
                throw new Exception("");
            }
            return numOfPlayer;
        }
        public int AskForBotPlayers()
        {
            Console.WriteLine();
            Info("Must be lower than the number of players!");
            Input("How many of the players you want to be bot: ");
            int numOfBotPlayers = Convert.ToInt32(Console.ReadLine());
            return numOfBotPlayers;
        }
        public string ChooseAttribute(Player player)
        {
            Console.WriteLine($" {player.Name}'s turn: ");
            if (player is HumanPlayer)
            {
                PrintCardWithAttributes(player.topCard);
                Console.WriteLine();
                Console.Write($"Decide which attribute you want to fight with [hp/attack/defend/speed]: p");
                return Console.ReadLine();
            }
            else
            {
                Random rand = new Random();
                string[] attributes = new string[] { "hp", "attack", "defend", "speed" };
                return attributes[rand.Next(0, 4)];
            }
        }
        public void PrintWinner(Player winner)
        {
            Console.WriteLine($"The winner is {winner.Name}!");
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
    }
}
