using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_3_Report
{
    public static class Helper
    {
        #region Helper Variables
        public static int g_GameSpeed = 150;
        public static int g_GameScore = 0;

        public const int g_GameSpeedValue = 5;
        public const int g_GameSpeedMin = 70;
        public const int g_LevelWidth = 80;
        public const int g_LevelHeight = 20;

        public const char g_SnakeBodySymbol = 'o';
        public const char g_SnakeHeadSymbol = 'O';
        public const char g_FoodSymbol = '$';
        #endregion

        #region Helper Methods
        public static void PrintTextPos(int pivotX, int pivotY, string message)
        {
            Console.SetCursorPosition(pivotX, pivotY);
            Console.Write(message);
        }

        public static void PrintClearSymbol(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(' ');
        }
        #endregion
    }
}
