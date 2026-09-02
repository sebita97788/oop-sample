# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-09-02

### Added
- US001: Register a Supplier: register a `Supplier` with an identifier, name, and address, in its own SupplyChain bounded context.
- US002: Create a Purchase Order: create a `PurchaseOrder` for a `Supplier`, with order number, `DateOnly` order date, and currency validation.
- US003: Add Items to a Purchase Order, US004: Calculate Purchase Order Item Subtotal, US005: Calculate Purchase Order Total: add `PurchaseOrderItem`s to a `PurchaseOrder`, with running total calculation.
- Shared kernel value objects `Address`, `Money`, and `Currency`; identity value objects `SupplierId` and `ProductId`, modeled as C# records.
- `Presentation` layer (`order.Summary`, `money.Display`) via C# 14 extension members, keeping console formatting out of the domain models.
- Console demo in `Program.cs` showing domain validation and invariants.
- Project `README.md` and MIT `LICENSE.md`.