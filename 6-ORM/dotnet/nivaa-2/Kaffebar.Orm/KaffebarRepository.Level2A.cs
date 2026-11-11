using Kaffebar.Orm.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kaffebar.Orm;

// Oppgave 2A: Include og projeksjon.
public partial class KaffebarRepository
{
    /// <summary>Alle bestillinger med linjer, bønner og brennerier, i én spørring.</summary>
    public async Task<List<Order>> GetAllOrdersWithDetailsAsync()
    {
        return await db.Orders.Include(o => o.Lines)
            .ThenInclude(l => l.Bean)
            .ThenInclude(b => b.Roastery)
            .OrderBy(o => o.CreatedAt)
            .ToListAsync();
    }

    /// <summary>Kvitteringene som DTO-er, uten å laste entiteter.</summary>
    public async Task<List<ReceiptDto>> GetReceiptsAsync()
    {
        return await db.Orders
            .OrderBy(o => o.CreatedAt)
            .Select(o => new ReceiptDto
            (
                o.CustomerName,
                o.Status,
                o.TotalPrice,
                o.Lines.Select(l => new ReceiptLineDto
                (
                    l.Quantity,
                    l.DrinkName,
                    l.Size,
                    l.Bean.Name,
                    l.Bean.Roastery.Name
                )).ToList()
            ))
            .ToListAsync();
    }
}
