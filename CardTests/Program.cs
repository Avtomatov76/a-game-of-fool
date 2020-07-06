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
            TestPickUpCardsTest();

            //PLAY HAND TESTS
            //TestAttackDefendPlayMethod();

            //DISCARD HAND TESTS
            //
        }

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
            Console.WriteLine("Attacking with a card at index 2 ('Ace of Spades').  Expecting 'Ace of Spades' displayed.\n" + fh.Attack(3));
        }

        static void TestAttackAgain()
        {
            Deck d = new Deck();
            FoolHand fh = new FoolHand();
            fh.DrawUpToSixCards(fh, d);
            Card c = fh.Attack(3);

            Console.WriteLine("Test AttackAgain method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            Console.WriteLine("Attacking with a card at index 2 ('Ace of Spades').  Expecting 'Ace of Spades' displayed.\n" + c);
            Console.WriteLine("Attacking again with a card of the same value ('Ace of Clubs').  Expecting 'Ace of Clubs' displayed.\n" + fh.AttackAgain(fh, c));
            Console.WriteLine("Attacking again with a card of the same value ('Ace of Clubs').  Expecting 'Ace of Diamonds' displayed.\n" + fh.AttackAgain(fh, c));
            Console.WriteLine("Current Fool Hand.  Expecting 3 cards left in a hand:\n" + fh);
        }

        static void TestDefendWithSpecifiedCard()
        {
            Deck d = new Deck();
            FoolHand fh = new FoolHand();
            fh.DrawUpToSixCards(fh, d);
            Card c = fh.Attack(5);

            Console.WriteLine("Test DefendWithSpecifiedCard method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            Console.WriteLine("Attacking with a card at index 4 ('2 of Diamonds').  Expecting '2 of Diamonds' displayed.\n" + c);
            Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.DefendWithSpecifiedCard(1, c));
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
            Card c = fh.Attack(5);
            fh.SortCards(fh);
            Console.WriteLine("Sorted hand of cards.\n" + fh);
            //Random cards are output -- disregard the notes below
            Console.WriteLine("Test Defend method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            Console.WriteLine("Attacking with a card at index 4 ('2 of Diamonds').  Expecting '2 of Diamonds' displayed.\n" + c);
            Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.Defend(fh, c, c2));
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
            Card c = fh.Attack(5);
            //Random cards are output -- disregard the notes below
            Console.WriteLine("Test Defend method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            Console.WriteLine("Attacking with a card at index 4 ('2 of Diamonds').  Expecting '2 of Diamonds' displayed.\n" + c);
            Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.DefendWithSameSuit(fh, c));
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
            Card c = fh.Attack(5);
            fh.SortCards(fh);
            Console.WriteLine("Sorted hand of cards.\n" + fh);
            //Random cards are output -- disregard the notes below
            Console.WriteLine("Test Defend method");
            Console.WriteLine("Current Fool Hand.  Expecting 6 cards.\n" + fh);
            Console.WriteLine("Attacking with a card at index 4 ('2 of Diamonds').  Expecting '2 of Diamonds' displayed.\n" + c);
            Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.DefendWithSameSuit(fh, c));
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
            Card c = fh.Attack(1);
            Console.WriteLine("Test AttackDefendPlay method");
            Console.WriteLine("Attacking with a card at index '0'.\n" + c);
            Card c3 = fh.Defend(fh, c, c2);
            Console.WriteLine("Defending with a card from the deck.\n" + c3);
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);
            ph.AddCardToPlayHand(ph, fh, c);
            ph.AddCardToPlayHand(ph, fh, c3);
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

            Card c = fh.Attack(1);
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


        #region // DISCARD HAND TESTS

        

        #endregion
    }
}
