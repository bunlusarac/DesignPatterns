namespace DesignPatterns.Behavioral.Bridge.Discount;

public abstract class Discount
{
    public virtual decimal DiscountRate { get; }
    public decimal CalculateFinalPrice(decimal originalPrice) => originalPrice * (1 - DiscountRate);
}