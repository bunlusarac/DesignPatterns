namespace DesignPatterns.Behavioral.Bridge.TicketNaive;

public class RetiredCitizenTicketNaive: LifelongTicketNaive
{
    public override decimal GetPrice() => 10m;
}