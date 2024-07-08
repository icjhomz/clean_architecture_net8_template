using Bookify.Domain.Abstractions;
using Bookify.Domain.Users.Events;

namespace Bookify.Domain.Users;

public class User : Entity
{
    public User(Guid id, FirstName firstName, LastName lastName, Email email, string identityId) : base(id) 
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        IdentityId = identityId;
    }
    public User()
    {
        
    }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set;}
    public Email Email { get; private set;}
    public string IdentityId { get; private set; } = string.Empty;

    public static User Create(FirstName firstName, LastName lastName, Email email, string identity)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email, identity);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }

    public void SetIdentity(string identityId)
    {
        IdentityId = identityId;
    }
}
