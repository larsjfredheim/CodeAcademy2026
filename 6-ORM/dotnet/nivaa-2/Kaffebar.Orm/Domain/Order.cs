namespace Kaffebar.Orm.Domain;

/// <summary>En bestilling i kaffebaren.</summary>
/// <remarks>
/// Navigasjonene er <c>virtual</c>. Det har ingen betydning før oppgave 1B, der vi skrur på
/// lazy loading. Da lager EF en proxy-subklasse som overstyrer dem, og det kan den bare
/// gjøre med virtuelle egenskaper.
/// </remarks>
public class Order
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public OrderStatus Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>Summen av linjene, lagret på ordren slik den sto på kvitteringen.</summary>
    public decimal TotalPrice { get; set; }

    public virtual List<OrderLine> Lines { get; set; } = [];
    public virtual List<StatusChange> StatusHistory { get; set; } = [];

    public static void AddLine(Order order, NewLine line)
    {
        order.Lines.Add(new OrderLine
        {
            DrinkName = line.DrinkName,
            Size = line.Size,
            Quantity = line.Quantity,
            UnitPrice = line.UnitPrice,
            BeanId = line.BeanId
        });
        order.TotalPrice += line.Quantity * line.UnitPrice;
    }

    public static void RemoveLine(Order order, OrderLine line)
    {
        order.Lines.Remove(line);
        order.TotalPrice -= line.Quantity * line.UnitPrice;
    }
}
