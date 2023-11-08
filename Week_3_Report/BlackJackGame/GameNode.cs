using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
    public class GameNode
    {
        #region Member Variables

        private Player _player;
        private Dealer _dealer;
        private Deck _deck;

        private bool isExit = false;
        private bool isGameOver = false;
        #endregion

        #region Flow
        public void Start()
        {
            _player = new Player();
            _dealer = new Dealer();
            _deck = new Deck();
        }

        public void Update()
        {
            if (!isGameOver)
            {
                this.StartingDrawTheCard();
                this.UI_StartingInfoText();
                this.DrawTheCardFromTotalscore();
                this.DealerDrawTheCardFromTotalscore();
                this.WhoIsVictory();
            }
            else
            {
                this.Start();
                this.UI_RematchConfirm();
            }
        }
        #endregion

        #region Main Methods
        private void StartingDrawTheCard()
        {
            for(int i = 0; i < 2; ++i)
            {
                _player.DrawCardFromDeck(_deck);
                _dealer.DrawCardFromDeck(_deck);
            }
        }

        private void DrawTheCardFromTotalscore()
        {
            while(_player.Hand.GetTotalValue() < Helper.g_TotalScoreMax)
            {
                Console.Write("Draw the card ? [Y/N] : ");
                char input = char.Parse(Console.ReadLine());

                if (input == 'y' || input == 'Y')
                {
                    Card drawnCard = _player.DrawCardFromDeck(_deck);

                    Console.WriteLine($"You pick up the Card : {drawnCard}");
                    Console.WriteLine($"Your Total Score : {_player.Hand.GetTotalValue()}");
                }
                else
                    break;
            }
        }

        private void DealerDrawTheCardFromTotalscore()
        {
            Console.WriteLine("Dealer Turn.");

            _dealer.DrawTheCards(_deck);

            Console.WriteLine($"Dealer Total Score : {_dealer.Hand.GetTotalValue()}");
        }

        private void WhoIsVictory()
        {
            if (_player.Hand.GetTotalValue() > Helper.g_TotalScoreMax)
            {
                Console.WriteLine("Player's total score over '21', Dealer Win.");
                isGameOver = true;
            }
            else if (_dealer.Hand.GetTotalValue() > Helper.g_TotalScoreMax)
            {
                Console.WriteLine("Dealer's total score over '21', Player Win.");
                isGameOver = true;
            }
            else if (_player.Hand.GetTotalValue() > _dealer.Hand.GetTotalValue())
            {
                Console.WriteLine("[Player Win!!!]");
                isGameOver = true;
            }
            else
            {
                Console.WriteLine("[Dealer Win]  You Lose...");
                isGameOver = true;
            }
        }
        #endregion

        #region Helper Methods
        public void UI_StartingInfoText()
        {
            Console.WriteLine("[Game Start]");
            Console.WriteLine($"Player Init card Total score : {_player.Hand.GetTotalValue()}");
            Console.WriteLine($"Dealer Init card Total score : {_dealer.Hand.GetTotalValue()}");
        }

        public void UI_RematchConfirm()
        {
            Console.Write("[Re match?] [Y/N] >> ");
            char input = char.Parse(Console.ReadLine());

            if(input == 'y' || input == 'Y')
            {
                Thread.Sleep(1000);
                Console.Clear();
                isGameOver = false;
            }
            else
                isExit = true;
        }

        public bool IsExit() { return isExit; }
        #endregion
    }
}
