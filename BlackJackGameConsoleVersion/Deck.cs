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
        int sizeOfDeck;

        //You can say how many decks you wanna play with
        // sizeOfDeck = 52 -> 1 deck
        // sizeOfDeck = 104 -> 2 decks...
        public Deck(int size)
        {
            sizeOfDeck = size;
            currentDeck = new List<Cards>(sizeOfDeck);
        }

        public List<Cards> getDeck()
        {
            return currentDeck;
        }

    }
}
