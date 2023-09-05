using DesignPatterns.Behavioral.Command;

namespace DesignPatterns.Test.Behavioral.Command;

public class BuyItemCommandTest
{
    [Fact]
    public void BuyItemCommand_ExecuteShouldDecreaseMoneyAndAddToRepo()
    {
        var manager = new CommandManager();
        
        var wallet = new Wallet();
        wallet.Deposit(50);

        var item = new Item
        {
            Name = "Test item",
            Price = 50m
        };

        var repo = new ItemRepository();

        var command = new BuyItemCommand(repo, wallet, item);

        var invokeException = Record.Exception(() => manager.Invoke(command));
        Assert.Null(invokeException);
        
        Assert.Equal(0, wallet.Balance);
        Assert.Single(repo.GetAllItems());
        
        var getException = Record.Exception(() => repo.GetItemById(item.Id));
        Assert.Null(getException);
    }
    
    [Fact]
    public void BuyItemCommand_UndoShouldRefundMoneyAndRemoveFromRepo()
    {
        var manager = new CommandManager();
        
        var wallet = new Wallet();
        wallet.Deposit(50);

        var item = new Item
        {
            Name = "Test item",
            Price = 50m
        };

        var repo = new ItemRepository();

        var command = new BuyItemCommand(repo, wallet, item);
        
        var invokeException = Record.Exception(() => manager.Invoke(command));
        Assert.Null(invokeException);
        
        manager.Undo();
        
        Assert.Equal(50, wallet.Balance);
        Assert.Empty(repo.GetAllItems());
    }
    
    [Fact]
    public void BuyItemCommand_UndoAllShouldRefundMoneyAndRemoveFromRepo()
    {
        var manager = new CommandManager();
        
        var wallet = new Wallet();
        wallet.Deposit(250);

        var item = new Item
        {
            Name = "Test item",
            Price = 50m
        };

        var repo = new ItemRepository();

        var command = new BuyItemCommand(repo, wallet, item);

        var invokeException = Record.Exception(() =>
        {
            manager.Invoke(command);
            manager.Invoke(command);
            manager.Invoke(command);
            manager.Invoke(command);
            manager.Invoke(command);
        });
        
        Assert.Null(invokeException);
        
        manager.UndoAll();
        
        Assert.Equal(250, wallet.Balance);
        Assert.Empty(repo.GetAllItems());
    }
    
    [Fact]
    public void BuyItemCommand_InvokeOnInsufficientFundsShouldThrowException()
    {
        var manager = new CommandManager();
        
        var wallet = new Wallet();
        wallet.Deposit(50);

        var item = new Item
        {
            Name = "Test item",
            Price = 50.1m
        };

        var repo = new ItemRepository();

        var command = new BuyItemCommand(repo, wallet, item);
        
        Assert.Throws<InvalidOperationException>(() => manager.Invoke(command));
        Assert.Equal(50, wallet.Balance);
        Assert.Empty(repo.GetAllItems());
    }
}