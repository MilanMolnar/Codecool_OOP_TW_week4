using NUnit.Framework;
using System.Collections.Generic;
using CardGame;
using System.Linq;

namespace CardGamesTest
{
    public class Tests
    {

        [Test]
        public void ComparerTest_ListWithFourElement_ShouldBeOrderedDescending()
        {
            var hpCompare = new CardComparer.HPComparer();
            var clist = new List<Card> {
                new Card(1, 1, 1, 1, "c1"),
                new Card(4, 4, 4, 4, "c4"),
                new Card(3, 3, 3, 3, "c3"),
                new Card(2, 2, 2, 2, "C2")};

            var expectedList = clist.OrderByDescending(x => x.HP);
            clist.Sort(hpCompare);

            Assert.IsTrue(expectedList.SequenceEqual(clist));
        }
        [Test]
        public void GetMaxValuesTest_BotMaxValuesCompareToMaxValues_ShouldBeTheSame()
        {
            var expectedList = new List<int> { 2210, 321, 423, 432 };
            var player = new BotPlayer(new Deck(), 3, "Boti");

            var actualList = new List<int> { player.Hp, player.Attack, player.Defense, player.Speed };

            Assert.IsTrue(expectedList.SequenceEqual(actualList));
        }
        [Test]
        public void NextRoundTest_EmptyCardList_ReturnFalse()
        {
            var deck = new Deck();
            var players = new List<Player> {
            new BotPlayer(deck, 3, "Boti"),
            new BotPlayer(deck, 3, "oti"),
            new BotPlayer(deck, 3, "ti")};
            players[2].listOfCards = new List<Card>();
            var gm = new GameManager(players);

            var result = gm.IsNextRound();

            Assert.IsFalse(result);
        }
        [Test]
        public void NextRoundTest_NoEmptyCardList_ReturnTrue()
        {
            var deck = new Deck();
            var players = new List<Player> {
            new BotPlayer(deck, 3, "Boti"),
            new BotPlayer(deck, 3, "oti"),
            new BotPlayer(deck, 3, "ti")};
            players[2].listOfCards = new List<Card>();
            var gm = new GameManager(players);

            var result = gm.IsNextRound();

            Assert.IsFalse(result);
        }
        [Test]
        public void RoundLogicTest_Wrongattribute_ShouldThrowException()
        {
            var gm = new GameManager();

            Assert.Throws<WrongAttributeException>(() => gm.RoundLogic("wrongInput", new List<Card>(), new Table()));
        }

    }
}

