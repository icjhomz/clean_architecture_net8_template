using Bookify.Application.Bookings.GetBooking;
using Bookify.Applications.IntegrationTest.Infrastructure;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using FluentAssertions;

namespace Bookify.Applications.IntegrationTest.Bookings;
public class GetBookingTests : BaseIntegrationTest
{
    private static readonly Guid BookingId = Guid.NewGuid();
    public GetBookingTests(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
        
    }

    [Fact]
    public async Task GetBooking_ShouldReturnFailure_WhenBookingIsNotFound()
    {
        //Arrange
        var command = new GetBookingQuery(BookingId);

        //Act
        var result = await _sender.Send(command);

        //Assert
        result.Error.Should().Be(Error.NullValue);
    }
}
