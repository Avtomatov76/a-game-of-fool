﻿using System;
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
            TestDefendMethod();
            //TestDefendWithSameSuitMethod();
            //TestSortCardsMethod();
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

        static void TestDrawUpToSixCards() //doesnt work
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
            Card c2 = d.DetermineTrump();
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
            Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.DefendWithSameSuit(fh, c, c2));
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);
        }

        static void TestSortCardsMethod()
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
            Console.WriteLine("Defending with a card at index 1 ('Ace of Diamonds').  Expecting 'Ace of Diamonds' displayed.\n" + fh.DefendWithSameSuit(fh, c, c2));
            Console.WriteLine("Current Fool Hand.  Expecting 4 cards left in a hand:\n" + fh);
        }


        #endregion
    }
}
