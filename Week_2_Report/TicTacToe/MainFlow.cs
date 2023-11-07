namespace TicTacToe
{
    internal class MainFlow
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe();

            ticTacToe.TicTacToeMainFlow();
        }
    }

    public class TicTacToe
    {
        public TicTacToe()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            _matrix_3By3 = new char[3, 3] {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' } };
        }

        public void PrintUI()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("{0}", "TicTacToe").PadLeft(_padding - (15 - ("TicTacToe".Length / 2))));
            Console.Write(String.Format($"{"플레이어 : X",(-_padding / 2)}"));
            Console.WriteLine(String.Format($"{"인공지능 : O",(_padding / 2)}"));

            if (_isPlayerTurn)
            {
                Console.WriteLine("\n");
                const string message = "플레이어님의 차례입니다.";
                Console.WriteLine(String.Format("{0}", message).PadLeft(_padding - (20 - (message.Length / 2))));
            }
            else
            {
                Console.WriteLine("\n");
                const string message = "인공지능님의 차례입니다.";
                Console.WriteLine(String.Format("{0}", message).PadLeft(_padding - (20 - (message.Length / 2))));
            }
            Console.WriteLine("\n");
        }

        public void PrintMainGame()
        {
            Console.Clear();
            Thread.Sleep(100);

            const int maxRow = 8;
            const int maxCol = 17;

            this.PrintUI();
            for (int row = 0; row < maxRow; ++row)
            {
                for (int col = 0; col < maxCol; ++col)
                {
                    if (col == 5 || col == 11)
                        Console.Write("│");
                    else if (row == 2 || row == 5)
                        Console.Write("-");
                    else if ((row == 1 || row == 4 || row == 7) &&
                        (col == 2 || col == 8 || col == 14))
                    {
                        int ir = (row == 1) ? row - 1 : (row - 3 == 1) ? row - 3 : row - 5;
                        int ic = (col == 2) ? col - 2 : (col - 7 == 1) ? col - 7 : col - 12;

                        Console.Write(_matrix_3By3[ir, ic]);
                    }
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public char PrintInput()
        {
            char input;

            if (_isPlayerTurn)
            {
                Console.WriteLine("\n");
                Console.Write("번호를 입력하세요 >> ");
                input = char.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("\n");
                Console.Write("컴퓨터가 번호를 입력 중입니다...   ");
                input = char.Parse(this.GetRandomNumber().ToString());
                Console.WriteLine(input);
                Console.WriteLine("엔터키를 누르세요.");
                Console.ReadLine();
            }

            return input;
        }

        public int GetRandomNumber(int min = 1, int max = 9 + 1)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void TicTacToeMainFlow()
        {
            while (victoryFlag == -2)
            {
                this.PrintUI();
                this.PrintMainGame();

                int userInput = this.PrintInput();

                NumberMatch(userInput);
            }

            this.PrintUI();
            this.PrintMainGame();

            switch (victoryFlag)
            {
                case -1:        // 인공지능 승리
                    Console.WriteLine("컴퓨터가 이겼습니다.. 떼잉..");
                    break;
                case 0:
                    Console.WriteLine("무승부.. 노력해보세요 좀 더!");
                    break;
                case 1:
                    Console.WriteLine("플레이어가 이겼습니다!!!!!");
                    break;
            }
        }

        private void NumberMatch(int userInput)
        {
            for (int i = 0; i < _matrix_3By3.GetLength(0); ++i)
            {
                for (int j = 0; j < _matrix_3By3.GetLength(1); ++j)
                {
                    if (_matrix_3By3[i, j] == userInput && (userInput != 'O') && (userInput != 'X'))
                    {
                        _matrix_3By3[i, j] = (_isPlayerTurn == true) ? 'X' : 'O';
                        victoryFlag = this.IsVictory();
                        _isPlayerTurn = !_isPlayerTurn;
                        return;
                    }
                    else if (_isPlayerTurn && (userInput < '0' || userInput > '9'))
                    {
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Console.WriteLine("다시 입력바랍니다. (엔터키를 누르세요)");
                        Console.ReadLine();
                        return;
                    }
                    else if (!_isPlayerTurn && (userInput < '0' || userInput > '9'))
                        return;
                }
            }
        }

        private int IsVictory()
        {
            int isVictory = -2;

            for (int i = 0; i < _matrix_3By3.GetLength(0); ++i)
            {
                int colCount = 0;
                int rowCount = 0;
                for (int j = 0; j < _matrix_3By3.GetLength(1); ++j)
                {
                    // 가로 승리
                    if (_isPlayerTurn && _matrix_3By3[i, j] == 'X')
                        ++rowCount;
                    else if (!_isPlayerTurn && _matrix_3By3[i, j] == 'O')
                        ++rowCount;

                        // 세로 승리
                        if (_isPlayerTurn && _matrix_3By3[j, i] == 'X')
                        ++colCount;
                    else if (!_isPlayerTurn && _matrix_3By3[j, i] == 'O')
                        ++colCount;

                    if (rowCount == 3 || colCount == 3)
                        return (_isPlayerTurn == true) ? 1 : -1;
                }
            }

            // 대각선 승리
            if (_matrix_3By3[1, 1] == 'X' && _matrix_3By3[0, 0] == _matrix_3By3[1, 1] && _matrix_3By3[1, 1] == _matrix_3By3[2, 2])
                return (_isPlayerTurn == true) ? 1 : -1;
            else if (_matrix_3By3[1, 1] == 'X' && _matrix_3By3[0, 2] == _matrix_3By3[1, 1] && _matrix_3By3[1, 1] == _matrix_3By3[2, 0])
                return (_isPlayerTurn == true) ? 1 : -1;

            // 무승부 (패배)
            int boardCount = 0;
            foreach (char element in _matrix_3By3)
            {
                if (element < '0' || element > '9')
                    ++boardCount;
            }

            if (boardCount == 9)
                isVictory = 0;

            return isVictory;
        }

        private const int _padding = 40;
        private bool _isPlayerTurn = true;
        private char[,] _matrix_3By3;
        private int victoryFlag = -2;
    }
}