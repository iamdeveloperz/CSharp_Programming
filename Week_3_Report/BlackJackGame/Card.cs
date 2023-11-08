using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    internal class Card
    {
        #region Member Variables

        public E_SUIT Suit { get; private set; }
        public E_RANK Rank { get; private set; }

        #endregion

        public Card(E_SUIT suit, E_RANK rank)
        {
            Suit = suit;
            Rank = rank;
        }

        #region Helper Methods
        public int GetValue()
        {
            if ((int)Rank <= 10)
                return (int)Rank;
            else if ((int)Rank <= 13)
                return 10;
            else
                return 11;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
        #endregion
    }
}
