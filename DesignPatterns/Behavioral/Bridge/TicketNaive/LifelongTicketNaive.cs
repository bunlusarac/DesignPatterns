namespace DesignPatterns.Behavioral.Bridge.TicketNaive;

public abstract class LifelongTicketNaive: TicketNaive
{
    public override DateTime? GetExpiration() => null;
}