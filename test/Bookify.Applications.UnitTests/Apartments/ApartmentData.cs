﻿using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Applications.UnitTests.Apartments;

internal static class ApartmentData
{
    public static Apartment Create() => new(
        Guid.NewGuid(),
        new Name("Test Apartment"),
        new Description("Test Description"),
        new Address("Country", "State", "Zipcode", "City", "Street"),
        new Money(100.0m, Currency.Usd),
        Money.Zero(),
        []
        );
}
