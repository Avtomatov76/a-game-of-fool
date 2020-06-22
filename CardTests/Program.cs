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
            TestDetermineTrump();

        
        }

        static void TestDetermineTrump()
        {
            Deck d = new Deck();
            Hand h = d.DealSixCards();
            Console.WriteLine("New hand of 6 Cards.  Expecting 6 cards.\n" + h);

            /*
            d.DetermineTrump();
            Console.WriteLine("Trump Card.  Expecting Ace of Clubs. " + d.GetCard(d.NumCards - 1));
            Console.WriteLine("Moved the 1st card to the bottom of the deck.  The last Card should be a trump card - Ace of Clubs.\n" + d.ToString());
            Console.WriteLine("Total Cards.  Expecting 46. " + d.NumCards);
            */
        }
    }
}
