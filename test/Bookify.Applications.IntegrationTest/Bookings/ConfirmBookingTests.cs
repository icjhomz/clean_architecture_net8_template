using Bookify.Applications.IntegrationTest.Infrastructure;

namespace Bookify.Applications.IntegrationTest.Bookings;
public class ConfirmBookingTests : BaseIntegrationTest
{
    public ConfirmBookingTests(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task ConfirmBooking_ShouldReturnFailure_WhenBookingIsNotFound()
    {
        //Arrange
        var command = new ConfirmBookingCommand(Guid.NewGuid())
        //Act
        //Assert
    }
}
