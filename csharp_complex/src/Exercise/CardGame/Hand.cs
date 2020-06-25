// SOLUTION FILE
using System;
using System.Collections.Generic;

namespace Exercise
{
    public class Hand : IComparable<Hand>
    {
        private List<Card> hand;

        public Hand()
        {
            hand = new List<Card>();
        }

        public void Add(Card card)
        {
            if (card is null || hand.Contains(card))
            {
                return;
            }

            hand.Add(card);
        }

        public void Print()
        {
            foreach (Card c in hand) 
            {
                Console.WriteLine(c.ToString());
            }
        }

        public void Sort()
        {
            hand.Sort();
        }

        public int CompareTo(Hand other)
        {
            int selfValue = 0;
            int otherValue = 0;

            foreach (Card c in hand)
            {
                selfValue += c.Value;
            }

            foreach (Card c in other.hand)
            {
                otherValue += c.Value;
            }

            return selfValue.CompareTo(otherValue);
        }
    }
}