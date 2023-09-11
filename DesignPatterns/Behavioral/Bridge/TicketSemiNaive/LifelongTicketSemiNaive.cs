namespace DesignPatterns.Behavioral.Bridge.TicketSemiNaive;

public class LifelongTicketSemiNaive: TicketSemiNaive
{
    public override DateTime? GetExpiration() => null;

    public LifelongTicketSemiNaive(Discount.Discount discount) : base(discount) { }
}