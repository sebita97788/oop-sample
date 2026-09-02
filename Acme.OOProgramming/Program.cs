using Acme.OOProgramming.Procurement.Domain.Model.Aggregates;
using Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;
using Acme.OOProgramming.Procurement.Presentation;
using Acme.OOProgramming.SupplyChain.Domain.Model.Aggregates;
using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;
using Acme.OOProgramming.Shared.Presentation;
using SupplyChainSupplierId = Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects.SupplierId;

var supplierAddress = new Address("Supplier St", "123", "SupplierCity", null, "12345", "United States");
var supplier = new Supplier(new SupplyChainSupplierId("SUP001"), "Supplier Inc.", supplierAddress);

Console.WriteLine($"Registered Supplier {supplier.Id.Identifier}: {supplier}");

// Procurement never uses SupplyChain's SupplierId directly: translate its raw identifier here
var purchaseOrder = new PurchaseOrder("PO001", new SupplierId(supplier.Id.Identifier), DateTime.UtcNow, "USD");
purchaseOrder.AddItem(ProductId.New(), 10, 25.99m);
purchaseOrder.AddItem(ProductId.New(), 20, 19.99m);

Console.WriteLine(purchaseOrder.Summary);
foreach (var item in purchaseOrder.Items)
{
    Console.WriteLine($"Order Item: {item.ProductId} x {item.Quantity} at {item.UnitPrice.Display} = {item.CalculateItemTotal().Display}");
}

Console.WriteLine($"Order Total: {purchaseOrder.CalculateTotal().Display}");