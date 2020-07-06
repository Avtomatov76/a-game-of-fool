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

        public FoolHand SortCards(FoolHand fh)
        {
            FoolHand fh1 = new FoolHand();
            fh.cards.Sort();
          
            for (int i = 0; i < fh.NumCards; i++)
                fh1.AddCard(cards[i]);
            
            return fh1;
        }

        public bool CanDefend(FoolHand fh, Card c, Card tc) //determines if a player is able to defend
        {
            bool canDefend = false;

            if (fh.Defend(fh, c, tc) != null || fh.DefendWithSameSuit(fh, c) != null)
                canDefend = true;

            return canDefend;
        }

        public bool CannotDefendOption() //Player chosen option to not defend
        {
            return true;
        }

        public Card Defend(FoolHand fh, Card c, Card tc) //NEEDS TESTING
        {
            Card c1 = new Card();
            
            for (int i = 0; i < fh.NumCards; i++)
            {
                c1 = cards[i];
                if ((c1.Suit == c.Suit && c1.Value > c.Value)  || 
                    ((c1.Suit == c.Suit) && c1.Value == 1 && c.Value != 1) || 
                    (c1.Suit == tc.Suit && c.Suit != tc.Suit) ||
                    (c1.Suit == tc.Suit && c.Suit == tc.Suit && (c1.Value > c.Value || 
                    (c1.Suit == c.Suit && c1.Value == 1 && c.Value != 1))))   
                {
                    cards.Remove(c1);
                    return c1;
                }
            }
            return null;
        }

        public Card DefendWithSameSuit(FoolHand fh, Card c)
        {
            Card c1 = new Card();

            for (int i = 0; i < fh.NumCards; i++)
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

        public Card DefendWithSpecifiedCard(int index, Card c) //NEEDS TESTING
        {
            Card c1 = cards[index];
            if (c1.HasMatchingSuit(c) && c1.Value > c.Value || 
                (c1.HasMatchingSuit(c) && c1.Value == 1 && c.Value != 1))
            {
                cards.Remove(c1);
                return c1;
            }                  
         return null;
        }




    }
}
