using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> cards = new List<Card>();

        public int NumCards
        {
            get
            {
                return cards.Count();
            }
        }

        public Hand() { }

        public Hand(Deck d, int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                cards.Add(d.Deal());
            }
        }

        public int IndexOf(Card c)
        {
            return cards.IndexOf(c);
        }

        public int IndexOf(int value)
        {
            int index = -1;

            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value == value)
                {
                    index = i;
                    return index;
                }
            }
            return index;
        }

        public int IndexOf(int value, int suit)
        {
            Card c = new Card(value, suit);

            return cards.IndexOf(c);
        }

        public bool HasCard(Card c)
        {
            return IndexOf(c) != -1;
        }

        public bool HasCard(int value)
        {
            return IndexOf(value) != -1;
        }

        public bool HasCard(int value, int suit)
        {
            return IndexOf(value, suit) != -1;
        }

        public void AddCard(Card c)
        {
            if (cards.IndexOf(c) == -1)
            {
                cards.Add(c);
            }
        }

        public Card Discard(int index)
        {
            Card c = new Card();
            if (cards.IndexOf(cards[index]) != -1)
            {
                c = cards[index];
                cards.Remove(c);
            }
            else
                throw new ArgumentException("There is no card at this index.");

            return c;
        }

        public void DiscardAll()
        {
            if (NumCards != 0)
            {
                cards.Clear();
            }
        }

        public Card GetCard(int index)
        {
            if (index < 0 && index > cards.Count)
                throw new ArgumentException("There are no cards at this index.");
            else
            {
                Card c = cards[index];
                return c;
            }
        }

        public override string ToString()
        {
            string output = "";
            // go through every card in the deck
            foreach (Card c in cards)
                // ask the card to convert itself to a string
                output += (c.ToString() + "\n");
            return output;
        }

    }
}
