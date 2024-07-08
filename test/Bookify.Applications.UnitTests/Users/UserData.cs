using Bookify.Domain.Users;

namespace Bookify.Application.UnitTests.Users;
internal static class UserData
{
    public static User Create() => User.Create(Firstname, Lastname, Email, Identity);

    public static readonly FirstName Firstname = new("First");
    public static readonly LastName Lastname = new("Last");
    public static readonly Email Email = new("test@test.com");
    public static readonly string Identity = new("identity");
}