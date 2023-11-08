using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Report
{
    public class StageLevel
    {
        #region Member Variables
        public int LevelWidth { get { return _levelWidth; } }
        public int LevelHeight {  get { return _levelHeight; } }

        public int LevelBlankUnit = 1;

        private int _levelWidth;
        private int _levelHeight;
        #endregion

        #region Constructor & Destructor
        public StageLevel(int maxX, int maxY)
        {
            _levelWidth = maxX + LevelBlankUnit;
            _levelHeight = maxY + LevelBlankUnit;
        }
        #endregion

        #region Main Methods
        public void DrawLevel()
        {
            this.DrawTitleText();

            string symbol = "│";
            // 세로 벽 그리기
            for (int posY = LevelBlankUnit + 1; posY < _levelHeight; ++posY)
            {
                Console.SetCursorPosition(LevelBlankUnit, posY);
                Console.Write(symbol);

                Console.SetCursorPosition(_levelWidth - LevelBlankUnit, posY);
                Console.Write(symbol);
            }

            // 가로 벽 그리기
            for (int posX = LevelBlankUnit; posX < _levelWidth; ++posX)
            {
                Console.SetCursorPosition(posX, LevelBlankUnit);
                symbol = (posX == LevelBlankUnit) ? "┌" : (posX == _levelWidth - LevelBlankUnit) ? "┐" : "─";
                Console.Write(symbol);

                Console.SetCursorPosition(posX, _levelHeight);
                symbol = (posX == LevelBlankUnit) ? "└" : (posX == _levelWidth - LevelBlankUnit) ? "┘" : "─";
                Console.Write(symbol);
            }
        }
        #endregion

        #region Helper Methods
        private void DrawTitleText()
        {
            // 타이틀 텍스트
            string titleText = "SNAKE GAME";
            int pivotX = (_levelWidth / 2) - (titleText.Length / 2);
            int pivotY = LevelBlankUnit - 1;

            Helper.PrintTextPos(pivotX, pivotY, titleText);
        }
        #endregion
    }
}
