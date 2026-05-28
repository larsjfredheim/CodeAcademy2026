using System.Collections.Concurrent;
using Kaffebar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kaffebar.Controllers;

[ApiController]
[Route("order")]
public class OrdersController : ControllerBase
{
    private static readonly ConcurrentDictionary<Guid, Order> Orders = new();

    [HttpPost("PlaceOrder")]
    [EndpointSummary("PlaceOrder")]
    public IActionResult PlaceOrder(OrderDto orderDto)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CoffeeId = orderDto.CoffeeId,
            Size = orderDto.Size,
            MilkType = orderDto.MilkType,
            ExtraShot = orderDto.ExtraShot,
            Timestamp = DateTimeOffset.UtcNow
        };
        Orders[order.Id] = order;
        return Created($"/orders/{order.Id}", order);
    }

    [HttpGet]
    [EndpointSummary("GetOrders")]
    public IActionResult GetOrders()
    {
        return Ok(Orders.Values);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("GetOrder")]
    public IActionResult GetOrder(Guid id)
    {
        return Orders.TryGetValue(id, out var order) ? Ok(order) : NotFound();
    }
}
