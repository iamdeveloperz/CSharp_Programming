using System.Runtime.CompilerServices;

namespace Week_3_Report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameNode gameNode = new GameNode();

            gameNode.Start();

            while(!gameNode.GetIsGameOver())
            {
                Thread.Sleep(Helper.g_GameSpeed);

                gameNode.Update();
            }

            gameNode.UI_GameEndText();
        }
    }

    public class GameNode
    {
        private bool isGameOver = false;
        private Snake? _snakePlayer;
        private StageLevel? _stageLevel;
        private FoodCreator? _foodCreator;

        private Point _food;

        public void Start()
        {
            this.Initialize();
            this.UI_StartText();
            this.SettingScreen();
        }

        public void Update()
        {
            _snakePlayer.MovementInput();
            _snakePlayer.Movement();

            this.SnakeIsHitFood();
            this.UI_GameInfoText();

            if (_snakePlayer.IsHitBody() || _snakePlayer.IsHitBorder(_stageLevel))
                isGameOver = true;
        }

        private void Initialize()
        {
            Point snakeBody = new Point(10, 10, Helper.g_SnakeBodySymbol);

            _snakePlayer = new Snake(snakeBody, 4, E_Direction.UP);
            _stageLevel = new StageLevel(Helper.g_LevelWidth, Helper.g_LevelHeight);
            _foodCreator = new FoodCreator(_stageLevel, Helper.g_FoodSymbol);
        }

        private void SettingScreen()
        {
            _snakePlayer.Draw();
            _stageLevel.DrawLevel();

            _food = _foodCreator.CreateFood();
            _food.Draw();
        }

        private void SnakeIsHitFood()
        {
            if(_snakePlayer.IsHitFood(_food))
            {
                Helper.g_GameScore += 1;

                _food = _foodCreator.CreateFood();

                // 게임 스피드 조절
                if(Helper.g_GameSpeedMin < Helper.g_GameSpeed)
                    Helper.g_GameSpeed -= Helper.g_GameSpeedValue;
            }

            _food.Draw();
        }

        private void UI_GameInfoText()
        {
            string message = "(GameScore) Snake Eat : " + Helper.g_GameScore.ToString();
            string message2 = "Current Game Speed : " + Helper.g_GameSpeed.ToString();

            Helper.PrintTextPos(_stageLevel.LevelWidth + 2, _stageLevel.LevelBlankUnit + 1, message);
            Helper.PrintTextPos(_stageLevel.LevelWidth + 2, _stageLevel.LevelBlankUnit + 3, message2);
        }

        private void UI_StartText()
        {
            string message = "게임을 시작하기 위해서 [Enter]키를 입력해주세요.";

            Helper.PrintTextPos((_stageLevel.LevelWidth / 2) - (int)(message.Length / 1.3), _stageLevel.LevelHeight + 2, message);
            Console.ReadLine();
            Console.Clear();
        }

        public void UI_GameEndText()
        {
            string message = "G  a  m  e     O  v  e  r .";

            Helper.PrintTextPos((_stageLevel.LevelWidth / 2) - (int)(message.Length / 2), _stageLevel.LevelHeight + 2, message);
            Console.ReadLine();
        }

        public bool GetIsGameOver() { return isGameOver; }
    }
}