using DesignPatterns.Behavioral.Bridge.Discount;
using DesignPatterns.Behavioral.Bridge.Ticket;

namespace DesignPatterns.Test.Behavioral.Bridge;

public class TicketTest
{
    private const decimal StandardCitizenTicketPrice = 50m;
    private const decimal PregnantCitizenTicketPrice = 25m;
    private const decimal RetiredCitizenTicketPrice = 10m;
    private const decimal VeteranCitizenTicketPrice = 0m;

    [Fact]
    public void Ticket_ChildTypesHaveExpectedValues()
    {
        var standardTicket = new Ticket(DiscountType.StandardCitizen, TicketLifetime.Annual);
        var pregnantTicket = new Ticket(DiscountType.PregnantCitizen, TicketLifetime.Annual);
        var retiredTicket = new Ticket(DiscountType.RetiredCitizen, TicketLifetime.Lifelong);
        var veteranTicket = new Ticket(DiscountType.VeteranCitizen, TicketLifetime.Lifelong);

        Assert.Equal(StandardCitizenTicketPrice, standardTicket.GetPrice());
        Assert.Equal(PregnantCitizenTicketPrice, pregnantTicket.GetPrice());
        Assert.Equal(RetiredCitizenTicketPrice, retiredTicket.GetPrice());
        Assert.Equal(VeteranCitizenTicketPrice, veteranTicket.GetPrice());
        
        Assert.Equal(1, standardTicket.GetExpiration().Value.Year - DateTime.UtcNow.Year);
        Assert.Equal(1, pregnantTicket.GetExpiration().Value.Year - DateTime.UtcNow.Year);
        
        Assert.Null(retiredTicket.GetExpiration());
        Assert.Null(veteranTicket.GetExpiration());
    }
}