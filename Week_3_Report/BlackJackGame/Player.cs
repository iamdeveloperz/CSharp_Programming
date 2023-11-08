using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    internal class Player
    {
        #region Member Variables

        public Hand Hand { get; private set; }

        #endregion

        public Player()
        {
            Hand = new Hand();
        }

        #region Main Methods
        public Card DrawCardFromDeck(Deck deck)
        {
            Card drawnCard = deck.DrawCard();

            Hand.AddCard(drawnCard);

            return drawnCard;
        }
        #endregion

        #region Helper Methods
        #endregion
    }
}
