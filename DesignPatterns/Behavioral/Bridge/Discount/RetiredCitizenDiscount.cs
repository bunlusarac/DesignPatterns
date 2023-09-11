namespace DesignPatterns.Behavioral.Bridge.Discount;

public class RetiredCitizenDiscount: Discount
{
    public override decimal DiscountRate => 0.8m;
}