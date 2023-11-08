using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    internal class Dealer : Player
    {
        #region Member Variables
        #endregion

        #region Main Mehtods
        public void DrawTheCards(Deck deck)
        {
            while(Hand.GetTotalValue() < Helper.g_DealerScoreMax)
            {
                Card drawnCard = DrawCardFromDeck(deck);

                Console.WriteLine($"Dealer pick up the Card : {drawnCard}");
                //Console.WriteLine($"Dealer Total Score : { Hand.GetTotalValue()}");
            }
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}
