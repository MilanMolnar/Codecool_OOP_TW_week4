using System;
using System.Collections.Generic;
using System.IO;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<HumanPlayer> playerList = new List<HumanPlayer>();
            var deck = new Deck();
            Console.Write("How many players are in this round: ");
            var numOfPlayers = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numOfPlayers; i++)
            {
                playerList.Add((new HumanPlayer(deck, numOfPlayers));
            }

            foreach (var player in playerList)
            {
                Console.Write(player + ": ");
                foreach (var card in player.listOfCards)
                {
                    Console.WriteLine("Attack: "+card.Attack);
                    Console.WriteLine("Hp: "+card.HP);
                    Console.WriteLine("Def: "+card.Defend);
                    Console.WriteLine("Speed: "+card.Speed);
                    Console.WriteLine();
                }
            }
        }
    }
}
