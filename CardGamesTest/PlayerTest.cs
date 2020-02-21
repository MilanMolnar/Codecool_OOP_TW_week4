using NUnit.Framework;
using System.Collections.Generic;
using CardGame;
using System.Linq;

namespace CardGamesTest
{
    class PlayerTest
    {
        [Test]
        public void TakeCardsTest_Take4Cards1Player_ShuldBe38()
        {
            var bot = new BotPlayer(new Deck(), 1, "Boti");
            var clist = new List<Card> {
                new Card(1, 1, 1, 1, "c1"),
                new Card(4, 4, 4, 4, "c4"),
                new Card(3, 3, 3, 3, "c3"),
                new Card(2, 2, 2, 2, "C2")};

            bot.TakeCards(clist);

            Assert.AreEqual(38, bot.GetCardCount());
        }
        [Test]
        public void GetCardCount_2Players_17Cards()
        {
            var bot = new BotPlayer(new Deck(), 2, "Boti");

            Assert.AreEqual(17, bot.GetCardCount());
        }
        [Test]
        public void GetTopCard_ShouldReturnTheCardICreate()
        {
            var bot = new BotPlayer(new Deck(), 2, "Boti");
            var cardToReturn = new Card(1, 1, 1, 1, "c1");
            bot.listOfCards[0] = cardToReturn;

            var result = bot.GetTopCard();

            Assert.AreEqual(cardToReturn, result);
        }
        [Test]
        public void RemoveCardTest_AddTwoNewCardRemoveOne_GetTopShoudBeTheSecond()
        {
            var bot = new BotPlayer(new Deck(), 2, "Boti");
            var cardToReturn = new Card(1, 2, 4, 1, "c1");
            var cardToRemove = new Card(1, 1, 1, 1, "c2r");
            bot.listOfCards[1] = (cardToReturn);
            bot.listOfCards[2] = (cardToRemove);

            bot.RemoveCard();
            var result = bot.GetTopCard();

            Assert.AreEqual(cardToReturn, result);
        }
    }

}
