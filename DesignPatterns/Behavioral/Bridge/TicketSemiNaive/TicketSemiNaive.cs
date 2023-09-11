namespace DesignPatterns.Behavioral.Bridge.TicketSemiNaive;

using Discount;

public abstract class TicketSemiNaive
{
    private decimal BasePrice => 50;
    private readonly Discount _discount;

    public DateTime PurchaseTime { get; }

    public TicketSemiNaive(Discount discount)
    {
        _discount = discount;
        PurchaseTime = DateTime.UtcNow;
    }

    public TicketSemiNaive(): this(new NoDiscount()) { }

    public decimal GetPrice() => _discount.CalculateFinalPrice(BasePrice);
    public abstract DateTime? GetExpiration();
}