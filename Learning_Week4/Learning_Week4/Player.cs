namespace Learning_Week4;

public class Player : IMovable
{
    public void Move(int x, int y)
    {
        Console.Write($"Player Movement [{x}, {y}]");
    }

    public void PickupItem(IItemPickable item)
    {
        item.PickUp();
    }

    public void DropItem(IItemDroppable item)
    {
        item.Drop();
    }
}