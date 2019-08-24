using System;
using CardGames;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CardGamesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeckCreation()
        {
            Deck myDeck = new Deck();
            foreach (var card in myDeck.Cards)
            {
                Assert.IsNotNull(card.CardImage);
            }
        }
    }
}
