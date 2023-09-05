namespace DesignPatterns.Behavioral.Command;

public interface IWallet
{
    public void Withdraw(decimal amount);
    public void Deposit(decimal amount);
    public decimal Balance { get; }
}