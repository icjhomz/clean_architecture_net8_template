using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Dapper;
using System.Globalization;

namespace Bookify.Application.Apartments.SearchApartments;

internal sealed class SearchApartmentQueryHandler
    : IQueryHandler<SearchApartmentQuery, IReadOnlyList<ApartmentResponse>>
{
    private static readonly int[] ActiveBookingStatuses =
    {
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
        (int)BookingStatus.Completed
    };
    private readonly IMySqlConnectionFactory _mySqlConnectionFactory;

    public SearchApartmentQueryHandler(IMySqlConnectionFactory mySqlConnectionFactory)
    {
        _mySqlConnectionFactory = mySqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<ApartmentResponse>>> Handle(SearchApartmentQuery request, CancellationToken cancellationToken)
    {
        if (request.StartDate > request.EndDate)
        {
            return new List<ApartmentResponse>();
        }

        // Format the DateTime objects back to strings in the desired format
        string StartDate = request.StartDate.ToString("yyyy-MM-dd");
        string EndDate = request.EndDate.ToString("yyyy-MM-dd");

        using var connection = _mySqlConnectionFactory.CreateConnection();

        const string sql = """
                        SELECT
                a.id AS Id,
                a.name AS Name,
                a.description AS Description,
                a.price_amount AS Price,
                a.price_currency AS Currency,
                a.address_country AS Country,
                a.address_state AS State,
                a.address_zipcode AS ZipCode,
                a.address_city AS City,
                a.address_street AS Street
            FROM apartments AS a   
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM bookings AS b
                WHERE
                    b.apartmentid = a.id AND
                    b.duration_start <= @EndDate AND
                    b.duration_end >= @StartDate AND
                    b.status in ('1','2','5')
            )
            """;

        var apartments = await connection
            .QueryAsync<ApartmentResponse, AddressResponse, ApartmentResponse>(
                sql,
                (apartment, address) =>
                {
                    apartment.Address = address;

                    return apartment;
                },
                new
                {
                    StartDate,
                    EndDate,
                    ActiveBookingStatuses
                },
                splitOn: "Country");

        return apartments.ToList();
    }
}
