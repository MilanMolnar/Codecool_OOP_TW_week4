using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CardGame
{
    //Loading Cards from XML file
    class XmlLoader : IDocumentLoader
    {
        //Creating the card objects and returning the list of cards from the xml nodes
        public List<Card> LoadCards(string path)
        {
            List<Card> ListOfCards = new List<Card>();
            XElement element = XElement.Load(path);//string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/CardGame/Cards.xml");
            var cardNodes = element.Elements("Card");
            int hp; int atk; int def; int speed;
            foreach (var node in cardNodes)
            {
                hp = Convert.ToInt32(node.Element("HP").Value);
                atk = Convert.ToInt32(node.Element("Atk").Value);
                def = Convert.ToInt32(node.Element("Def").Value);
                speed = Convert.ToInt32(node.Element("Speed").Value);
                Card card = new Card(hp, atk, def, speed);
                ListOfCards.Add(card);
            }
            return ListOfCards;
        }
    }
}
