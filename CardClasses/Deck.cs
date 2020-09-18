using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Deck 
    {
        // can instantiate the list here OR in the constructor
        private List<Card> cards = new List<Card>();

        public Deck()
        {
            // 13 values
            for (int value = 1; value <= 13; value++)
                // in each of 4 suits
                for (int suit = 1; suit <= 4; suit++)
                    // create the card and add it to the list
                    cards.Add(new Card(value, suit));
        }

        // read-only property
        public int NumCards
        {
            get
            {
                return cards.Count;
            }
        }

        // read-only property
        public bool IsEmpty
        {
            get
            {
                return (cards.Count == 0);
            }
        }

        public Card this[int i]
        {
            get
            {
                return cards[i];
            }
        }

        // dealing from the deck should return a card object
        public Card Deal()
        {
            // if the deck still has cards
            if (!IsEmpty)
            {
                // get a refernce to the first card
                Card c = cards[0];
                // remove the card from the list
                // could have used cards.RemoveAt[0];
                cards.Remove(c);
                // return the first card
                return c;
            }
            // when the deck is empty, return null or throw an exception
            return null;
        }

        public Hand DealSixCards()
        {
            Hand h = new Hand();
            // if the deck still has cards
            if (!IsEmpty)
            {
                for (int i = 1; i <= 6; i++)
                {
                    Card c = cards[0];
                    cards.Remove(c);
                    h.AddCard(c);
                } 
                return h;
            }
            // when the deck is empty, return null or throw an exception
            return null;
        }

        public void DealCards(FoolHand fh, CompHand ch) //dealing cards, one at a time to each player: 6 cards each
        {
            for (int i = 0; i < 6; i++)
            {
                fh.AddCard(Deal());
                ch.AddCard(Deal());
            }
        }

        public Card DetermineTrump() //detemines what trump is and places it at the bottom of the deck
        {                            //this is a helper method
            if (!IsEmpty)
            {
                Card c = cards[0];
                cards.Remove(c);
                cards.Add(c);
                return c;
            }
            return null;
        }

        public Card DisplayTrumpCard() //displays a trump card -- a way to keep track of trump cards' SUIT
        {
            return cards[NumCards - 1]; 
        }

        public Card GetCard(int index) //helper method: finds a card at a specified index
        {
            if (index < 0 && index > cards.Count)
                throw new ArgumentException("There are no cards at this index.");
            else
            {
                Card c = cards[index];
                return c;
            }
        }

        public void Shuffle()
        {
            Random gen = new Random();
            // go through all of the cards in the deck
            for (int i = 0; i < NumCards; i++)
            {
                // generate a random index
                int rnd = gen.Next(0, NumCards);
                // swap the card at the random index with the card at the current index
                Card c = cards[rnd];
                cards[rnd] = cards[i];
                cards[i] = c;
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
