namespace DesignPatterns.Behavioral.Bridge.Discount;

public class NoDiscount: Discount
{
    public override decimal DiscountRate => 0;
}