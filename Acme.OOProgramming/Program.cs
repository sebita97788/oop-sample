using Acme.OOProgramming.SupplyChain.Domain.Model.Aggregates;
using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;
using Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects;

var supplierAddress = new Address("Supplier St", "123", "SupplierCity", null, "12345", "United States");
var supplier = new Supplier(new SupplierId("SUP001"), "Supplier Inc.", supplierAddress);

Console.WriteLine($"Registered Supplier {supplier.Id.Identifier}: {supplier}");