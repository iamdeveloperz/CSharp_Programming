using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Report
{
    public class FoodCreator
    {
        #region Member Variables
        private int _levelWidth;
        private int _levelHeight;
        private int _lerpLevelBlankValue;
        private char _symbol;

        private const int _lerpPosValue = 2;

        private Random _random = new Random();
        #endregion

        #region Constructor & Destructor
        public FoodCreator(StageLevel levelGenerator, char symbol)
        {
            _levelWidth = levelGenerator.LevelWidth;
            _levelHeight = levelGenerator.LevelHeight;
            _lerpLevelBlankValue = levelGenerator.LevelBlankUnit;
            _symbol = symbol;
        }
        #endregion

        #region Main Methods
        public Point CreateFood()
        {
            int posX = _random.Next(_lerpLevelBlankValue + _lerpPosValue, _levelWidth - _lerpPosValue);
            int posY = _random.Next(_lerpLevelBlankValue + _lerpPosValue, _levelHeight - _lerpPosValue);
            return new Point(posX, posY, _symbol);
        }
        #endregion
    }
}
