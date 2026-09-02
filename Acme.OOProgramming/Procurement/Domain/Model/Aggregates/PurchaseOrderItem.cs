using Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;
using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

namespace Acme.OOProgramming.Procurement.Domain.Model.Aggregates;

public class PurchaseOrderItem
{
    public ProductId ProductId { get; }
    public int Quantity { get; }
    public Money UnitPrice { get; }

    internal PurchaseOrderItem(ProductId productId, int quantity, Money unitPrice)
    {
        if (productId == default)
            throw new ArgumentException("Product ID is required.", nameof(productId));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        if (unitPrice == default)
            throw new ArgumentException("Unit price is required.", nameof(unitPrice));

        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public override bool Equals(object? obj)
    {
        return obj is PurchaseOrderItem other && ProductId == other.ProductId && Quantity == other.Quantity && UnitPrice == other.UnitPrice;
    }

    public override int GetHashCode() => HashCode.Combine(ProductId, Quantity, UnitPrice);

    public override string ToString() => $"PurchaseOrderItem[ProductId={ProductId}, Quantity={Quantity}, UnitPrice={UnitPrice}]";
}