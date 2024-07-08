namespace Bookify.API.Controllers.Bookings;

public sealed record ReserveBookingRequest(
    Guid ApartmentId,
    Guid UserId,
    DateTime StartDate,
    DateTime EndDate);