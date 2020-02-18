using NUnit.Framework;
using System.Collections.Generic;
using CardGame;

namespace CardGamesTest
{
    public class Tests
    {
        [Test]
        public void RoundGetRankListTest()
        {
            Deck d = new Deck();
            HumanPlayer p1 = new HumanPlayer(d, 2);
            Deck d2 = new Deck();
            HumanPlayer p2 = new HumanPlayer(d2, 1);
            Deck d3 = new Deck();
            HumanPlayer p3 = new HumanPlayer(d3, 3);
            Deck d4 = new Deck();
            HumanPlayer p4 = new HumanPlayer(d4, 4);

            List<HumanPlayer> l = new List<HumanPlayer>();
            l.Add(p2);
            l.Add(p4);
            l.Add(p1);
            l.Add(p3);

            Round r = new Round(l);
            List<HumanPlayer> result=r.GetRankList(l);

            Assert.AreEqual(result[0], p2);
        }
    }
}