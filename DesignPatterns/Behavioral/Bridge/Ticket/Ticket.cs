namespace DesignPatterns.Behavioral.Bridge.Ticket;

using static DiscountType;
using static TicketLifetime;

public class Ticket
{
    private decimal BasePrice => 50;
    
    private readonly DiscountType _discountType;
    private readonly TicketLifetime _ticketLifetime;
    
    public DateTime PurchaseTime { get; }

    public Ticket(DiscountType discountType, TicketLifetime ticketLifetime)
    {
        _discountType = discountType;
        _ticketLifetime = ticketLifetime;
        PurchaseTime = DateTime.UtcNow;
    }

    private decimal GetDiscountRate() => _discountType switch
    {
        PregnantCitizen => 0.5m,
        RetiredCitizen => 0.8m,
        StandardCitizen => 0m,
        VeteranCitizen => 1m,
        _ => throw new InvalidOperationException()
    };
    
    public decimal GetPrice() => BasePrice * (1 - GetDiscountRate());
    
    public DateTime? GetExpiration() => _ticketLifetime switch
    {
        Annual => DateTime.UtcNow.AddYears(1),
        Lifelong => null,
        _ => throw new InvalidOperationException()
    };
}