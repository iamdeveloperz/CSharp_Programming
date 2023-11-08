namespace BlackJackGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameNode gameNode = new GameNode();

            gameNode.Start();

            while (!gameNode.IsExit())
                gameNode.Update();
        }
    }

    public class Num
    {
        public int value;
    }
}