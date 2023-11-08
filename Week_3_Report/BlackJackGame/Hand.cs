using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    internal class Hand
    {
        #region Member Variables

        private List<Card> _cards;

        #endregion

        public Hand()
        {
            _cards = new List<Card>();
        }

        #region Main Methods
        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public int GetTotalValue()
        {
            int total = 0;
            int aceCount = 0;

            foreach(Card card in _cards)
            {
                if (card.Rank == E_RANK.ACE)
                    ++aceCount;

                total += card.GetValue();
            }

            while(total > 21 && aceCount > 0)
            {
                total -= 10;
                --aceCount;
            }

            return total;
        }
        #endregion



        #region Helper Methods
        #endregion
    }
}
