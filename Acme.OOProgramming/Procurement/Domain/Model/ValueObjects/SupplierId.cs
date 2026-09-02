namespace Acme.OOProgramming.Procurement.Domain.Model.ValueObjects;

/// <summary>
/// Represents a reference to a supplier, as understood by the Procurement bounded context.
/// Deliberately decoupled from SupplyChain's own SupplierId: each bounded context models its own
/// concepts independently, even when they refer to the same real-world supplier.
/// </summary>
public readonly record struct SupplierId
{
    /// <summary>
    /// The string identifier value.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the value is null or white space.</exception>
    public string Identifier
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            field = value;
        }
    }

    /// <summary>
    /// Prevents parameterless construction of <see cref="SupplierId"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Always thrown because an identifier is required.</exception>
    public SupplierId() => throw new InvalidOperationException("SupplierId must be initialized with a non-empty identifier.");

    /// <summary>
    /// Creates a new instance of <see cref="SupplierId"/>.
    /// </summary>
    /// <param name="identifier">The unique identifier for the supplier.</param>
    /// <exception cref="ArgumentException">Thrown when the identifier is null or empty.</exception>
    public SupplierId(string identifier) => Identifier = identifier;

    /// <summary>
    /// Returns a string representation of the supplier identifier.
    /// </summary>
    /// <returns>A string representation of the supplier identifier.</returns>
    public override string ToString() => Identifier;
}