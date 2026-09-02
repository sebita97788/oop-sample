using Acme.OOProgramming.Procurement.Domain.Model.Aggregates;
using Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;
using Acme.OOProgramming.SupplyChain.Domain.Model.Aggregates;
using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;
using SupplyChainSupplierId = Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects.SupplierId;

var supplierAddress = new Address("Supplier St", "123", "SupplierCity", null, "12345", "United States");
var supplier = new Supplier(new SupplyChainSupplierId("SUP001"), "Supplier Inc.", supplierAddress);

Console.WriteLine($"Registered Supplier {supplier.Id.Identifier}: {supplier}");

// Procurement never uses SupplyChain's SupplierId directly: translate its raw identifier here
var purchaseOrder = new PurchaseOrder("PO001", new SupplierId(supplier.Id.Identifier), DateTime.UtcNow, "USD");

Console.WriteLine($"Purchase Order {purchaseOrder.OrderNumber} created for Supplier ID {purchaseOrder.SupplierId.Identifier} in {purchaseOrder.Currency}");

purchaseOrder.AddItem(ProductId.New(), 10, 25.99m);
purchaseOrder.AddItem(ProductId.New(), 20, 19.99m);
Console.WriteLine($"Items added: {purchaseOrder.Items.Count}");

foreach (var item in purchaseOrder.Items)
{
    Console.WriteLine($"Order Item Total: {item.CalculateItemTotal()}");
}

Console.WriteLine($"Order Total: {purchaseOrder.CalculateTotal()}");