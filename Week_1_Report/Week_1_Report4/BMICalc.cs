namespace Week_1_Report4
{
    internal class BMICalc
    {
        static void Main(string[] args)
        {
            Console.Write("Input your Tall, Weight >> ");
            string input = Console.ReadLine();
            string[] splitInput = input.Split(',');

            float tall = float.Parse(splitInput[0]);
            float weight = float.Parse(splitInput[1]);

            float sum = weight / MathF.Pow(tall / 100.0f, 2);
            sum = MathF.Round(sum, 2);
            Console.WriteLine("키 {0} / 몸무게 {1} ..... BMI {2}", tall, weight, sum);
        }
    }
}