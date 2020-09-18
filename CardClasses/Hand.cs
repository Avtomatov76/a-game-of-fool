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

        public void DrawUpToSixCards(Hand h, Deck d, Card tc) //draws cards from the deck up to 6 cards, and sorts the cards
        {
            while (!(h.HasSixCards) && d.NumCards != 0)
            {
                Card c = d.Deal();
                cards.Remove(c);
                h.AddCard(c);
            }
            h.SortCards(h, tc);
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

        public Card Attack(int index, Hand h) //NEEDS WORK!!!!!!!!!!!!!!!!!!!
        {
            Card c = h.cards[index];
            h.cards.Remove(c);
            return c;
        }

        public bool CanAttackAgain(Hand h, PlayHand ph) //Checks if Computer can attack again based on cards in the PlayHand
        {
            bool canAttack = false;

            for (int i = 0; i < ph.NumCards; i++)
            {
                Card c = ph.GetCard(i);
                for (int j = 0; j < h.NumCards; j++)
                {
                    Card c1 = h.GetCard(i);
                    if (c1.Value == c.Value)
                        canAttack = true;
                }
            }
            return canAttack;
        }

        public void PutCardsIntoPlayHand(Hand h, Hand ph, Card c)
        {
            for ( int i = 0; i < h.NumCards; i++)
            {
                if (h.cards[i].Value == c.Value)
                {
                    h.cards.Remove(c);
                    ph.AddCard(c);
                }
            }
        }

        public Card AttackAgain(Hand h, PlayHand ph) // REWORKED THE METHOD A BIT
        {
            for (int i = 0; i < ph.NumCards; i++)
            {
                Card c1 = ph.cards[i];
                for (int j = 0; j < h.NumCards; j++)
                {
                    Card c = h.cards[j];
                    if (c.HasMatchingValue(c1))
                    {
                        h.cards.Remove(c);
                        return c;
                    }
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

        //public override string ToString()
        //{
        //    string output = "";
        //    // go through every card in the deck
        //    foreach (Card c in cards)
        //        // ask the card to convert itself to a string
        //        output += (c.ToString() + "\n");
        //    return output;
        //}

        public override string ToString()
        {
            string output = "";
            // go through every card in the deck
            foreach (Card c in cards)
                // ask the card to convert itself to a string
                output += (cards.IndexOf(c) + 1) + ") " + (c.ToString() + "\n");
          
            return output;
        }

        public Hand SortCards(Hand h, Card tc)
        {
            List<Card> cards2 = new List<Card>(); //helper list for sorting trump cards
            Hand h1 = new Hand();
            cards.Sort();

            for (int i = 0; i < h.NumCards; i++) //placing all Aces to the bottom of the hand
            {
                Card c = cards[0];
                if (c.Value == 1)
                {
                    cards.Remove(c);
                    cards.Add(c);
                }
            }

            for (int i = 0; i < cards.Count; i++)
            {
                Card c = cards[i];
                if (!c.HasMatchingSuit(tc))
                    cards2.Add(c);
            }

            for (int i = 0; i < cards.Count; i++)
            {
                Card c = cards[i];
                if (c.HasMatchingSuit(tc))
                    cards2.Add(c);
            }

            cards.Clear();

            for (int i = 0; i < cards2.Count; i++)
            {
                Card c = cards2[i];
                cards.Add(c);
                h1.AddCard(c);
            }

            return h1;
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)cards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Card>)cards).GetEnumerator();
        }
    }
}
