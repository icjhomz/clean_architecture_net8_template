using Bookify.Application.Apartments.SearchApartments;
using Bookify.Applications.IntegrationTest.Infrastructure;
using FluentAssertions;

namespace Bookify.Applications.IntegrationTest.Apartments;

public class SearchApartmentsTests : BaseIntegrationTest
{
    public SearchApartmentsTests(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task SearchApartments_ShouldReturnEmptyList_WhenDateRangeIsInvalid()
    {
        //Arrange
        var query = new SearchApartmentQuery(new DateTime(2024, 1, 10), new DateTime(2024, 1, 2));

        //Act
        var result = await _sender.Send(query);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEmpty();    
    }

    [Fact]
    public async Task SearchApartments_ShouldReturnApartmentList_WhenDateRangeIsValid()
    {
        //Arrange
        var query = new SearchApartmentQuery(new DateTime(2024, 1, 10), new DateTime(2024, 1, 20));

        //Act
        var result = await _sender.Send(query);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeEmpty();
    }
}
