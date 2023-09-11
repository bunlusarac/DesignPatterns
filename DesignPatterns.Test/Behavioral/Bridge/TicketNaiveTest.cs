using DesignPatterns.Behavioral.Bridge.TicketNaive;

namespace DesignPatterns.Test.Behavioral.Bridge;


public class TicketNaiveTest
{
    private const decimal StandardCitizenTicketPrice = 50m;
    private const decimal PregnantCitizenTicketPrice = 25m;
    private const decimal RetiredCitizenTicketPrice = 10m;
    private const decimal VeteranCitizenTicketPrice = 0m;

    [Fact]
    public void TicketNaive_ChildTypesHaveExpectedValues()
    {
        var standardTicket = new StandardCitizenTicketNaive();
        var pregnantTicket = new PregnantCitizenTicketNaive();
        var retiredTicket = new RetiredCitizenTicketNaive();
        var veteranTicket = new VeteranCitizenTicketNaive();

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