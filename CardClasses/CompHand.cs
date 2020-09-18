using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class CompHand : Hand 
    {
        public CompHand() : base() { }

        public CompHand(Deck d, int numCards) : base(d, numCards) { }

        public Card CompAttack()
        {
            Card c = cards[0];
            if (cards.Count != 0)
                cards.Remove(c);

            return c;
        }

        public Hand OffLoadAttackCards(Card attackCard, CompHand ch, Hand ph)
        {
            for (int i = 0; i < ch.NumCards; i++)
            {
                Card c = ch.GetCard(i);
                if (c.Value == attackCard.Value)
                {
                    ch.cards.Remove(c);
                    ph.AddCard(c);
                }
            }
            return ph;
        }

        public Card CompAttackSameCardValue(CompHand ch, Card c)
        {
            Card atckCard = new Card();
            for (int i = 0; i < ch.NumCards; i++)
            {
                if (cards[i].HasMatchingValue(c))
                {
                    atckCard = cards[i];
                    cards.Remove(atckCard);
                }
                else
                    atckCard = null;
            }
            return atckCard;
        }

        //attack with any VALUE displayed within the PlayHand

        public CompHand CompSortCards(CompHand ch, Card tc)
        {
            List<Card> cards2 = new List<Card>(); //helper list for sorting trump cards
            CompHand ch1 = new CompHand();
            cards.Sort();

            for (int i = 0; i < ch.NumCards; i++) //placing all Aces to the bottom of the hand
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
                ch1.AddCard(c);
            }

            return ch1;
        }

        public Card CompDefend(CompHand ch, Card c, Card tc) //SAME SUIT CARD BEATS ACE BECAUSE ACE IS OF VALUE '1' -- THATS NOT RIGHT, NEEDS CHANGING
        {
            Card c1 = new Card();

            for (int i = 0; i < ch.NumCards; i++)
            {
                c1 = cards[i];
                if ((c1.HasMatchingSuit(c) && c1.Value > c.Value) ||
                    (c1.HasMatchingSuit(c) && c1.Value == 1 && c.Value != 1) ||
                    (c1.HasMatchingSuit(tc) && c.Suit != tc.Suit) ||
                    (c1.HasMatchingSuit(tc) && c.HasMatchingSuit(tc) && (c1.Value > c.Value ||
                    (c1.HasMatchingSuit(c) && c1.Value == 1 && c.Value != 1))))
                {
                    cards.Remove(c1);
                    return c1;
                }
            }
            return null;
        }

        //public bool CanAttackAgain(CompHand ch, PlayHand ph) //Checks if Computer can attack again based on cards in the PlayHand
        //{
        //    bool canAttack = false;

        //    for (int i = 0; i < ph.NumCards; i++)
        //    {
        //        Card c = ph.GetCard(i);
        //        for (int j = 0; j < ch.NumCards; j++)
        //        {
        //            if (ch.cards[j].Value == c.Value)
        //                canAttack = true;
        //        }
        //    }
        //    return canAttack;
        //}

        public bool CanDefend(CompHand ch, Card c, Card tc) //determines if a player is able to defend
        {
            bool canDefend = false;

            if (ch.CompDefend(ch, c, tc) != null )
                canDefend = true;

            return canDefend;
        }

        public CompHand CompPickCard(CompHand ch, Card c, Card tc)
        {
            if (ch.CompDefend(ch, c, tc) == null )
                ch.cards.Add(c);

            return ch;
        }



    }
}
