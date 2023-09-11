namespace DesignPatterns.Behavioral.Bridge.TicketNaive;

public abstract class AnnualTicketNaive: TicketNaive
{
    public override DateTime? GetExpiration() => DateTime.UtcNow.AddYears(1);
}