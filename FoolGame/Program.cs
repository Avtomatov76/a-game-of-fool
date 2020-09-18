using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using CardClasses;

namespace FoolGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const string YOU_LOSE = "You lost :(."; //Message displayed at the end of the game when someone loses
            Deck deck = new Deck(); //New deck instance
            deck.Shuffle();

            Card trumpCard = deck.DetermineTrump(); //Determining and displaying a trump (trump suit) card and placing it at the bottom of the deck
            Console.WriteLine("Determine a trump card.  The trump is: " + trumpCard);

            FoolHand player = new FoolHand();
            CompHand computer = new CompHand();
            PlayHand playHand = new PlayHand();

            deck.DealCards(player, computer); //Dealing 6 cards to each player in an alternating pattern

            do
            {              
                player.SortCards(player, trumpCard); //sorting cards         
                Console.WriteLine("Player's hand is as follows:\n" + player);

                computer.CompSortCards(computer, trumpCard);
                Console.WriteLine("\nComputers's hand is as follows:\n" + computer);

                bool playerTurn = true; //starting the game with the human player
                

                //PLAYER'S TURN
                do
                {
                    int cardIndex = -1;
                    bool canAttack = true;

                    Console.WriteLine("\nPlease enter the Card number you would like to attack with or enter 'n' to end your turn: ");
                    string input = Console.ReadLine();
                    //cardIndex = InputValidation(input, player);
                    if (input == "n")
                    {
                        playerTurn = false;
                        canAttack = false;
                    }  
                    else
                        cardIndex = InputValidation(input, player); //^^^^SOMETHING IS OFF IN THE LINES ABOVE ^^^^^

                    //if (cardIndex == player.NumCards + 1) //entering 1 more than the total number in a hand terminates player's turn
                    //    playerTurn = false;

                    Card attckCard = player.Attack(cardIndex, player);

                    

                    while (canAttack) // playHand is empty - needs more checking     ***|| playHand.IsEmpty || !player.IsEmpty***
                    {
                        if (playHand.Contains(attckCard))
                        {
                            Console.WriteLine("If you attack more than once, please make sure you attack with a card which value macthes any of the ones that are currently in play.");
                            canAttack = false;
                            playerTurn = false;
                        }
                        else
                        {
                            Console.WriteLine("Player's card to attack with is: " + attckCard);
                            playHand.AddCardToPlayHand(playHand, computer, attckCard);
                            Thread.Sleep(2000);
                            //check if computer can defend
                            Card defCard = computer.CompDefend(computer, attckCard, trumpCard);
                            Console.WriteLine("Computer's card to defend with is: " + defCard); 

                            if (defCard != null)
                            {
                                playHand.AddCard(defCard);

                                TestMessagesMethod(playHand, player, computer); //TEST

                                Console.WriteLine("\nPlease enter the Card number you would like to attack with or enter 'n' to end your turn: ");
                                input = Console.ReadLine();
                                //cardIndex = InputValidation(input, player);
                                if (input == "n")
                                    playerTurn = false;
                                else
                                    cardIndex = InputValidation(input, player);


                                //if (cardIndex == player.NumCards + 1) //entering 1 more than the total number in a hand terminates player's turn
                                //    playerTurn = false;

                                canAttack = player.CanAttackAgain(cardIndex, player, playHand); //PROBLEM SOMEWHERE HERE

                                if (canAttack)
                                    attckCard = player.AttackWithCard(player, cardIndex);
                                TestMessagesMethod(playHand, player, computer); //TEST 
                            }
                            else if (!computer.CanDefend(computer, attckCard, trumpCard))
                            {
                                computer.PickUpCards(computer, playHand);
                                playHand.DiscardAll();
                                player.DrawUpToSixCards(player, deck, trumpCard);
                                player.SortCards(player);
                                computer.CompSortCards(computer, trumpCard);
                                //Console.WriteLine("Player's current hand is:\n" + player);
                                TestMessagesMethod(playHand, player, computer); //TEST                 

                                Console.WriteLine("\nPlease enter the Card number you would like to attack with: ");
                                input = Console.ReadLine();
                                cardIndex = InputValidation(input, player);


                                if (cardIndex == player.NumCards + 1) //entering 1 more than the total number in a hand terminates player's turn
                                    playerTurn = false;

                                canAttack = player.CanAttackAgain(cardIndex, player, playHand); //PROBLEM SOMEWHERE HERE

                                if (canAttack)
                                    attckCard = player.AttackWithCard(player, cardIndex);
                            }
                        } 
 
                    }

                    string doneWithTurn = EndTurn();

                    if (doneWithTurn == "y" && playHand.NumCards % 2 == 0)
                    {
                        playHand.DiscardAll();
                        playerTurn = false;
                    }
                    else if (doneWithTurn == "y" && playHand.NumCards % 2 != 0)
                    {
                        computer.PickPlayHandCards(computer, playHand);
                        Console.WriteLine("Computer picked up because it could not defend the attack.  Computer's hand is currently:\n" + computer);
                        computer.CompSortCards(computer, trumpCard);
                        player.DrawUpToSixCards(player, deck, trumpCard);
                        Console.WriteLine("Player's hand is as follows:\n" + player); //just for testing
                    }

                    Console.WriteLine("Current PlayHand:\n" + playHand.NumCards);      

                } while (playerTurn);

                EndOfTurnMaintenance(deck, trumpCard, player, computer);
                TestMessagesMethod(playHand, player, computer); //TEST

                //COMPUTER'S TURN
                do
                {
                    bool canAttack = true;
                    bool canAttackAgain = false;

                    Console.WriteLine("\nNow, it's computer's turn to attack.");
                    Card compAttack = new Card();

                    while (canAttack) // playHand is empty - needs more checking   || playHand.IsEmpty || !computer.IsEmpty
                    {
                        if (playHand.IsEmpty)
                        {
                            compAttack = computer.Attack(0, computer);
                            playHand.AddCard(compAttack);
                        }    
                        else if (canAttackAgain || (canAttack && !playHand.IsEmpty))
                        {
                            compAttack = computer.AttackAgain(computer, playHand);
                            playHand.AddCard(compAttack);
                        }
                            
                        Console.WriteLine("Computer attacks with: " + compAttack);
                        
                        bool canDefend = false; //bool that gets assigned based on whether or not player can defend

                        Console.WriteLine("\nPlease enter the Card number you would like to defend with, or press 'p' to pick up the card(s): ");
                        string input = Console.ReadLine();

                        if (input == "p")
                        {
                            player.PickPlayHandCards(player, playHand);
                            computer.OffLoadAttackCards(compAttack, computer, playHand);
                            player.PickPlayHandCards(player, playHand);
                            computer.DrawUpToSixCards(computer, deck, trumpCard);
                            computer.CompSortCards(computer, trumpCard);
                            player.SortCards(player);
                            canAttack = true;
                            TestMessagesMethod(playHand, player, computer); //TEST
                        }
                        else
                        {
                            int cardIndex = InputValidation(input, player);

                            Card defCard = player.GetCard(cardIndex);
                            canDefend = player.CanDefendWithSpecificCard(compAttack, defCard, trumpCard);

                            Console.WriteLine("Checking if a player can defend (true/false): " + canDefend);
                            Console.WriteLine("Player is defending with: " + defCard);
                            

                            if (canDefend)
                            {  
                                player.DefendWithCard(defCard, player);
                                playHand.AddCard(defCard);
                                canAttackAgain = computer.CanAttackAgain(computer, playHand);
                                canAttack = computer.CanAttackAgain(computer, playHand);
                                TestMessagesMethod(playHand, player, computer); //TEST
                            }
                            else
                            {
                                Console.WriteLine("You cannot defend with this card.");
                                //player.PickUpCards(player, playHand);
                                //player.SortCards(player);
                                //computer.DrawUpToSixCards(computer, deck, trumpCard);
                                //computer.CompSortCards(computer, trumpCard);

                                computer.OffLoadAttackCards(compAttack, computer, playHand);
                                player.PickPlayHandCards(player, playHand);
                                computer.DrawUpToSixCards(computer, deck, trumpCard);
                                computer.CompSortCards(computer, trumpCard);
                                player.SortCards(player);
                                canAttack = true;
                                
                            }
                            
                        }
                    }

                    playHand.DiscardAll();

                    //TestMessagesMethod(playHand, player, computer); //TEST

                    playerTurn = true;

                } while (!playerTurn);

                EndOfTurnMaintenance(deck, trumpCard, player, computer);

            } while (!deck.IsEmpty);

            //CHECK FOR LOSER

        }

        //JUST FOR TESTING
        static void TestMessagesMethod(PlayHand ph, FoolHand fh, CompHand ch)
        {
            Console.WriteLine("Current PlayHand:\n" + ph); //just for testing
            Console.WriteLine("Player's hand is as follows:\n" + fh); //just for testing
            Console.WriteLine("Computer's hand is as follows:\n" + ch); //just for testing
        }

        static void EndOfTurnMaintenance(Deck d, Card tc, FoolHand fh, CompHand ch) //Helper method: drawing cards and displaying messages at the end of each turn
        {
            DrawUpToSixCards(d, tc, fh, ch); //drawing up to six cards for both players 
            //Console.WriteLine("Player's hand after drawing cards (if less than 6) is as follows:\n" + fh); //just for testing
            //Console.WriteLine("Computer's hand after drawing cards (if less than 6) is as follows:\n" + ch); //just for testing
        }

        static int InputValidation(string input, Hand h) // input validation method
        {
            int index = -1;
            bool isNumber = int.TryParse(input, out index);
            while (!isNumber) 
            {
                Console.WriteLine("You have entered something other than a number.  Please enter a valid number.");
                Console.ReadLine();
            }

            index -= 1; //decrementing index by '1' because of user-friendly numbering from 1 to whatever number of cards (index under the hood still starts at '0'...)

            if (index < 0 || index > h.NumCards - 1)
                index = -1;

            return index;
        }

        static string EndTurn() //Method for determining if a human player wants to end a turn or continue playing
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

        static void CheckForLoser(FoolHand fh, CompHand ch) //Method that checks if someone lost ('Fool')
        {

            //CHECK FOR LOSER
            //DISPLAY A MESSAGE
            //END GAME

        }

        static void DrawUpToSixCards(Deck d, Card tc, Hand h1, CompHand ch)
        {
            if (h1.NumCards < 6)
            {
                h1.DrawUpToSixCards(h1, d, tc);
            }

            if (ch.NumCards < 6)
            {
                ch.DrawUpToSixCards(ch, d, tc);
                ch.CompSortCards(ch, tc);
            }
        }
    }
}
