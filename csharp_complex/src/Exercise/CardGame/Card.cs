using System;

namespace Exercise
{
    public class Card : IComparable<Card>, IEquatable<Card>
    {
        public int value { get; }
        public Suit suit { get; }

        public Card(int value, Suit suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public override string ToString()
        {
            string valueString = value switch {
                11 => "J",
                12 => "Q",
                13 => "K",
                14 => "A",
                _ => value.ToString()
            };

            return $"{suit} {valueString}";
        }

        public int CompareTo(Card another)
        {
            int valueDiff = this.value - another.value;

            if (valueDiff != 0)
            {
                return valueDiff;
            }
            else
            {
                return ((int) this.suit) - ((int) another.suit);
            }
        }

        public bool Equals(Card other)
        {
            if (other is null) return false;

            return this.value == other.value && this.suit == other.suit;
        }
    }
}