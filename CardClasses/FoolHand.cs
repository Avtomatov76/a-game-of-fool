using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class FoolHand : Hand
    {
        public FoolHand() : base() { }

        public FoolHand(Deck d, int numCards) : base(d, numCards) { }

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

        public string GetTrumpSuit(Card tc) //determines the suit of the trump card
        {
            string trump = "";
            int indexOfSuit = tc.Suit;

            switch(indexOfSuit)
            {
                case 1: trump = "Clubs";
                    break;
                case 2: trump = "Diamonds";
                    break;
                case 3: trump = "Hearts";
                    break;
                default: trump = "Spades";
                    break;
            }
            return trump;
        }

        public int HowManyTrumpCards(FoolHand fh, Card tc) //determines the number of trump cards in a hand
        {
            int numTrumpCards = 0;

            for (int i = 0; i < fh.cards.Count; i++)
            {
                if (cards[i].Suit == tc.Suit)
                    numTrumpCards += 1;
            }
            return numTrumpCards;
        }
    
        public void DrawUpToSixCards(FoolHand fh, Deck d) //draws cards from the deck up to 6 cards
        {
            while (!(fh.HasSixCards) && d.NumCards != 0)
            {
                Card c = d.Deal();
                cards.Remove(c);
                fh.AddCard(c);
            } 
        }

        public Card Attack(int index)
        {
            Card c = cards[index];
            cards.Remove(c);

            return c;
        }

        public Card AttackAgain(FoolHand fh, Card c) //attacking again if there is a card of the same value in a hand
        {
            Card c1 = new Card();
            for (int i = 0; i < fh.NumCards; i++)
            {
                c1 = cards[i];
                if (c1.HasMatchingValue(c))
                {
                    cards.Remove(c1);
                    return c1;
                }
            }
            return null;
        }

        public Card Defend(FoolHand fn, Card c) //NEEDS TESTING
        {
            Card c1 = new Card();
            for (int i = 0; i < fn.NumCards; i++)
            {
                c1 = cards[i];
                if (c1.HasMatchingSuit(c) && c1.Value > c.Value)
                {
                    cards.Remove(c1);
                    return c1;
                }
            }
            return null;
        }

        public Card DefendWithSpecifiedCard(int index) //NEEDS TESTING
        {
            Card c = cards[index];
            cards.Remove(c);

            return c;
        }
    }
}
