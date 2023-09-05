namespace DesignPatterns.Behavioral.Command;

public class ItemRepository: IItemRepository
{
    private readonly List<Item> _items = new();
    
    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void RemoveItemById(Guid itemId)
    {
        _items.RemoveAll(i => i.Id == itemId);
    }

    public Item GetItemById(Guid itemId)
    {
        return _items.First(i => i.Id == itemId);
    }

    public IEnumerable<Item> GetAllItems()
    {
        return _items;
    }
}