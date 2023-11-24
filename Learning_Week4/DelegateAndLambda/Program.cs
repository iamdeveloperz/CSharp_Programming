// See https://aka.ms/new-console-template for more information

namespace DelegateAndLambda
{
    internal class Program
    {
        delegate void MyDelegate(string message);

        static void Method1(string message) { Console.Write("Method1: " + message); }
        static void Method2(string message) { Console.Write("Method2: " + message); }
        
        static void Main()
        {
            MyDelegate myDelegate = Method1;
            myDelegate += Method2;

            myDelegate("Hello!");
        }
    }
}