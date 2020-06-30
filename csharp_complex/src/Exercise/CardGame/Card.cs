// SOLUTION FILE
using System;

namespace Exercise
{
    public class Card : IComparable<Card>, IEquatable<Card>
    {
        public int Value { get; }
        public Suit Suit { get; }

        public Card(int value, Suit suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string valueString = Value switch
            {
                11 => "J",
                12 => "Q",
                13 => "K",
                14 => "A",
                _ => Value.ToString()
            };

            return $"{Suit} {valueString}";
        }

        public int CompareTo(Card another)
        {
            int valueDiff = Value.CompareTo(another.Value);
            if (valueDiff != 0)
            {
                return valueDiff;
            }
            else
            {
                return Suit.CompareTo(another.Suit);
            }
        }

        public bool Equals(Card other)
        {
            if (other is null)
            {
                return false;
            }

            return Value == other.Value && Suit == other.Suit;
        }
    }
}