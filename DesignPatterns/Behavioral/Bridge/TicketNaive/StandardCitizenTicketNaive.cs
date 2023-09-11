namespace DesignPatterns.Behavioral.Bridge.TicketNaive;

public class StandardCitizenTicketNaive : AnnualTicketNaive
{
    public override decimal GetPrice() => 50m;
}