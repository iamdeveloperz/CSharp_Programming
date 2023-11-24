namespace Learning_Week4;

public interface IMovable
{
    void Move(int x, int y);
}

public interface IItemPickable
{
    void PickUp();
}

public interface IItemDroppable
{
    void Drop();
}