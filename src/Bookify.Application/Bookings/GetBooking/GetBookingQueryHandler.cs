using Bookify.Application.Abstractions.Caching;
using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Dapper;

namespace Bookify.Application.Bookings.GetBooking;

internal sealed class GetBookingQueryHandler(IMySqlConnectionFactory mySqlConnectionFactory)
    : IQueryHandler<GetBookingQuery, BookingResponse>
{
    public async Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        using var connection = mySqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS Id,
                apartmentid AS ApartmentId,
                userid AS UserId,
                status AS Status,
                priceforperiod_amount AS PriceAmount,
                priceforperiod_currency AS PriceCurrency,
                cleaningfee_amount AS CleaningFeeAmount,
                cleaningfee_currency AS CleaningFeeCurrency,
                amenitiesupcharge_amount AS AmenitiesUpChargeAmount,
                amenitiesupcharge_currency AS AmenitiesUpChargeCurrency,
                totalprice_amount AS TotalPriceAmount,
                totalprice_currency AS TotalPriceCurrency,
                duration_start AS DurationStart,
                duration_end AS DurationEnd,
                createdonutc AS CreatedOnUtc
            FROM bookings
            WHERE id = @BookingId
            """;

        var booking = await connection.QueryFirstOrDefaultAsync<BookingResponse>(
            sql,
            new
            {
                request.BookingId
            });

        return booking;
    }
}
