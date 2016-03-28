using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace blackjack.Tests
{
    public class CardTests
    {
        [Fact]
        public void TestConstructorClubsAce()
        {
            var myCard = new Card(CardSuit.Clubs, 1);

            Assert.Equal(CardSuit.Clubs, myCard.Suit);
            Assert.Equal(1, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Ace);
        }
        [Fact]
        public void TestConstructorHeartsTwo()
        {
            var myCard = new Card(CardSuit.Hearts, 2);

            Assert.Equal(CardSuit.Hearts, myCard.Suit);
            Assert.Equal(2, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Two);
        }
        [Fact]
        public void TestConstructorDiamondsThree()
        {
            var myCard = new Card(CardSuit.Diamonds, 3);

            Assert.Equal(CardSuit.Diamonds, myCard.Suit);
            Assert.Equal(3, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Three);
        }
        [Fact]
        public void TestConstructorSpadesFour()
        {
            var myCard = new Card(CardSuit.Spades, 4);

            Assert.Equal(CardSuit.Spades, myCard.Suit);
            Assert.Equal(4, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Four);
        }
        [Fact]
        public void TestConstructorClubsFive()
        {
            var myCard = new Card(CardSuit.Clubs, 5);

            Assert.Equal(CardSuit.Clubs, myCard.Suit);
            Assert.Equal(5, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Five);
        }
        [Fact]
        public void TestConstructorHeartsSix()
        {
            var myCard = new Card(CardSuit.Hearts, 6);

            Assert.Equal(CardSuit.Hearts, myCard.Suit);
            Assert.Equal(6, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Six);
        }
        [Fact]
        public void TestConstructorDiamondsSeven()
        {
            var myCard = new Card(CardSuit.Diamonds, 7);

            Assert.Equal(CardSuit.Diamonds, myCard.Suit);
            Assert.Equal(7, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Seven);
        }
        [Fact]
        public void TestConstructorSpadesEight()
        {
            var myCard = new Card(CardSuit.Spades, 8);

            Assert.Equal(CardSuit.Spades, myCard.Suit);
            Assert.Equal(8, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Eight);
        }
        [Fact]
        public void TestConstructorClubsNine()
        {
            var myCard = new Card(CardSuit.Clubs, 9);

            Assert.Equal(CardSuit.Clubs, myCard.Suit);
            Assert.Equal(9, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Nine);
        }
        [Fact]
        public void TestConstructorHeartsTen()
        {
            var myCard = new Card(CardSuit.Hearts, 10);

            Assert.Equal(CardSuit.Hearts, myCard.Suit);
            Assert.Equal(10, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Ten);
        }
        [Fact]
        public void TestConstructorDiamondsJack()
        {
            var myCard = new Card(CardSuit.Diamonds, 11);

            Assert.Equal(CardSuit.Diamonds, myCard.Suit);
            Assert.Equal(10, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Jack);
        }
        [Fact]
        public void TestConstructorSpadesQueen()
        {
            var myCard = new Card(CardSuit.Spades, 12);

            Assert.Equal(CardSuit.Spades, myCard.Suit);
            Assert.Equal(10, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.Queen);
        }
        [Fact]
        public void TestConstructorClubsKing()
        {
            var myCard = new Card(CardSuit.Clubs, 13);

            Assert.Equal(CardSuit.Clubs, myCard.Suit);
            Assert.Equal(10, myCard.Score);
            Assert.Equal(myCard.Display, CardDisplay.King);
        }
        [Fact]
        public void TestConstructorBadValue()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => {
                var myCard = new Card(CardSuit.Clubs, 0);
            });
        }
    }

    public class DeckTests
    {
        [Fact]
        public void TestConstructorCount()
        {
            var myDeck = new Deck();

            Assert.Equal(52, myDeck.Cards.Count);
        }
        [Fact]
        public void TestConstructorUnique()
        {
            var myDeck = new Deck();

            Assert.Equal(52,myDeck.Cards.Distinct().Count());
        }
        [Fact]
        public void TestShuffle()
        {
            var deck1 = new Deck();
            var deck2 = new Deck();
            for (int i = 0; i < deck1.Cards.Count; i++)
            {
                if (deck1.Cards[i] != deck2.Cards[i])
                {
                    return;
                }
            }
            throw new Exception("Deck not properly shuffled!");
        }
    }
}
