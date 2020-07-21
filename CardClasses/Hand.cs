using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand : IEnumerable<Card>
    {
        protected List<Card> cards = new List<Card>();

        public int NumCards
        {
            get
            {
                return cards.Count();
            }
        }

        public bool IsEmpty
        {
            get
            {
                return NumCards == 0;
            }
        }

        public bool HasSixCards
        {
            get
            {
                return NumCards == 6;
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

        public void DrawUpToSixCards(Hand h, Deck d) //draws cards from the deck up to 6 cards
        {
            while (!(h.HasSixCards) && d.NumCards != 0)
            {
                Card c = d.Deal();
                cards.Remove(c);
                h.AddCard(c);
            }
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

        public Card Attack(int index, FoolHand fh, PlayHand ph) //NEEDS WORK!!!!!!!!!!!!!!!!!!!
        {
            Card c = fh.cards[index];
            Card c1 = new Card();

            if (ph.IsEmpty)
            {
                fh.cards.Remove(c);
                return c;
            }

            for (int i = 0; i < ph.NumCards; i++)
            {
                c1 = ph.cards[i];
                if (c.HasMatchingValue(c1))
                {
                    fh.cards.Remove(c);
                    return c;
                }
                //else
                //    throw new ArgumentException("This card's value does not match any cards currently in play; therefore it cannot be played.");
            }
            return null;
        }

        public Hand PickUpCards(Hand h, Hand playHand)
        {
            for (int i = 0; i < playHand.NumCards; i++)
            {
                h.AddCard(playHand.GetCard(i));
            }
            return h;
        }

        public Card DefendWithSameSuit(Hand h, Card c)
        {
            Card c1 = new Card();

            for (int i = 0; i < h.NumCards; i++)
            {
                c1 = cards[i];
                if ((c1.HasMatchingSuit(c) && c1.Value > c.Value && c.Value != 1) ||
                    (c1.HasMatchingSuit(c) && c1.Value == 1 && c.Value != 1))
                {
                    cards.Remove(c1);
                    return c1;
                }
            }
            return null;
        }

        public Hand PickPlayHandCards(Hand h, PlayHand ph)
        {
            for (int i = 0; i < ph.NumCards; i++)
                h.AddCard(ph.cards[i]);

            ph.DiscardAll();

            return h;
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

        public IEnumerator<Card> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
