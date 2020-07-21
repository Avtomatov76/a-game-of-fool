using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Card : IComparable<Card>
    {
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        private int value;
        private int suit;

        public int Value
        {
            get
            {
                return value;
            }
            set
            {   // validating input within a specified range and throwing exception if not
                if (value >= 1 && value <= 13)
                    this.value = value;
                else
                    throw new ArgumentException("Value must be between 1 and 13");
            }
        }

        public int Suit
        {
            get
            {
                return suit;
            }
            set
            {  // validating input within a specified range and throwing exception if not
                if (value >= 1 && value <= 4)
                    suit = value;
                else
                    throw new ArgumentException("Suit must be between 1 and 4");
            }
        }

        public Card()
        {
            value = generator.Next(1, 14);
            suit = generator.Next(1, 5);
        }

        public Card(int v, int s)
        {   // instantiating a new Class object using property values to validate the input 
            Value = v;
            Suit = s;
        }

        public bool HasMatchingSuit(Card other)
        {
            if (this.suit == other.suit)
                return true;
            else
                return false;
        }

        public bool HasMatchingValue(Card other)
        {
            if (this.value == other.value)
                return true;
            else
                return false;
        }

        public bool IsBlack()
        {
            if (suit == 1 || suit == 4)
                return true;
            else
                return false;
        }

        public bool IsRed()
        {
            if (suit == 2 || suit == 3)
                return true;
            else
                return false;
        }

        public bool IsClub()
        {
            if (suit == 1)
                return true;
            else
                return false;
        }

        public bool IsDiamond()
        {
            if (suit == 2)
                return true;
            else
                return false;
        }

        public bool IsHeart()
        {
            if (suit == 3)
                return true;
            else
                return false;
        }

        public bool IsSpade()
        {
            if (suit == 4)
                return true;
            else
                return false;
        }

        public bool IsFaceCard()
        {
            if (value == 11 || value == 12 || value == 13)
                return true;
            else
                return false;
        }

        public bool IsAce()
        {
            if (value == 1)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }

        public bool IsTrump(int suit) //determines if a card is a trump card
        {
            bool isTrump = false;
            if (this.Suit == suit)
                isTrump = true;

            return isTrump;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Card other = (Card)obj;
                return other.Value == Value &&
                    other.Suit == Suit;
            }
        }

        public override int GetHashCode()
        {
            return 13 + 7 * value.GetHashCode() +
                7 * suit.GetHashCode();
        }

        public int CompareTo(Card other)
        {
            int comparisonIndex = 0;
            if (this.Value == other.Value)
                comparisonIndex = 0;
            else if (this.Value < other.Value)
                comparisonIndex = -1;
            else 
                comparisonIndex = 1;

            return comparisonIndex;
        }
    }
}
