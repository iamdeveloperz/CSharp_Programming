namespace Learning_Week4
{
    internal class Program
    {
        private static void Main()
        {
            Player player = new Player();
            Item item = new Item("Axe");
            
            player.PickupItem(item);
            player.DropItem(item);
            player.Move(10, 20);
        }
    }
}