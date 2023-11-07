namespace NumberMatchGame
{
    internal class NumberMatchMain
    {
        static void Main(string[] args)
        {
            NumberMatch numberMatch = new NumberMatch();

            numberMatch.NumberMainFlow();
        }
    }

    public class NumberMatch
    {
        void PrintMain()
        {
            Console.Write("숫자 맞추기 게임을 시작합니다. ");
            Console.WriteLine("1에서 100까지의 숫자 중 하나를 맞춰보세요.");

            GenerateRandomNumber();
        }

        private void GenerateRandomNumber(int min = 1, int max = 100 + 1)
        {
            Random random = new Random();
            _computerNumber = random.Next(min, max);
            _count = 0;
        }

        private void CheckNumberMatch()
        {
            Console.Write("숫자를 입력하세요: ");
            _userNumber = int.Parse(Console.ReadLine());
            ++_count;

            if (_userNumber < _computerNumber)
                Console.WriteLine("너무 작습니다!");
            else if (_userNumber > _computerNumber)
                Console.WriteLine("너무 큽니다!");
            else
            {
                Console.Write("축하합니다! ");
                Console.WriteLine(_count + "번 만에 숫자를 맞추었습니다.");
                _isVictory = true;
            }
        }

        public void NumberMainFlow()
        {
            PrintMain();

            while(!_isVictory)
                this.CheckNumberMatch();
        }

        private int _userNumber;
        private int _computerNumber;
        private int _count;

        private bool _isVictory = false;
    }
}