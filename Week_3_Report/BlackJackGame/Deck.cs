using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    internal class Deck
    {
        #region Member Variables

        private List<Card> _cards;

        #endregion

        public Deck()
        {
            _cards = new List<Card>();

            this.Initialize();
        }

        #region Main Methods
        private void ShuffleTheCards()
        {
            for(int i = 0; i < _cards.Count; ++i)
            {
                int j = Helper.RandomMinMax(i, _cards.Count);

                Helper.Swap<Card>(_cards, i, j);
            }
        }

        public Card DrawCard()
        {
            Card card = _cards[0];

            _cards.RemoveAt(0);

            return card;
        }
        #endregion

        #region Helper Methods
        private void Initialize()
        {
            foreach(E_SUIT suit in Enum.GetValues(typeof(E_SUIT)))
            {
                foreach (E_RANK rank in Enum.GetValues(typeof(E_RANK)))
                    _cards.Add(new Card(suit, rank));
            }

            this.ShuffleTheCards();
        }
        #endregion
    }
}
