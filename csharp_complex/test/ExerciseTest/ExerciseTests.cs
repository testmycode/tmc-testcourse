using System;
using System.IO;
using Xunit;
using Exercise;
using System.Collections.Generic;
using System.Reflection;
using TestMyCode.CSharp.API.Attributes;

namespace ExerciseTest
{
    public class Tests
    {
        string @namespace = "Exercise";
        string mainclass = "Program";
        private Type MainClassType;
        private MethodInfo MainMethod;

        public Tests()
        {
            MainClassType = Type.GetType($"{@namespace}.{mainclass},{@namespace}");
            this.MainMethod = this.MainClassType.GetMethod("Main", new[] { typeof(string[]) });
        }

        [Fact]
        public void TestMainExists()
        {
            MethodBody MainMethodBody = this.MainMethod.GetMethodBody();
            Assert.NotNull(MainMethodBody);
        }

        [Fact]
        [Points("1")]
        public void ExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Card first = new Card(2, Suit.Diamond);
                Card second = new Card(14, Suit.Spade);
                Card third = new Card(12, Suit.Heart);

                Console.WriteLine(first);
                Console.WriteLine(second);
                Console.WriteLine(third);
                Console.SetOut(stdout);
                string comparison = "Diamond 2\nSpade A\nHeart Q\n";
                Assert.Equal(comparison, sw.ToString().Replace("\r\n", "\n"));
            }
        }

        [Fact]
        [Points("1")]
        public void Example2ShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Card first = new Card(2, Suit.Club);
                Card second = new Card(14, Suit.Spade);
                Card third = new Card(12, Suit.Heart);
                Card fourth = new Card(14, Suit.Heart);
                Card fifth = new Card(12, Suit.Diamond);

                List<Card> list = new List<Card> { first, second, third, fourth, fifth };
                list.Sort();
                list.ForEach(Console.WriteLine);
                string comparison = "Club 2\nDiamond Q\nHeart Q\nHeart A\nSpade A\n";
                Assert.Equal(comparison, sw.ToString().Replace("\r\n", "\n"));
            }
        }

        [Fact]
        [Points("1")]
        public void Example3ShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(2, Suit.Diamond));
                hand.Add(new Card(14, Suit.Spade));
                hand.Add(new Card(12, Suit.Heart));
                hand.Add(new Card(2, Suit.Spade));

                hand.Print();
                string comparison = "Diamond 2\nSpade A\nHeart Q\nSpade 2\n";
                Assert.Equal(comparison, sw.ToString().Replace("\r\n", "\n"));
            }
        }

        [Fact]
        [Points("1")]
        public void Example4ShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(2, Suit.Diamond));
                hand.Add(new Card(14, Suit.Spade));
                hand.Add(new Card(12, Suit.Heart));
                hand.Add(new Card(2, Suit.Spade));

                hand.Sort();
                hand.Print();
                string comparison = "Diamond 2\nSpade 2\nHeart Q\nSpade A\n";
                Assert.Equal(comparison, sw.ToString().Replace("\r\n", "\n"));
            }
        }


        [Fact]
        [Points("1")]
        public void Example5ShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
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

                string compare = "better hand is\nDiamond J\nSpade J\nHeart J\n";
                Assert.Equal(compare, sw.ToString().Replace("\r\n", "\n"));
            }
        }
    }
}
