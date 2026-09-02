using Acme.OOProgramming.Shared.Domain.Model.ValueObjects;
using Acme.OOProgramming.SupplyChain.Domain.Model.ValueObjects;

namespace Acme.OOProgramming.SupplyChain.Domain.Model.Aggregates;

/// <summary>
/// Represents a supplier aggregate root in the Supply Chain bounded context.
/// </summary>
public class Supplier
{
    /// <summary>
    /// The unique identifier for the supplier.
    /// </summary>
    public SupplierId Id { get; }

    /// <summary>
    /// The name of the supplier.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The address of the supplier.
    /// </summary>
    public Address Address { get; }

    /// <summary>
    /// Creates a new instance of <see cref="Supplier"/>.
    /// </summary>
    /// <param name="id">The supplier identifier, which must not be the default value.</param>
    /// <param name="name">The supplier name, which must not be null or blank.</param>
    /// <param name="address">The supplier address, which must not be the default value.</param>
    /// <exception cref="ArgumentException">Thrown when the id or address is the default value, or the name is null or blank.</exception>
    public Supplier(SupplierId id, string name, Address address)
    {
        if (id == default)
            throw new ArgumentException("Supplier ID is required.", nameof(id));
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (address == default)
            throw new ArgumentException("Supplier address is required.", nameof(address));

        Id = id;
        Name = name;
        Address = address;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Supplier"/> with a string identifier.
    /// </summary>
    /// <param name="identifier">The supplier identifier string.</param>
    /// <param name="name">The supplier name.</param>
    /// <param name="address">The supplier address.</param>
    public Supplier(string identifier, string name, Address address)
        : this(new SupplierId(identifier), name, address)
    {
    }

    /// <summary>
    /// Determines whether this <see cref="Supplier"/> is equal to another object, by identity.
    /// </summary>
    /// <param name="obj">The object to compare against.</param>
    /// <returns><see langword="true"/> if the other object is a <see cref="Supplier"/> with the same <see cref="Id"/>.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Supplier other && Id == other.Id;
    }

    /// <summary>
    /// Returns a hash code based on the supplier's identity.
    /// </summary>
    /// <returns>A hash code derived from <see cref="Id"/>.</returns>
    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>
    /// Returns a string representation of the supplier.
    /// </summary>
    /// <returns>A string representation of the supplier.</returns>
    public override string ToString() => $"Supplier[Id={Id}, Name={Name}, Address={Address}]";
}