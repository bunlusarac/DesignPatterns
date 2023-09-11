namespace DesignPatterns.Behavioral.Bridge.TicketNaive;

public class PregnantCitizenTicketNaive: AnnualTicketNaive
{
    public override decimal GetPrice() => 25m;
}
    