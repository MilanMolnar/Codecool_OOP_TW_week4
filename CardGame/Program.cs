using System;
using System.Collections.Generic;
using System.IO;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/CardGame/Cards.xml");
            XmlLoader xmlLoader = new XmlLoader();
            List<Card> ListOfCards = xmlLoader.LoadCards(path);
            foreach (var card in ListOfCards)
            {
                Console.WriteLine(card.Attack);
            }
        }
    }
}
