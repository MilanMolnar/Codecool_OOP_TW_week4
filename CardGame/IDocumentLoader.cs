using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    interface IDocumentLoader
    {
        
        public List<Card> LoadCards(string path);
    }
}
