using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blackjack
{
    public enum CardSuit
    {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }
    public enum CardDisplay
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    } 

    public class Program
    {

        public class Card
        {
            public CardSuit Suit { get; private set; }
            public int Value { get; private set; }
            public CardDisplay Display
            {
                get
                {
                    if (Value == 1)
                    {
                        return CardDisplay.Ace;
                    }
                    if (Value == 2)
                    {
                        return CardDisplay.Two;
                    }
                    if (Value == 3)
                    {
                        return CardDisplay.Three;
                    }
                    if (Value == 4)
                    {
                        return CardDisplay.Four;
                    }
                    if (Value == 5)
                    {
                        return CardDisplay.Five;
                    }
                    if (Value == 6)
                    {
                        return CardDisplay.Six;
                    }
                    if (Value == 7)
                    {
                        return CardDisplay.Seven;
                    }
                    if (Value == 8)
                    {
                        return CardDisplay.Eight;
                    }
                    if (Value == 9)
                    {
                        return CardDisplay.Nine;
                    }
                    if (Value == 10)
                    {
                        return CardDisplay.Ten;
                    }
                    if (Value == 11)
                    {
                        return CardDisplay.Jack;
                    }
                    if (Value == 12)
                    {
                        return CardDisplay.Queen;
                    }
                    if (Value == 13)
                    {
                        return CardDisplay.King;
                    }
                    throw new IndexOutOfRangeException("Value");

                }
            }
            public Card(CardSuit suit, int val)
            {
                Suit = suit;
                Value = val;
            }
        }


        public class Deck
        {
            public static Random rand = new Random();

            public List<Card> Cards { get; set; }

            public void Deal(Hand hand)
            {
                Card dealCard = Cards.First();
                Cards.Remove(dealCard);
                hand.Cards.Add(dealCard);
            }

            public void Shuffle()
            {
                int n = Cards.Count;
                while (n > 1)
                {
                    n--;
                    int k = rand.Next(n + 1);
                    Card value = Cards[k];
                    Cards[k] = Cards[n];
                    Cards[n] = value;
                }
            }

            public Deck()
            {
                Cards = new List<Card>();
                for(int i = 1; i< 14; i++)
                {
                    foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                    {
                        if (i > 10)
                        {
                            Cards.Add(new Card(suit, 10));
                        }
                        else
                        {
                            Cards.Add(new Card(suit, i));
                        }
                    }
                }
                Shuffle();
            }
        }

        public class Hand
        {
            public string Name { get; set; }
            public List<Card> Cards { get; set; }
            public int LowAceCount { get; set; }
            public int HandValue
            {
                get
                {
                    int score = 0;
                    LowAceCount = Cards.FindAll(c => c.Value == 1).Count;
                    foreach (Card card in Cards)
                    {
                        score += card.Value;
                    }
                    while (score < 12 && LowAceCount > 0)
                    {
                        LowAceCount--;
                        score += 10;
                    }
                    return score;
                }
            }
            public void Display()
            {
                Console.WriteLine("{0}'s Hand",Name);
                foreach (Card card in Cards)
                {
                    Console.WriteLine(string.Format("{0} of {1}",card.Display,card.Suit));
                }
                Console.WriteLine(string.Format("Hand Value: {0}",HandValue));
                Console.WriteLine();
            }
            public Hand(string name)
            {
                LowAceCount = 0;
                Name = name;
                Cards = new List<Card>();
            }
        }

        public static void Main(string[] args)
        {

            bool game = true;
            string input;
            while (game)
            {
                Deck deck = new Deck();
                Hand player = new Hand("Player");
                Hand dealer = new Hand("Dealer");

                deck.Deal(player);
                deck.Deal(player);
                deck.Deal(dealer);
                Console.WriteLine("----------------------------------------");
                dealer.Display();
                player.Display();
                bool playing = true;
                while (playing)
                {
                    if (player.HandValue == 21)
                    {
                        input = "n";
                    }
                    else
                    {
                        Console.WriteLine("Hit? (Y)");
                        input = Console.ReadLine();
                    }
                    if (input.ToLower() == "y")
                    {
                        deck.Deal(player);
                        Console.WriteLine("----------------------------------------");
                        dealer.Display();
                        player.Display();
                        if (player.HandValue > 21)
                        {
                            playing = false;
                        }
                    }
                    else
                    {
                        playing = false;
                    }
                }
                deck.Deal(dealer);
                Console.WriteLine("----------------------------------------");
                dealer.Display();
                player.Display();
                if (player.HandValue > 21)
                {
                    Console.WriteLine("You busted, dealer wins!");
                }
                else
                {
                    while (dealer.HandValue < 17 || (dealer.HandValue == 17 && dealer.LowAceCount > 0))
                    {
                        deck.Deal(dealer);
                        Console.WriteLine("----------------------------------------");
                        dealer.Display();
                        player.Display();
                        Console.ReadLine();
                    }
                    if (dealer.HandValue > 21)
                    {
                        Console.WriteLine("Dealer busted, you win!");
                    }
                    else if (player.HandValue > dealer.HandValue)
                    {
                        Console.WriteLine("You win!");
                    }
                    else if (player.HandValue < dealer.HandValue)
                    {
                        Console.WriteLine("You lose!");
                    }
                    else
                    {
                        Console.WriteLine("Its a tie!");
                    }
                }
                Console.WriteLine("Play again? (Y)");
                input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    game = false;
                }
                else
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("----------------------------------------");
                }
            }
        }
    }
}
