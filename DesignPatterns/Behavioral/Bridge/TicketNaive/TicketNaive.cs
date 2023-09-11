namespace DesignPatterns.Behavioral.Bridge.TicketNaive;

public abstract class TicketNaive
{
    public DateTime PurchaseTime { get; }

    protected TicketNaive() => PurchaseTime = DateTime.UtcNow;

    public abstract decimal GetPrice();
    public abstract DateTime? GetExpiration();
}