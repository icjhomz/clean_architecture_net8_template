using Bookify.Domain.Users;

internal static class UserData
{
    public static readonly FirstName Firstname = new("First");
    public static readonly LastName Lastname = new("Last");
    public static readonly Email Email = new("test@test.com");
    public static readonly string Identity = new("identity");
}