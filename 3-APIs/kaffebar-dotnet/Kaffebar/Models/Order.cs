namespace Kaffebar.Models;

public record Order
{
    public Guid Id { get; init; }
    public Guid CoffeeId { get; init; }
    public Size Size { get; init; }
    public MilkType MilkType { get; init; }
    public bool ExtraShot { get; init; }
    public DateTimeOffset Timestamp { get; init; }
    
    public OrderStatus Status { get; set; } = OrderStatus.PENDING;
}