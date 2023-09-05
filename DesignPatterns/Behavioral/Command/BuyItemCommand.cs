namespace DesignPatterns.Behavioral.Command;

public class BuyItemCommand : ICommand
{
    private readonly IItemRepository _itemRepository;
    private readonly IWallet _wallet;
    private readonly Item _item;

    public BuyItemCommand(IItemRepository itemRepository, IWallet wallet, Item item)
    {
        _itemRepository = itemRepository;
        _wallet = wallet;
        _item = item;
    }

    public void Execute()
    {
        _wallet.Withdraw(_item.Price);
        _itemRepository.AddItem(_item);
    }

    public bool CanExecute()
    {
        return _wallet.Balance >= _item.Price; 
    } 
    
    public void Undo()
    {
        _itemRepository.RemoveItemById(_item.Id);
        _wallet.Deposit(_item.Price);
    }
}