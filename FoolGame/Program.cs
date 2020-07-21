using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardClasses;

namespace FoolGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const string YOU_LOSE = "You lost :(.";

            PlayHand ph = new PlayHand();

            Deck d = new Deck();
            d.Shuffle();
            Card trumpCard = d.DetermineTrump();
            Console.WriteLine("Determine a trump card: " + trumpCard);
            Console.WriteLine("The trump is: " + d.DisplayTrumpCard());

            bool playerTurn = true;

            FoolHand player = new FoolHand();
            player.DrawUpToSixCards(player, d);
            player.SortCards(player);
            Console.WriteLine("Player's hand is a follows:\n" + player);

            CompHand computer = new CompHand();
            computer.DrawUpToSixCards(computer, d);
            computer.CompSortCards(computer, trumpCard);
            Console.WriteLine("Computers's hand is as follows:\n" + computer);

            do
            {
                Console.WriteLine("Please enter the Card number you would like to attack with: ");
                string input = Console.ReadLine();
                int cardIndex = InputValidation(input);
                Card attckCard = player.Attack(cardIndex, player, ph);

                if (attckCard == null)
                    Console.WriteLine("Please attack with a card which value macthes any of the ones that are currently in play.");

                Console.WriteLine("Player's card to attack with is: " + attckCard);

                
                ph.AddCardToPlayHand(ph, computer, attckCard);
                Card defCard = computer.CompDefend(computer, attckCard, trumpCard);
                Console.WriteLine("Computer's card to defend with is: " + defCard);

                if (defCard != null)
                    ph.AddCard(defCard);

                Console.WriteLine("Current PlayHand:\n" + ph);
                Console.WriteLine("Current Player's hand:\n" + player);
                Console.WriteLine("Current Computer's hand:\n" + computer);


                string doneWithTurn = EndTurn();
                if (doneWithTurn == "y")
                    playerTurn = false;

            } while (playerTurn);

            //// Player's turn
            //Console.WriteLine("Please enter the card number you wish to play with:\n" );
            //string input = Console.ReadLine();
            //int cardIndex = InputValidation(input);
            //Console.WriteLine("You have entered: " + cardIndex);












        }


        static int InputValidation(string input) // input validation method
        {
            int index = 0;
            bool isNumber = int.TryParse(input, out index);
            while (!isNumber)
            {
                Console.WriteLine("You have entered something other than a number.  Please enter a valid number.");
                Console.ReadLine();
            }
            return index;
        }

        static string EndTurn()
        {
            Console.WriteLine("Are you done with your turn?  Please enter 'y'(for a 'yes') or 'n'(for a 'no') only: ");
            string input = Console.ReadLine();
            input = input.ToLower();
            while (input != "y" && input != "n")
            {
                Console.WriteLine("You have entered an incorrect response.  Please enter either 'y' or 'n");
                input = Console.ReadLine();
            }
            return input;
        }

    }
}
