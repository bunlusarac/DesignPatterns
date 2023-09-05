namespace DesignPatterns.Behavioral.Command;

public class Wallet : IWallet
{
    private decimal _balance = 0m;

    public void Withdraw(decimal amount)
    {
        if (_balance < amount) throw new InvalidOperationException();
        _balance -= amount;
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public decimal Balance => _balance;
}