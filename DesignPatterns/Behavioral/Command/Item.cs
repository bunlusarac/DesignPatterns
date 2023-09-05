namespace DesignPatterns.Behavioral.Command;

public class Item
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}