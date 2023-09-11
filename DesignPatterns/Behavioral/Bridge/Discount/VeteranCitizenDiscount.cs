namespace DesignPatterns.Behavioral.Bridge.Discount;

public class VeteranCitizenDiscount: Discount
{
    public override decimal DiscountRate => 1m;
}