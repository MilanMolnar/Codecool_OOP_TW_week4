using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
   public class UserControl
    {
        public void PrintPlayers(List<Player> players)
        {
            int count = 1;
            foreach (var player in players)
            {
                Console.WriteLine($"[{count}.] Player ID: {player.Name}");
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
                    Console.WriteLine("There is no name that corresponds to the input");
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
            Console.Write("How many players wants to play: ");
            int numOfPlayer = Convert.ToInt32(Console.ReadLine());
            if(numOfPlayer<2)
            {
                throw new Exception("NotValidNumberForPlayers");
            }
            return numOfPlayer;
        }
        public int AskForBotPlayers()
        {
            Console.Write("How many of them are bots: ");
            int numOfBotPlayers = Convert.ToInt32(Console.ReadLine());
            return numOfBotPlayers;
        }
        public string ChooseAttribute(Player player)
        {
            if(player is HumanPlayer)
            { 
                PrintCardWithAttributes(player.topCard);
                Console.WriteLine();
                Console.Write("Decide which attribute you want to fight with: ");
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
            Console.Write("What is your names: ");
            return Console.ReadLine();
        }

        public void PrintErrorMessage()
        {
            Console.WriteLine($"\nERROR\\:InvadlidInput\n");
        }
    }
}
