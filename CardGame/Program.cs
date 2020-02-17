using System;
using System.Collections.Generic;
using System.IO;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> playerList = new List<Player>();
            var deck = new Deck();
            Console.Write("How many players are in this round: ");
            var numOfPlayers = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numOfPlayers; i++)
            {
                playerList.Add(new Player(deck, numOfPlayers));
            }

            foreach (var player in playerList)
            {
                Console.Write(player + ": ");
                foreach (var card in player.listOfCards)
                {
                    Console.WriteLine(card.Attack);
                }
            }
        }
    }
}
