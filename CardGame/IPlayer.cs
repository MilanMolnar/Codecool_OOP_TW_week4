using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    interface IPlayer
    {
        int ChooseAttributes(Card topCard,string attribute);
        void TakeCards(List<Card> topCards);
    }
}
