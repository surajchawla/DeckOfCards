using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;


namespace CardGame.UnitTests
{
    [TestFixture]
    public class CardTest
    {
        private IDeck _deck;

        [SetUp]
        public void Initialize()
        {
            _deck = new Deck();
        }

        /*
         * Validate that we throw an exception when no cards are left in the deck 
         */
        [Test]
        public void GivenNoCardsLeftInTheDeckWhenCallingDealCardThenThrowsEmptyDeckException()
        {
            int testNumberOfHands = 1;
            int numberOfCards = 53;
            
            var players = Program.GetPlayers(testNumberOfHands);

            Assert.Throws<EmptyDeckException>(() => Program.DealCards(_deck, players, numberOfCards),"No card left in the deck");
        }

        /*
         * Validate when No cards are dealt then we give the appropriate error message
         */
        [Test]
        public void GivenNoCardsAreDealtWhenShowHandIsCalledGivesErrorMessage()
        {
            IPlayer player = new Player("Test");
            string expectedMessage = "No cards dealt yet";

            string actualMessage = player.ShowHand();

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        /*
         * Validate whether all the cards in the deck are always unique
         */
        [Test]
        public void GivenCardsAreDealtAllCardsAreUnique()
        {
            const int testNoOfPlayers = 1;
            const int numberOfCards = 52;

            var players = Program.GetPlayers(testNoOfPlayers);
            Program.DealCards(_deck, players, numberOfCards);
            string outputString  =  players[0].ShowHand();
            var cards = outputString.Split('-');

            int distinctCardCount = cards.Distinct().Count();

            Assert.AreEqual(numberOfCards, distinctCardCount);
        }

        [Test]
        public void GivenWeDealTheCardsForAPlayerTheExactNumberClardShouldBeThereInAHand()
        {
            var hand = new Hand();
            hand.AddCard(new Card(CardValue.Ace, Suit.Clubs));
            hand.AddCard(new Card(CardValue.King, Suit.Diamonds));
            hand.AddCard(new Card(CardValue.Queen, Suit.Hearts));

            Assert.AreEqual(3, hand.GetCardsInHand());
        }

        [Test]
        public void GivenOutputFileIsGivenVerifyOutputIsWrittenToFile()
        {
            const int testNoOfPlayers = 2;
            const int numberOfCards = 5;
            const string fileName = "testOutput.txt";

            var players = Program.GetPlayers(testNoOfPlayers);
            Program.DealCards(_deck, players, numberOfCards);
            Program.WriteAllPlayerHands(players, "testOutput.txt");
            string[] fileContents = File.ReadAllText(fileName).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] expectedFileContents = Program.GetAllPlayerHands(players).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for(int i = 0 ; i < fileContents.Count(); i++)
            {
                StringAssert.AreEqualIgnoringCase(expectedFileContents[i], fileContents[i]);
            }
        }

    }
}
