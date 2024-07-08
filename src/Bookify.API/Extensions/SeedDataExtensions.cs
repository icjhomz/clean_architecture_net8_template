using Bogus;
using Bookify.Application.Abstractions.Data;
using Bookify.Domain.Apartments;
using Dapper;
using Newtonsoft.Json;

namespace Bookify.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<IMySqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        var amenitiesList = new List<int> { (int)Amenity.Parking, (int)Amenity.MountView };
        var amenitiesJson = JsonConvert.SerializeObject(amenitiesList);

        List<object> apartments = new();
        for (var i = 0; i < 100; i++)
        {
            apartments.Add(new
            {
                Id = Guid.NewGuid(),
                Name = faker.Company.CompanyName(),
                Description = "Amazing view",
                Country = faker.Address.Country(),
                State = faker.Address.State(),
                ZipCode = faker.Address.ZipCode(),
                City = faker.Address.City(),
                Street = faker.Address.StreetAddress(),
                PriceAmount = faker.Random.Decimal(50, 1000),
                PriceCurrency = "USD",
                CleaningFeeAmount = faker.Random.Decimal(25, 200),
                CleaningFeeCurrency = "USD",
                Amenities = amenitiesJson,
                LastBookedOn = DateTime.MinValue
            });
        }

        const string sql = @"
                            INSERT INTO apartments
                            (id, name, description, address_country, address_state, address_zipcode, address_city, address_street, price_amount, price_currency, cleaningfee_amount, cleaningfee_currency, amenities, lastbookedonutc)
                            VALUES(@Id, @Name, @Description, @Country, @State, @ZipCode, @City, @Street, @PriceAmount, @PriceCurrency, @CleaningFeeAmount, @CleaningFeeCurrency, @Amenities, @LastBookedOn);
                        ";

        connection.Execute(sql, apartments);
    }
}
