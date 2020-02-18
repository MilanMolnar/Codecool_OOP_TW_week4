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
            Player p1 = new Player(d, 2);
            Deck d2 = new Deck();
            Player p2 = new Player(d2, 1);
            Deck d3 = new Deck();
            Player p3 = new Player(d3, 3);
            Deck d4 = new Deck();
            Player p4 = new Player(d4, 4);

            List<Player> l = new List<Player>();
            l.Add(p2);
            l.Add(p4);
            l.Add(p1);
            l.Add(p3);

            Round r = new Round(l);
            List<Player> result=r.GetRankList(l);

            Assert.AreEqual(result[0], p2);
        }
    }
}