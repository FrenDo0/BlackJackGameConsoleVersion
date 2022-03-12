using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGameConsoleVersion
{
    class Cards
    {
        private int suit = 0; //1 -> Hearts, 2 -> Spade, 3 -> Diamonds, 4 -> Clubs
        private int value = 0;
        private string color = "No color";
        private string suitName;
        private string faceCard;
        private bool isFaceCard;

        public Cards()
        {
            suit = 0;
            value = 0;
            color = null;
            faceCard = "";
            isFaceCard = false;
        }

        public Cards(int suitD, int valueD, string colorD)
        {
            suit = suitD;
            value = valueD;
            color = colorD;
            if (valueD == 12)
            {
                isFaceCard = true;
                faceCard = "Jack";
            }
            else if (valueD == 13)
            {
                isFaceCard = true;
                faceCard = "Queen";
            }
            else if (valueD == 14)
            {
                isFaceCard = true;
                faceCard = "King";
            }
            else if (valueD == 11)
            {
                isFaceCard = false;
                faceCard = "Ace";
            }
            else if (valueD == 1)
            {
                isFaceCard = false;
                faceCard = "Ace";
            }
            else
            {
                isFaceCard = false;
                faceCard = valueD.ToString();
            }
        }

        public bool IsFaceCard
        {
            get
            {
                return isFaceCard;
            }
            set
            {
                isFaceCard = value;
            }
        }

        public String FaceCard
        {
            get
            {
                return faceCard;
            }
            set
            {
                faceCard = value;
            }
        }

       
        public string getSuitString()
        {
            if(suit == 1)
            {
                suitName = "Heart";
            }
            else if(suit == 2)
            {
                suitName = "Spade";
            }
            else if(suit == 3)
            {
                suitName = "Diamond";
            }
            else
            {
                suitName = "Club";
            }
            return suitName;
        }

        public void printCard()
        {
            getSuitString();
            Console.WriteLine(faceCard + " of " + suitName);
        }

        public void changeValue(int v)
        {
            value = v;
        }

        public int getValue()
        {
            return value;
        }

        public void changeColor(string c)
        {
            color = c;
        }
        public string getColor()
        {
            return color;
        }
    }
}
