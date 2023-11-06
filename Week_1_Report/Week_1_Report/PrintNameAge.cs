namespace Week_1_Report
{
    internal class PrintNameAge
    {
        static void Main(string[] args)
        {
            string input;
            string name;
            int age;
            Console.Write("Input your Name >> "); input = Console.ReadLine(); name = input;
            Console.Write("Input your Age >> "); input = Console.ReadLine(); age = int.Parse(input);

            Console.WriteLine("My name is {0}, and I'm {1} years old.", name, age);
        }
    }
}