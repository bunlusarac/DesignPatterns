namespace DesignPatterns.Behavioral.Bridge.Discount;

public class PregnantCitizenDiscount: Discount
{
    public override decimal DiscountRate => 0.5m;
}