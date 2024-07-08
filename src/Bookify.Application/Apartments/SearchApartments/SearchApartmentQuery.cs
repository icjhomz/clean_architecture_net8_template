using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Apartments.SearchApartments;

public record SearchApartmentQuery(DateTime StartDate, DateTime EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;

