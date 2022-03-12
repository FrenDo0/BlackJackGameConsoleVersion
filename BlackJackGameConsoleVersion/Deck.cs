using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGameConsoleVersion
{
    class Deck
    {
        List<Cards> currentDeck;
        int sizeOfDeck = 52;

        public Deck()
        {
            currentDeck = new List<Cards>(sizeOfDeck);
        }

        public List<Cards> getDeck()
        {
            return currentDeck;
        }

        public void createDeck()
        {
            Cards newCard;
            for (int i = 0; i <= 52; i++)
            {
                if (i < 13)
                {
                    if (i == 0)
                    {
                        newCard = new Cards(1, 14, "Red");
                    }
                    else
                    {
                        newCard = new Cards(1, i + 1, "Red");
                    }
                }
                else if (i < 26) 
                {
                    if (i == 13)
                    {
                        newCard = new Cards(2, 14, "Black");
                    }
                    else
                    {
                        newCard = new Cards(2, i - 12, "Black");
                    }
                }
                else if (i < 39)
                {
                    if (i == 26)
                    {
                        newCard = new Cards(3, 14, "Red");
                    }
                    else
                    {
                        newCard = new Cards(3, i - 25, "Red");
                    }
                }
                else
                {
                    if (i == 39)
                    {
                        newCard = new Cards(4, 14, "Black");
                    }
                    else
                    {
                        newCard = new Cards(4, i - 39, "Black");
                    }
                }
                currentDeck.Add(newCard);
            }
        }

        public void printDeck()
        {
            for (int i = 0; i <= sizeOfDeck; i++)
            {
                Console.WriteLine("Suit: " + currentDeck[i].getSuitString() + " Value: " + currentDeck[i].getValue() + " Color" + currentDeck[i].getColor());
            }
        }

        public void resetFaceCards()
        {
            for (int i = 0; i <= 52; i++)
            {
                if (currentDeck[i].IsFaceCard)
                {
                    currentDeck[i].changeValue(10);
                }
            }
        }

        public void shuffleDeck()
        {
            Random rnd = new Random();
            List<Cards> shuffledDeck = new List<Cards>(sizeOfDeck);

            int randomNum = 0;
            for (int i = 0; i <= 52; i++)
            {
                randomNum = rnd.Next(0, sizeOfDeck);
                shuffledDeck.Add(currentDeck[randomNum]);
                currentDeck.RemoveAt(randomNum);
                sizeOfDeck--;
            }
            for (int i = 0; i <= 52; i++)
            {
                currentDeck.Add(shuffledDeck[i]);
            }
        }
    }
}
