using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJackGameConsoleVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayNewGame();
            Console.ReadKey();

        }

        private static void BlackJack()
        {
            Deck gameDeck = new Deck();
            List<Cards> playingDeck;
            gameDeck.createDeck();
            gameDeck.resetFaceCards();

            int minNumCards = 20; //Minimum number of cards until make a new deck
            bool winner = false;
            int dealerTotal = 0;
            int playerTotal = 0;
            int playeTotalHand = 0;

            gameDeck.shuffleDeck();

            playingDeck = gameDeck.getDeck();

            List<Cards> playerHand = new List<Cards>();
            List<Cards> dealerHand = new List<Cards>();

            while (playingDeck.Count > minNumCards && !winner)
            {
                dealerHand.Add(playingDeck.ElementAt(0));
                playerHand.Add(playingDeck.ElementAt(1));
                dealerHand.Add(playingDeck.ElementAt(2));
                playerHand.Add(playingDeck.ElementAt(3));

                dealerTotal = dealerHand.ElementAt(0).getValue() + dealerHand.ElementAt(1).getValue();
                playerTotal = playerHand.ElementAt(0).getValue() + playerHand.ElementAt(1).getValue();

                for (int i = 0; i < 4; i++)
                {
                    playingDeck.RemoveAt(i);
                }

                Console.WriteLine("This is your card: ");
                Thread.Sleep(2000);
                playerHand.ElementAt(0).printCard();

                Console.WriteLine();

                Console.WriteLine("The dealer has: ");
                Thread.Sleep(2000);
                dealerHand.ElementAt(0).printCard();

                Console.WriteLine();

                Console.WriteLine("This is your second card: ");
                Thread.Sleep(2000);
                playerHand.ElementAt(1).printCard();

                Console.WriteLine();
                Thread.Sleep(2000);
                Console.WriteLine("Your hand is: ");
                playerHand.ElementAt(0).printCard();
                playerHand.ElementAt(1).printCard();
                playeTotalHand = playerHand.ElementAt(0).getValue() + playerHand.ElementAt(1).getValue();
                Console.WriteLine("Total: " + playeTotalHand);

                Console.WriteLine();

                Thread.Sleep(2000);
                Console.WriteLine("Dealer has: ");
                dealerHand.ElementAt(0).printCard();

                if (playeTotalHand == 21)
                {
                    Console.WriteLine();
                    Console.WriteLine("You have BlackJack !");
                    Thread.Sleep(5000);
                    PlayNewGame();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("What would you like to do ? Press H for hit or S for Stand");
                    Console.WriteLine();

                    String userInput = Console.ReadLine().ToUpper();


                    while (!userInput.Equals("H") && !userInput.Equals("S"))
                    {
                        Console.WriteLine("What would you like to do ? Press H for hit or S for Stand");
                        userInput = Console.ReadLine().ToUpper();
                        Console.WriteLine();
                    }

                    
                    while (userInput.Equals("H") && playerTotal < 22 && !winner)
                    {
                        playerHand.Add(playingDeck.ElementAt(0));
                        playerTotal = playerTotal + playingDeck.ElementAt(0).getValue();
                        playingDeck.RemoveAt(0);
                        printList(playerHand);
                        Console.WriteLine("Total: " + playerTotal);

                        Console.WriteLine("What would you like to do ? Press H for hit or S for Stand");
                        Console.WriteLine();
                        userInput = Console.ReadLine().ToUpper();

                        if (playerTotal > 21)
                        {
                            winner = true;
                        }
                    }

                    while (userInput.Equals("S") && dealerTotal < 17 && !winner)
                    {
                        dealerHand.Add(playingDeck.ElementAt(0));
                        dealerTotal = dealerTotal + playingDeck.ElementAt(0).getValue();
                        playingDeck.RemoveAt(0);
                        printList(dealerHand);            
                        Console.ReadKey();
                        Console.WriteLine();
                        Console.WriteLine("Total: " + dealerTotal);
                    }

                    if (dealerTotal > playerTotal && dealerTotal < 22)
                    {
                        Console.WriteLine();
                        winner = true;
                        Console.WriteLine("Dealer wins with " + dealerTotal + " over your hand with " + playerTotal);
                    }
                    else if (playerTotal > 21)
                    {
                        Console.WriteLine();
                        winner = true;
                        Console.WriteLine("You are busted ! Dealer wins !");
                    }
                    else if (dealerTotal > 21)
                    {
                        Console.WriteLine();
                        winner = true;
                        Console.WriteLine("Dealer is busted. You win !");
                    }
                    else if (playerTotal > dealerTotal)
                    {
                        Console.WriteLine();
                        winner = true;
                        Console.WriteLine("You win with " + playerTotal + " over Dealer's hand with " + dealerTotal);
                    }
                    else if (playerTotal == 21)
                    {
                        Console.WriteLine();
                        winner = true;
                        Console.WriteLine("Congrats you have BlackJack !");
                    }
                    else if (dealerTotal == 21)
                    {
                        Console.WriteLine();
                        winner = true;
                        Console.WriteLine("Dealer has 21 ! You lost !");
                    }
                    else if (dealerTotal == playerTotal)
                    {
                        Console.WriteLine();
                        winner = true;
                        Console.WriteLine("Tie you both have " + dealerTotal);
                    }
                    Thread.Sleep(5000);
                    PlayNewGame();
                }
            }
        }

        private static void PlayNewGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome !");

            int userInput = 0;

            while (userInput == 0)
            {
                try
                {
                    Console.WriteLine("To play BlackJack press 1");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if(userInput != 1)
                    {
                        userInput = 0;
                    }
                }
                catch ( Exception e)
                {

                }

                if (userInput == 1)
                {
                    BlackJack();
                }
                else
                {
                    Console.WriteLine("Wrong input !");
                }
            }
        }
        private static void printList(List<Cards> currentList)
        {
            for (int i = 0; i < currentList.Count; i++)
            {
                currentList.ElementAt(i).printCard();
            }
        }
    }
}
