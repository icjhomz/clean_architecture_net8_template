using Bookify.Domain.UnitTests.Infrastructure;
using Bookify.Domain.Users;
using Bookify.Domain.Users.Events;
using FluentAssertions;

namespace Bookify.Domain.UnitTests.Users;

public class UserTests : BaseTest
{
    [Fact]
    public void Create_Should_SetPropertyValues()
    {
        //Act
        var user = User.Create(UserData.Firstname,UserData.Lastname, UserData.Email, UserData.Identity);

        //Assert
        user.FirstName.Should().Be(UserData.Firstname);
        user.LastName.Should().Be(UserData.Lastname);
        user.Email.Should().Be(UserData.Email);
        user.IdentityId.Should().Be(UserData.Identity);
    }

    [Fact]
    public void Create_Should_RaiseUserCreatedDomainEvent()
    {
        //Act
        var user = User.Create(UserData.Firstname, UserData.Lastname, UserData.Email, UserData.Identity);

        //Assert
        var domainEvent = AssertDomainEventWasPublished<UserCreatedDomainEvent>(user);

        domainEvent.UserId.Should().Be(user.Id);
    }
}
