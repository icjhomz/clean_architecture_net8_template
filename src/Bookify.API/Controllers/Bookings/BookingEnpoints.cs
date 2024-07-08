using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.Bookings.ReserveBooking;
using MediatR;

namespace Bookify.API.Controllers.Bookings;

public static class BookingEndpoints
{
    public static IEndpointRouteBuilder MapBookingEndpoints(this IEndpointRouteBuilder builder)
    {
        //require auth with policy
        //builder.MapGet("api/v{version:apiVersion}/bookings/{id}", GetBooking).RequireAuthorization("policy:permission");
        //builder.MapPost("api/v{version:apiVersion}/bookings", ReserveBooking).RequireAuthorization("policy:permission");

        builder.MapPost("bookings", ReserveBooking);
        builder.MapGet("bookings/{id}", GetBooking)
            .WithName(nameof(GetBooking));

        return builder;
    }

    public static async Task<IResult> GetBooking(
        Guid id,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(id);

        var result = await sender.Send(query, cancellationToken);

        return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound();
    }

    public static async Task<IResult> ReserveBooking(
        ReserveBookingRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(
            request.ApartmentId,
            request.UserId,
            request.StartDate,
            request.EndDate);

        var result = await sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result.Error);
        }

        return Results.CreatedAtRoute(nameof(GetBooking), new { id = result.Value }, result.Value);
    }
}
