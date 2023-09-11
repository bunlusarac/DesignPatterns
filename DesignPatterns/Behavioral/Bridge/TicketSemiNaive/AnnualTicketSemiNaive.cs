namespace DesignPatterns.Behavioral.Bridge.TicketSemiNaive;

public class AnnualTicketSemiNaive: TicketSemiNaive
{
    public override DateTime? GetExpiration() => DateTime.UtcNow.AddYears(1);

    public AnnualTicketSemiNaive(Discount.Discount discount) : base(discount) { }
}