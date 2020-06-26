using System;
using System.IO;
using Xunit;
using Exercise;
using System.Collections.Generic;
using TestMyCode.CSharp.API.Attributes;

namespace ExerciseTest
{
    public partial class Tests
    {
        [Fact]
        [Points("1.1")]
        public void CardToString()
        {
            Card first = new Card(2, Suit.Diamond);
            Card second = new Card(14, Suit.Spade);
            Card third = new Card(12, Suit.Heart);

            Assert.Equal("Diamond 2", first.ToString());
            Assert.Equal("Spade A", second.ToString());
            Assert.Equal("Heart Q", third.ToString());
        }

        [Fact]
        [Points("1.2")]
        public void CardSort()
        {
            List<Card> original = new List<Card>
            {
                new Card(2, Suit.Club),
                new Card(12, Suit.Diamond),
                new Card(12, Suit.Heart),
                new Card(14, Suit.Heart),
                new Card(14, Suit.Spade)
            };

            List<Card> copy = new List<Card>(original);
            
            original.Reverse();
            original.Sort();

            Assert.Equal(copy, original);
        }

        [Fact]
        [Points("1.3")]
        public void HandPrint()
        {
            using StringWriter sw = new StringWriter()
            {
                NewLine = "\r\n"
            };

            Console.SetOut(sw);

            Hand hand = new Hand();
            hand.Add(new Card(2, Suit.Diamond));
            hand.Add(new Card(14, Suit.Spade));
            hand.Add(new Card(12, Suit.Heart));
            hand.Add(new Card(2, Suit.Spade));

            hand.Print();
            
            Assert.Equal(@"Diamond 2
Spade A
Heart Q
Spade 2
", sw.ToString());
        }

        [Fact]
        [Points("1.4")]
        public void HandSort()
        {
            using StringWriter sw = new StringWriter()
            {
                NewLine = "\r\n"
            };

            Console.SetOut(sw);

            Hand hand = new Hand();
            hand.Add(new Card(2, Suit.Diamond));
            hand.Add(new Card(14, Suit.Spade));
            hand.Add(new Card(12, Suit.Heart));
            hand.Add(new Card(2, Suit.Spade));

            hand.Sort();
            hand.Print();

            Assert.Equal(@"Diamond 2
Spade 2
Heart Q
Spade A
", sw.ToString());
        }


        [Fact]
        [Points("1.5")]
        public void HandCompare()
        {
            using StringWriter sw = new StringWriter()
            {
                NewLine = "\r\n"
            };

            Console.SetOut(sw);

            Hand hand1 = new Hand();

            hand1.Add(new Card(2, Suit.Diamond));
            hand1.Add(new Card(14, Suit.Spade));
            hand1.Add(new Card(12, Suit.Heart));
            hand1.Add(new Card(2, Suit.Spade));

            Hand hand2 = new Hand();

            hand2.Add(new Card(11, Suit.Diamond));
            hand2.Add(new Card(11, Suit.Spade));
            hand2.Add(new Card(11, Suit.Heart));

            int comparison = hand1.CompareTo(hand2);

            if (comparison < 0)
            {
                Console.WriteLine("better hand is");
                hand2.Print();
            }
            else if (comparison > 0)
            {
                Console.WriteLine("better hand is");
                hand1.Print();
            }
            else
            {
                Console.WriteLine("hands are equal");
            }

            Assert.Equal(@"better hand is
Diamond J
Spade J
Heart J
", sw.ToString());
        }
    }
}
