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

        public Card AttackWithCard(FoolHand fh, int index)
        {
            Card c = fh.GetCard(index);
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

        public bool CanAttackAgain(int index, Hand h, PlayHand ph) //Checks if a player can attack again with a specific card
        {
            bool canAttack = false;
            Card attackCard = h.GetCard(index);

            for (int i = 0; i < ph.NumCards; i++)
            {
                Card c = ph.GetCard(i);
                if (attackCard.Value == c.Value)
                    canAttack = true;
            }
            return canAttack;
        }

        public FoolHand SortCards(FoolHand fh)
        {
            FoolHand fh1 = new FoolHand();
            fh.cards.Sort();
          
            for (int i = 0; i < fh.NumCards; i++)
                fh1.AddCard(cards[i]);
            
            return fh1;
        }

        public bool CanDefendWithSpecificCard(Card attkCard, Card defCard, Card trump) //checking if a plyer-chosen card can beat the attacking card
        {
            bool canDefend = false;
            if ((defCard.HasMatchingSuit(attkCard) && defCard.Value > attkCard.Value) ||
                defCard.HasMatchingSuit(trump) && attkCard.Suit != trump.Suit ||
                defCard.HasMatchingSuit(attkCard) && defCard.Value == 1 && attkCard.Value != 1)

                canDefend = true;

            return canDefend;
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

        public Card DefendWithSpecificCard(FoolHand fh, int index) //NEEDS TESTING
        {
            Card c = fh.cards[index];

            return c;
        }

        public Card Defend(FoolHand fh, Card c, Card tc) //NEEDS TESTING
        {
            Card c1 = new Card();

            for (int i = 0; i < fh.NumCards; i++)
            {
                c1 = cards[i];
                if ((c1.HasMatchingSuit(c) && c1.Value > c.Value && c.Value != 1) ||
                    (c1.HasMatchingSuit(c) && c1.Value == 1 && c.Value != 1) ||
                    (c1.HasMatchingSuit(tc) && c.Suit != tc.Suit) ||
                    (c1.HasMatchingSuit(tc) && c.HasMatchingSuit(tc) && (c1.Value > c.Value)))
                {
                    cards.Remove(c1);
                    return c1;
                }
            }
            return null;
        }

        public Card DefendWithCard(Card c, FoolHand fh)
        {
            fh.cards.Remove(c);
            return c;
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

        public PlayHand PickCardUp(PlayHand ph, Card c) //Picking up a card voluntarily
        {
            ph.AddCard(c);

            return ph;
        }


    }
}
