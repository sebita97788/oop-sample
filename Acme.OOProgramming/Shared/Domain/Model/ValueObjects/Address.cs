namespace Acme.OOProgramming.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents an international physical address value object.
/// </summary>
public readonly record struct Address
{
    private const int MaxStreetLength = 100;
    private const int MaxNumberLength = 10;
    private const int MaxCityLength = 100;
    private const int MaxPostalCodeLength = 20;
    private const int MaxCountryLength = 100;

    /// <summary>
    /// The street address.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the street is null, blank, or exceeds <see cref="MaxStreetLength"/> characters.</exception>
    public string Street
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > MaxStreetLength)
                throw new ArgumentException($"Street cannot exceed {MaxStreetLength} characters.", nameof(value));
            field = value;
        }
    }

    /// <summary>
    /// The street address number.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the number is null, blank, or exceeds <see cref="MaxNumberLength"/> characters.</exception>
    public string Number
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > MaxNumberLength)
                throw new ArgumentException($"Number cannot exceed {MaxNumberLength} characters.", nameof(value));
            field = value;
        }
    }

    /// <summary>
    /// The city.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the city is null, blank, or exceeds <see cref="MaxCityLength"/> characters.</exception>
    public string City
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > MaxCityLength)
                throw new ArgumentException($"City cannot exceed {MaxCityLength} characters.", nameof(value));
            field = value;
        }
    }

    /// <summary>
    /// The state or region.
    /// </summary>
    public string? StateOrRegion { get; init; }

    /// <summary>
    /// The postal code.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the postal code is null, blank, or exceeds <see cref="MaxPostalCodeLength"/> characters.</exception>
    public string PostalCode
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > MaxPostalCodeLength)
                throw new ArgumentException($"Postal code cannot exceed {MaxPostalCodeLength} characters.", nameof(value));
            field = value;
        }
    }

    /// <summary>
    /// The country.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when the country is null, blank, or exceeds <see cref="MaxCountryLength"/> characters.</exception>
    public string Country
    {
        get => field ?? string.Empty;
        init
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            if (value.Length > MaxCountryLength)
                throw new ArgumentException($"Country cannot exceed {MaxCountryLength} characters.", nameof(value));
            field = value;
        }
    }

    /// <summary>
    /// Prevents parameterless construction of <see cref="Address"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Always thrown because address components are required.</exception>
    public Address() => throw new InvalidOperationException("Address must be initialized with street, number, city, postal code, and country.");

    /// <summary>
    /// Creates a new instance of <see cref="Address"/>.
    /// </summary>
    /// <param name="street">The address street, which must not be null, blank, or exceed 100 characters.</param>
    /// <param name="number">The address number, which must not be null, blank, or exceed 10 characters.</param>
    /// <param name="city">The address city, which must not be null, blank, or exceed 100 characters.</param>
    /// <param name="stateOrRegion">The address state or region, which can be null.</param>
    /// <param name="postalCode">The address postal code, which must not be null, blank, or exceed 20 characters.</param>
    /// <param name="country">The address country, which must not be null, blank, or exceed 100 characters.</param>
    public Address(string street, string number, string city, string? stateOrRegion, string postalCode, string country)
    {
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
    }

    /// <summary>
    /// Returns a string representation of the address.
    /// </summary>
    /// <returns>A string representation of the address, which may include the state or region if present.</returns>
    public override string ToString() => string.IsNullOrWhiteSpace(StateOrRegion)
        ? $"{Street}, {Number}, {City}, {PostalCode}, {Country}"
        : $"{Street}, {Number}, {City}, {StateOrRegion}, {PostalCode}, {Country}";
}