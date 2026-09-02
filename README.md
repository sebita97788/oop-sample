# OOP Sample

[![.NET](https://img.shields.io/badge/.NET-10-purple.svg)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14-blue.svg)](https://learn.microsoft.com/dotnet/csharp/)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE.md)

## Overview

This project is a sample C# console application illustrating Object-Oriented Programming (OOP) and Domain-Driven Design (DDD) principles in a supply chain domain. It features two bounded contexts: SupplyChain (for supplier management) and Procurement (for purchase order management).

### Bounded Contexts & Domain Model

**`Acme.OOProgramming.SupplyChain`** (Supply Chain Management)
- `Supplier` (Aggregate Root): a vendor with identity and location.
- `SupplierId` (Value Object): strongly-typed identifier, owned by SupplyChain.

**`Acme.OOProgramming.Procurement`** (Procurement)
- `PurchaseOrder` (Aggregate Root): purchase order invariants, currency consistency, and item lifecycle; `OrderDate` is a `DateOnly`, a calendar date with no time-of-day or time zone component.
- `PurchaseOrderItem` (Entity): managed exclusively by `PurchaseOrder`, its constructor is `internal`.
- `ProductId` (Value Object): time-ordered identifier generated with UUIDv7 (`Guid.CreateVersion7()`).
- `SupplierId` (Value Object): Procurement's own copy of the concept, deliberately decoupled from SupplyChain's.
- `Presentation.ConsoleFormatting` (`order.Summary`): console-only formatting kept out of the aggregate itself, via a C# 14 extension member.

**`Acme.OOProgramming.Shared`** (Shared Kernel)
- `Money` (Value Object): `decimal` amount + a validated `Currency`, `readonly record struct`.
- `Currency` (Value Object): validated 3-letter ISO code, `readonly record struct`.
- `Address` (Value Object): international postal address, `readonly record struct`.
- `Presentation.ConsoleFormatting` (`money.Display`): console-only formatting kept out of `Money` itself, via a C# 14 extension member.

### Key Domain Rules
- **Aggregate invariant encapsulation**: `PurchaseOrder` strictly controls the creation and lifecycle of `PurchaseOrderItem`.
- **Single-currency rule**: every item in a `PurchaseOrder` is priced in the order's own currency.
- **Currency-safe arithmetic**: `Money` rejects cross-currency operations and negative amounts.
- **Cross-context references**: each bounded context owns its own copy of any identifier it references from another context, rather than sharing one type.
- **Presentation decoupling**: display formatting (`order.Summary`, `money.Display`) lives in dedicated `*.Presentation` namespaces, never on the domain models themselves.

## Class Diagram
See [`docs/class-diagram.puml`](docs/class-diagram.puml). Open it with a PlantUML plugin/viewer to render it.

## Prerequisites
- .NET 10 SDK

## Build and Run
```bash
dotnet build
dotnet run --project Acme.OOProgramming
```

## Docs
- [`docs/user-stories.md`](docs/user-stories.md): acceptance criteria.
- [`CHANGELOG.md`](CHANGELOG.md): version history.

## License
MIT, see [`LICENSE.md`](LICENSE.md).