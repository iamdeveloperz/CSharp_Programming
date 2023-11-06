namespace Week_1_Report2
{
    internal class SimpleCalculator
    {
        public static void Calucalting(int num1, int num2, char oper)
        {
            float sum = 0f;
            switch(oper)
            {
                case '+':
                    sum = num1 + num2;
                    break;
                case '-':
                    sum = num1 - num2;
                    break;
                case '*':
                    sum = num1 * num2;
                    break;
                case '/':
                    sum = (float)num1 / num2;
                    break;
            }

            Console.WriteLine("{0} {1} {2} = {3}", num1, oper, num2, sum);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Input [number operator number]");
            Console.Write("Ex) 10 + 5 >>");

            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            SimpleCalculator.Calucalting(int.Parse(numbers[0]), int.Parse(numbers[2]), char.Parse(numbers[1]));
        }
    }
}