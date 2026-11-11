using Kaffebar.Orm.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kaffebar.Orm;

// Oppgave 2B: To samlinger.
public partial class KaffebarRepository
{
    /// <summary>Alle bestillinger med linjer (til og med brenneri) OG statushistorikk.</summary>
    public async Task<List<Order>> GetOrdersWithLinesAndHistoryAsync()
    {
        return await db.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Bean)
            .ThenInclude(b => b.Roastery)
            .Include(o => o.StatusHistory)
            .AsSplitQuery()
            .ToListAsync();
    }
}
