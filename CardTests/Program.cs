using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //DECK TEST
            //TestDetermineTrump();
            TestDealCardsMethod();

            //FOOL HAND TESTS
            //TestGetTrumpSuit();
            //TestHowManyTrumpCards();
            //TestDrawUpToSixCards();
            //TestAtackMethod();
            //TestAttackAgain();
            //TestDefendWithSpecifiedCard();
            //TestDefendMethod();
            //TestDefendWithSameSuitMethod();
            //TestSortCardsMethod();
            //TestCanDefendMethod();
            //TestPickUpCardsTest();

            //PLAY HAND TESTS
            //TestAttackDefendPlayMethod();

            //COMP HAND TESTS
            //TestCompSortCards();
            //TestCompDefendMethod();
            //TestCompPickCard();

            //HAND TESTS
            //TestPickPlayHandCards();
            //TestCompAttackSameValueCard();
            //TestCanAttackAgainMethod();
        }

        #region //HAND TESTS

        static void TestPickPlayHandCards()
        {
            Deck d = new Deck();
            FoolHand fh = new FoolHand();
            PlayHand ph = new PlayHand();
            fh.DrawUpToSixCards(fh, d);
            ph.AddCard(new Card(13, 1));
            ph.AddCard(new Card(13, 2));
            ph.AddCard(new Card(13, 3));

            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            Console.WriteLine("Current Play Hand.  Expecting 3 Kings.\n" + ph);
            fh.PickPlayHandCards(fh, ph);
            Console.WriteLine("Test PickPlayHandCards method");
            Console.WriteLine("Execting 9 cards in Fool Hand:\n" + fh + "\nand '0' cards in Play Hand:\n" + ph.NumCards);
        }

        #endregion

        #region //DECK TESTS

        static void TestDetermineTrump()
        {
            Deck d = new Deck();
            //d.Shuffle();
            Hand h = d.DealSixCards();
            Console.WriteLine("New hand of 6 Cards.  Expecting 6 cards.\n" + h);
            d.DetermineTrump();
            Console.WriteLine("Trump Card.  Expecting '2 of Hearts'. " + d.DisplayTrumpCard());
            Console.WriteLine("Moved the 1st card in the deck after dealing to the bottom of the deck.  The last Card should be a trump card - '2 of Hearts'.\n" + d.ToString());
            Console.WriteLine("Total Cards.  Expecting 46. " + d.NumCards);
        }

        static void TestDealCardsMethod()
        {
            Deck d = new Deck();
            d.Shuffle();

            FoolHand fh = new FoolHand();
            CompHand ch = new CompHand();

            d.DealCards(fh, ch);

            Card tc = d.DetermineTrump();

            fh.SortCards(fh, tc);
            ch.SortCards(ch, tc);

            Console.WriteLine("Test DEalCardsMethod");
            Console.WriteLine("The trump card (Suit) is: " + tc);
            Console.WriteLine("FoolHand.  Expecting 6 cards.\n" + fh);
            Console.WriteLine("CompHand.  Expecting 6 cards.\n" + ch);
        }

        #endregion

        #region //FOOL HAND TESTS

        static void TestHowManyTrumpCards()
        {
            Deck d = new Deck();
            FoolHand fh = new FoolHand(d, 51);

            Console.WriteLine("Test how many trump cards are in the hand");
            d.DetermineTrump();
            Console.WriteLine("Trump Card.  Expecting 'King of Spades'. " + d.DisplayTrumpCard());
            Console.WriteLine("Moved the 1st card in the deck after dealing to the bottom of the deck.  The last Card should be a trump card - 'King of Spades'.\n" + d.ToString());
            Console.WriteLine("Number of trump cards.  Expecting '12'. " + fh.HowManyTrumpCards(fh, d.DisplayTrumpCard()));
        }

        static void TestDrawUpToSixCards() 
        {
            Deck d = new Deck();
            FoolHand fh = new FoolHand();

            fh.AddCard(d.Deal());
            fh.AddCard(d.Deal());

            Console.WriteLine("Test DrawUpToSixCards method");
            Console.WriteLine("Current Fool Hand.  Expecting 2 cards.\n" + fh);
            fh.DrawUpToSixCards(fh, d);
            Console.WriteLine("Drawing 4 more cards.  Expecting 6 cards in the hand:\n" + fh);
            Console.WriteLine("Total Cards left.  Expecting 46. " + d.NumCards);
        }

        static void TestAtackMethod()
        {
            Deck d = new Deck();
            FoolHand fh = new FoolHand();
            fh.DrawUpToSixCards(fh, d);

            Console.WriteLine("Test Attack method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Console.WriteLine("Attacking with a card at index 2 ('Ace of Spades').  Expecting 'Ace of Spades' displayed.\n" + fh.Attack(3));
        }

        static void TestAttackAgain()
        {
            Deck d = new Deck();
            FoolHand fh = new FoolHand();
            fh.DrawUpToSixCards(fh, d);
            //Card c = fh.Attack(3);

            Console.WriteLine("Test AttackAgain method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Console.WriteLine("Attacking with a card at index 2 ('Ace of Spades').  Expecting 'Ace of Spades' displayed.\n" + c);
            //Console.WriteLine("Attacking again with a card of the same value ('Ace of Clubs').  Expecting 'Ace of Clubs' displayed.\n" + fh.AttackAgain(fh, c));
            //Console.WriteLine("Attacking again with a card of the same value ('Ace of Clubs').  Expecting 'Ace of Diamonds' displayed.\n" + fh.AttackAgain(fh, c));
            Console.WriteLine("Current Fool Hand.  Expecting 3 cards left in a hand:\n" + fh);
        }

        static void TestDefendWithSpecifiedCard()
        {
            Deck d = new Deck();
            FoolHand fh = new FoolHand();
            fh.DrawUpToSixCards(fh, d);
            //Card c = fh.Attack(5);

            Console.WriteLine("Test DefendWithSpecifiedCard method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Console.WriteLine("Attacking with a card at index 4 ('2 of Diamonds').  Expecting '2 of Diamonds' displayed.\n" + c);
            //Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.DefendWithSpecifiedCard(1, c));
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);
        }

        static void TestDefendMethod()
        {
            Deck d = new Deck();
            d.Shuffle();
            Card c2 = d.DetermineTrump();
            //just for testing display trump card
            Console.WriteLine("The trump card is: " + d.DisplayTrumpCard());
            FoolHand fh = new FoolHand();
            fh.DrawUpToSixCards(fh, d);
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Card c = fh.Attack(5);
            fh.SortCards(fh);
            Console.WriteLine("Sorted hand of cards.\n" + fh);
            //Random cards are output -- disregard the notes below
            Console.WriteLine("Test Defend method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Console.WriteLine("Attacking with a card at index 4 ('2 of Diamonds').  Expecting '2 of Diamonds' displayed.\n" + c);
            //Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.Defend(fh, c, c2));
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);
        }

        static void TestDefendWithSameSuitMethod()
        {
            Deck d = new Deck();
            d.Shuffle();
            //Card c2 = d.DetermineTrump();
            //just for testing display trump card
            Console.WriteLine("The trump card is: " + d.DisplayTrumpCard());
            FoolHand fh = new FoolHand();
            fh.DrawUpToSixCards(fh, d);
            
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Card c = fh.Attack(5);
            //Random cards are output -- disregard the notes below
            Console.WriteLine("Test Defend method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Console.WriteLine("Attacking with a card at index 4 ('2 of Diamonds').  Expecting '2 of Diamonds' displayed.\n" + c);
            //Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.DefendWithSameSuit(fh, c));
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);
        }

        static void TestSortCardsMethod()
        {
            Deck d = new Deck();
            d.Shuffle();
            //Card c2 = d.DetermineTrump();
            //just for testing display trump card
            Console.WriteLine("The trump card is: " + d.DisplayTrumpCard());
            FoolHand fh = new FoolHand();
            fh.DrawUpToSixCards(fh, d);
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Card c = fh.Attack(5);
            fh.SortCards(fh);
            Console.WriteLine("Sorted hand of cards.\n" + fh);
            //Random cards are output -- disregard the notes below
            Console.WriteLine("Test Defend method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Console.WriteLine("Attacking with a card at index 4 ('2 of Diamonds').  Expecting '2 of Diamonds' displayed.\n" + c);
            //Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.DefendWithSameSuit(fh, c));
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);
        }

        static void TestPickUpCardsTest()
        {
            Deck d = new Deck();
            d.Shuffle();
            Card c = d.DetermineTrump();
            FoolHand fh = new FoolHand();
            FoolHand fh2 = new FoolHand();
            fh.DrawUpToSixCards(fh, d);
            fh2.DrawUpToSixCards(fh2, d);
            
            Console.WriteLine("Test PickupCards method");
            Console.WriteLine("Display a trump card: " + c);
            Console.WriteLine("Display FoolHand #1.  Expecting 6 cards:\n" + fh);
            Console.WriteLine("Display FoolHand #2.  Expecting 6 cards:\n" + fh2);

            fh2.PickUpCards(fh2, fh); //FoolHand #2 picking up cards
            Console.WriteLine("Display FoolHand #1.  Expecting 6 cards:\n" + fh);
            Console.WriteLine("Display FoolHand #2.  Expecting 12 cards:\n" + fh2);
            fh.DiscardAll();
            Console.WriteLine("Display FoolHand #1.  Expecting 0 cards after discrading all cards:\n" + fh.NumCards);
        }

        #endregion

        #region //PLAY HAND TESTS

        static void TestAttackDefendPlayMethod()
        {
            Deck d = new Deck();
            d.Shuffle();
            Card c2 = d.DetermineTrump();
            //just for testing display trump card
            Console.WriteLine("The trump card is: " + d.DisplayTrumpCard());
            FoolHand fh = new FoolHand();
            PlayHand ph = new PlayHand();
            fh.DrawUpToSixCards(fh, d);

            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            //Card c = fh.Attack(1);
            Console.WriteLine("Test AttackDefendPlay method");
            //Console.WriteLine("Attacking with a card at index '0'.\n" + c);
            //Card c3 = fh.Defend(fh, c, c2);
            //Console.WriteLine("Defending with a card from the deck.\n" + c3);
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);
            //ph.AddCardToPlayHand(ph, fh, c);
            //ph.AddCardToPlayHand(ph, fh, c3);
            Console.WriteLine("Current Play Hand.  Expecting 2 cards in a hand:\n" + ph);
            Console.WriteLine("Number of cards in the PlayHand.  Expecting 2 cards:\n" + ph.NumCards);
        }

        static void TestCanDefendMethod()
        {
            Deck d = new Deck();
            d.Shuffle();
            Card c2 = d.DetermineTrump();
            //just for testing display trump card
            Console.WriteLine("The trump card is: " + d.DisplayTrumpCard());
            FoolHand fh = new FoolHand();
            PlayHand ph = new PlayHand();
            fh.DrawUpToSixCards(fh, d);

            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);

            Card c = fh.Attack(1, fh, ph);
            Console.WriteLine("Test AttackDefendPlay method");
            Console.WriteLine("Attacking with a card at index '0'.\n" + c);

            Card c3 = fh.Defend(fh, c, c2);
            Console.WriteLine("Defending with a card from the deck.\n" + c3);
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);

            bool canDefend = fh.CanDefend(fh, c, c2);
            Console.WriteLine("Checking if a player can defend.\n" + canDefend);
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);

            ph.AddCardToPlayHand(ph, fh, c);
            ph.AddCardToPlayHand(ph, fh, c3);
            Console.WriteLine("Current Play Hand.  Expecting 2 cards in a hand:\n" + ph);
            Console.WriteLine("Number of cards in the PlayHand.  Expecting 2 cards:\n" + ph.NumCards);

            DiscardHand dh = new DiscardHand();
            
            Console.WriteLine("Number of cards in the DiscardHand.  Expecting 2 cards:\n" + dh.AddToDiscardPile(dh, ph));
            ph.DiscardAll();
            Console.WriteLine("Number of cards in the PlayHand.  Expecting 0 cards after DiscardAll():\n" + ph.NumCards);
            dh.DiscardAll();
            Console.WriteLine("Number of cards in the DiscardHand.  Expecting 0 cards after DiscardAll():\n" + dh.NumCards);
        }

        #endregion


        #region // COMP HAND TESTS

        static void TestCompSortCards()
        {
            Deck d = new Deck();
            d.Shuffle();
            Card tc = d.DetermineTrump();
            //just for testing display trump card
            Console.WriteLine("The trump card is: " + d.DisplayTrumpCard());
            CompHand ch = new CompHand();
            ch.DrawUpToSixCards(ch, d);
            Console.WriteLine("Current CompHand.  Expecting 6 cards.\n" + ch); 
            ch.CompSortCards(ch, tc);
            Console.WriteLine("Sorted hand of cards.\n" + ch);
        }

        static void TestCompDefendMethod()
        {
            Deck d = new Deck();
            d.Shuffle();
            Card c2 = d.DetermineTrump();
            Card c3 = new Card(4, 1);
            Card c4 = new Card(11, 4);
            //just for testing display trump card
            Console.WriteLine("The trump card is: " + d.DisplayTrumpCard());
            CompHand ch = new CompHand();
            ch.DrawUpToSixCards(ch, d);
            Console.WriteLine("Current CompHand.  Expecting 6 cards.\n" + ch);
            ch.CompSortCards(ch, c2);
            Console.WriteLine("Sorted hand of cards.\n" + ch);
            //Random cards are output -- disregard the notes below
            Console.WriteLine("Test Defend method\n");

            Console.WriteLine("Attacking with a picked card.  Expecting '4 of Clubs' displayed.\n" + c3);   
            Console.WriteLine("Defending with a card from a deck.  Expecting same suite card, trump or null.\n" + ch.CompDefend(ch, c3, c2));
            Console.WriteLine("Current CompHand.  Expecting 5 cards left in a hand:\n" + ch);

            Console.WriteLine("Attacking with a picked card.  Expecting 'Jack of Spades' displayed.\n" + c4);
            Console.WriteLine("Defending with a card from a deck.  Expecting same suite card, trump or null.\n" + ch.CompDefend(ch, c4, c2));
            Console.WriteLine("Current CompHand.  Expecting 4 cards left in a hand:\n" + ch);
        }

        static void TestCompPickCard()
        {
            Deck d = new Deck();
            d.Shuffle();
            Card tc = new Card(2, 2);
            Card c1 = new Card(11, 2);
            Card c2 = new Card(12, 2);
            Card c3 = new Card(13, 2);
            //just for testing display trump card
            Console.WriteLine("The trump card is: " + tc);
            CompHand ch = new CompHand();
            ch.DrawUpToSixCards(ch, d);
            Console.WriteLine("Current CompHand.  Expecting 6 cards.\n" + ch);
            ch.CompSortCards(ch, c2);
            Console.WriteLine("Sorted hand of cards.\n" + ch);
            //Random cards are output -- disregard the notes below
            Console.WriteLine("Test CompPickCard method\n");
            Console.WriteLine("Attacking with a 'Jack of Diamonds' displayed.\n" + c1);
            Console.WriteLine("Cannot defend.  Expecting: false\n" + ch.CanDefend(ch, c1, tc));
            ch.CompPickCard(ch, c1, tc);
            Console.WriteLine("Cannot defend.  Expecting hand to have 7 cards:\n" + ch);

            Console.WriteLine("Attacking with a 'Jack of Diamonds' displayed.\n" + c2);
            Console.WriteLine("Cannot defend.  Expecting: false\n" + ch.CanDefend(ch, c2, tc));
            ch.CompPickCard(ch, c2, tc);
            Console.WriteLine("Cannot defend.  Expecting hand to have 8 cards:\n" + ch);

            Console.WriteLine("Attacking with a 'Jack of Diamonds' displayed.\n" + c3);
            Console.WriteLine("Cannot defend.  Expecting: false\n" + ch.CanDefend(ch, c3, tc));
            ch.CompPickCard(ch, c3, tc);
            Console.WriteLine("Cannot defend.  Expecting hand to have 9 cards:\n" + ch);
        }

        static void TestCompAttackSameValueCard()
        {
            Deck d = new Deck();
            CompHand ch = new CompHand();
            ch.DrawUpToSixCards(ch, d);
            ch.AddCard(new Card(13, 1));
            ch.AddCard(new Card(13, 2));
            Card c = new Card(13, 3);

            Console.WriteLine("Current Fool Hand.  Expecting 8 cards.\n" + ch);
            
            Console.WriteLine("Test CompAttackSameCardValue method");
            Console.WriteLine("Attacking with another King from the Comp Hand:\n" + ch.CompAttackSameCardValue(ch, c));
            Console.WriteLine("Attacking with another King from the Comp Hand:\n" + ch.CompAttackSameCardValue(ch, c));
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + ch);
            Console.WriteLine("Checking if there is a Queen to attack with.  Expecting 'null' returned and 6 cards in hand:\n" + 
                ch.CompAttackSameCardValue(ch, new Card(12, 1)) + "\nnumber of cards in the hand:\n" + ch);
        }

        static void TestCanAttackAgainMethod()
        {
            Deck d = new Deck();
            d.Shuffle();

            FoolHand fh = new FoolHand();
            CompHand ch = new CompHand();
            PlayHand ph = new PlayHand();

            Card tc = d.DetermineTrump();

            ch.DrawUpToSixCards(ch, d);
            ch.CompSortCards(ch, tc);
            fh.DrawUpToSixCards(fh, d);
            fh.SortCards(fh, tc);

            Card lastCard = d.GetCard(d.NumCards - 1);

            Console.WriteLine("Test CanAttackAgain method");
            Console.WriteLine("Determining a trump card.  The trump card (Suit) is: " + tc);
            Console.WriteLine("Last card in the deck - should be the same as the trump card: " + lastCard);
            Console.WriteLine("Current FoolHand.  Expecting 6 cards.\n" + fh);
            Console.WriteLine("Current CompHand.  Expecting 6 cards.\n" + ch);
            Card attkCard = ch.Attack(0, ch, ph);
            Console.WriteLine("Computer attacking a player with: " + attkCard);
            ph.AddCardToPlayHand(ph, fh, attkCard);

            Card defCard = fh.Defend(fh, attkCard, tc);
            Console.WriteLine("Player is defending with the following card: " + defCard);
            ph.AddCardToPlayHand(ph, fh, defCard);

            Console.WriteLine("Current FoolHand.  Expecting 5 cards.\n" + fh);
            Console.WriteLine("Current CompHand.  Expecting 5 cards.\n" + ch);

            Console.WriteLine("Current PlayHand:\n" + ph);
            Console.WriteLine("Checking if compuetr can attack again: " + ch.CanAttackAgain(ch, ph));
        }

        #endregion
    }
}
