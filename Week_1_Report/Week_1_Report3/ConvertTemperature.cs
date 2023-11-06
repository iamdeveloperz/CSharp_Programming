namespace Week_1_Report3
{
    internal class ConvertTemperature
    {
        static void Main(string[] args)
        {
            Console.Write("Input Celcius Temperature >> ");
            string input = Console.ReadLine();
            float celcius = float.Parse(input);

            float fahrenheit = (celcius * 1.8f) + 32f;
            fahrenheit = MathF.Round(fahrenheit, 2);
            Console.WriteLine("Celcius Temp. {0} , Fahrenheit Temp. {1}", celcius, fahrenheit);
        }
    }
}