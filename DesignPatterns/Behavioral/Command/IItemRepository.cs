namespace DesignPatterns.Behavioral.Command;

public interface IItemRepository
{
    public void AddItem(Item item);
    public void RemoveItemById(Guid itemId);
    public Item GetItemById(Guid id);
    public IEnumerable<Item> GetAllItems();
}