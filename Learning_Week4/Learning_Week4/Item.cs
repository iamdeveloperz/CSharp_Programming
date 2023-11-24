namespace Learning_Week4;

public class Item : IItemPickable, IItemDroppable
{
    public Item(string itemName)
    {
        ItemName = itemName;
    }

    private string ItemName { get; }
    
    public void PickUp()
    {
        Console.WriteLine($"아이템 {ItemName}을 주웠습니다.");
    }

    public void Drop()
    {
        Console.WriteLine($"아이템 {ItemName}을 버렸습니다.");
    }
}