using Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;
using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

namespace Acme.OOProgramming.Procurement.Domain.Model.Aggregates;

public class PurchaseOrder
{
    private readonly List<PurchaseOrderItem> _items = new();

    public string OrderNumber { get; }
    public SupplierId SupplierId { get; }
    public DateOnly OrderDate { get; }
    public Currency Currency { get; }

    public IReadOnlyList<PurchaseOrderItem> Items => _items.AsReadOnly();

    public PurchaseOrder(string orderNumber, SupplierId supplierId, DateOnly orderDate, Currency currency)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(orderNumber);
        if (supplierId == default)
            throw new ArgumentException("Supplier ID is required.", nameof(supplierId));
        if (currency == default)
            throw new ArgumentException("Currency is required.", nameof(currency));

        OrderNumber = orderNumber;
        SupplierId = supplierId;
        OrderDate = orderDate;
        Currency = currency;
    }

    public PurchaseOrder(string orderNumber, SupplierId supplierId, DateOnly orderDate, string currency)
        : this(orderNumber, supplierId, orderDate, new Currency(currency)) { }

    public PurchaseOrder(string orderNumber, SupplierId supplierId, DateTime orderDate, string currency)
        : this(orderNumber, supplierId, DateOnly.FromDateTime(orderDate), new Currency(currency)) { }

    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        if (productId == default)
            throw new ArgumentException("Product ID is required.", nameof(productId));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegative(unitPriceAmount);

        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);
    }

    public override bool Equals(object? obj)
    {
        return obj is PurchaseOrder other && OrderNumber == other.OrderNumber;
    }

    public override int GetHashCode() => OrderNumber.GetHashCode();

    public override string ToString() =>
        $"PurchaseOrder[OrderNumber={OrderNumber}, SupplierId={SupplierId}, OrderDate={OrderDate}, Items={_items.Count}, Currency={Currency}]";
}