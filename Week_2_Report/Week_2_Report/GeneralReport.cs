using System.ComponentModel.Design;

namespace Week_2_Report
{
    internal class GeneralReport
    {
        void PrintGugudan()
        {
            for(int i = 2; i < 10; ++i)
            {
                for (int j = 1; j < 10; ++j)
                    Console.WriteLine("{0} x {1} = {2}", i, j, i * j);
            }
        }

        void PaintingStar(bool isFlip = false, bool isPyramid = false, int height = 5)
        {
            for (int i = 0; i < height; ++i) {
                // Not PYRAMID
                if (!isPyramid)
                {
                    if (!isFlip)
                    {
                        for (int j = 0; j < (i + 1); ++j)
                            Console.Write("*");
                    }
                    else
                    {
                        for (int j = height; j > i; --j)
                            Console.Write("*");
                    }
                }
                // Do Pyramid
                else
                {
                    int centerPos = height - 1;     // 5일경우 4가 된다.
                    for(int j = 0; j <= (height * 2); ++j)
                    {
                        if (centerPos - i <= j && centerPos + i >= j)
                            Console.Write("*");
                        else
                            Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        void MinMaxValue()
        {
            int max = 0, min = 0;
            for (int i = 0; i < 5; ++i)
            {
                Console.Write("숫자를 입력하세요: ");
                int value = int.Parse(Console.ReadLine());

                if (min == 0)
                    min = value;

                if (value > max)
                    max = value;
                else if (value < min)
                    min = value;
            }

            Console.WriteLine("최대값: " + max);
            Console.WriteLine("최소값: " + min);
        }

        bool IsPrimeNumber(int number)
        {
            for(int i = 2; i <= Math.Sqrt((double)number); ++i)
            {
                if (number % 2 == 0)
                    return false;
            }

            return true;
        }
        void PrintPrimeNumber()
        {
            Console.Write("숫자를 입력하세요: ");
            int value = int.Parse(Console.ReadLine());

            if (IsPrimeNumber(value))
                Console.WriteLine(value + "는 소수입니다.");
            else
                Console.WriteLine(value + "는 소수가 아닙니다.");
        }

        static void Main(string[] args)
        {
            GeneralReport generalReport = new GeneralReport();
            /*
             * 1. Gugudan
             * 2. Paint Star
             * 3. Min, Max Value
             * 4. Prime Number
             */

            // ①
            // generalReport.PrintGugudan();

            // ②
            // generalReport.PaintingStar(false, true);

            // ③
            // generalReport.MinMaxValue();

            // ④
            generalReport.PrintPrimeNumber();

        }
    }
}