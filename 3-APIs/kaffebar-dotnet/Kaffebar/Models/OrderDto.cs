using System.ComponentModel.DataAnnotations;

namespace Kaffebar.Models;

public record OrderDto
{
    [Required]
    public required Guid CoffeeId { get; init; }
    
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public required string CustomerName { get; init; }
    
    [Range(1, 10)]
    public int Quantity { get; init; }
    
    public Size Size { get; init; }
    
    public MilkType MilkType { get; init; }
    
    public bool ExtraShot { get; init; }
    
}