using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Shared;
using Bookify.Domain.UnitTests.Apartments;
using Bookify.Domain.UnitTests.Infrastructure;
using Bookify.Domain.Users;
using FluentAssertions;

namespace Bookify.Domain.UnitTests.Bookings;

public class BookingTests : BaseTest
{
    [Fact]
    public void Reserve_Should_RaiseBookingReserveDomainEvent()
    {
        //Arrange
        var user = User.Create(UserData.Firstname, UserData.Lastname, UserData.Email, UserData.Identity);
        var price = new Money(10.0m, Currency.Usd);
        var period = DateRange.Create(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10));
        var apartment = ApartmentData.Create(price);
        var pricingService = new PricingService();

        //Act
        var booking = Booking.Reserve(apartment, user.Id, period, DateTime.UtcNow, pricingService);

        //Assert
        var domainEvent = AssertDomainEventWasPublished<BookingReservedDomainEvent>(booking);

        domainEvent.BookingId.Should().Be(booking.Id);
    }

    [Fact]
    public void Confirm_Booking_Should_RaiseDomainEvent_WhenStatusIsReserved()
    {
        // Arrange
        var user = User.Create(UserData.Firstname, UserData.Lastname, UserData.Email, UserData.Identity);
        var price = new Money(10.0m, Currency.Usd);
        var period = DateRange.Create(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10));
        var apartment = ApartmentData.Create(price);
        var pricingService = new PricingService();

        var booking = Booking.Reserve(apartment, user.Id, period, DateTime.UtcNow, pricingService);
        var utcNow = DateTime.UtcNow;

        // Act
        booking.Confirm(utcNow);

        // Assert
        var domainEvent = AssertDomainEventWasPublished<BookingConfirmedDomainEvent>(booking);

        domainEvent.BookingId.Should().Be(booking.Id);
    }

    [Fact]
    public void Reject_Booking_Should_RaiseDomainEvent_WhenStatusIsReject()
    {
        // Arrange
        var user = User.Create(UserData.Firstname, UserData.Lastname, UserData.Email, UserData.Identity);
        var price = new Money(10.0m, Currency.Usd);
        var period = DateRange.Create(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10));
        var apartment = ApartmentData.Create(price);
        var pricingService = new PricingService();

        var booking = Booking.Reserve(apartment, user.Id, period, DateTime.UtcNow, pricingService);
        var utcNow = DateTime.UtcNow;

        // Act
        booking.Reject(utcNow);

        // Assert
        var domainEvent = AssertDomainEventWasPublished<BookingRejectedDomainEvent>(booking);

        domainEvent.BookingId.Should().Be(booking.Id);
    }

    [Fact]
    public void Complete_Booking_Should_RaiseDomainEvent_WhenStatusIsComplete()
    {
        // Arrange
        var user = User.Create(UserData.Firstname, UserData.Lastname, UserData.Email, UserData.Identity);
        var price = new Money(10.0m, Currency.Usd);
        var period = DateRange.Create(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10));
        var apartment = ApartmentData.Create(price);
        var pricingService = new PricingService();

        var booking = Booking.Reserve(apartment, user.Id, period, DateTime.UtcNow, pricingService);
        
        var utcNow = DateTime.UtcNow;

        // Act
        booking.Confirm(utcNow);
        booking.Complete(utcNow);

        // Assert
        var domainEvent = AssertDomainEventWasPublished<BookingCompletedDomainEvent>(booking);

        domainEvent.BookingId.Should().Be(booking.Id);
    }
    //[Fact]
    //public void Cancel_Booking_Should_RaiseDomainEvent_WhenStatusIsConfirm()
    //{
    //    // Arrange
    //    var user = User.Create(UserData.Firstname, UserData.Lastname, UserData.Email, UserData.Identity);
    //    var price = new Money(10.0m, Currency.Usd);
    //    var period = DateRange.Create(new DateTime(2024, 1, 1), new DateTime(2024, 1, 10));
    //    var apartment = ApartmentData.Create(price);
    //    var pricingService = new PricingService();

    //    var booking = Booking.Reserve(apartment, user.Id, period, DateTime.UtcNow, pricingService);

    //    var utcNow = DateTime.UtcNow;

    //    // Act
    //    if(utcNow < period.Start)
    //        booking.Cancel(utcNow);


    //    // Assert
    //    var domainEvent = AssertDomainEventWasPublished<BookingCancelledDomainEvent>(booking);

    //    domainEvent.BookingId.Should().Be(booking.Id);
    //}
}
