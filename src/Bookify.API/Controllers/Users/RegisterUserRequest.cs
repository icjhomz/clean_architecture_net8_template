using Bookify.Application.Abstractions.Messaging;

namespace Bookify.API.Controllers.Users;
public sealed record RegisterUserRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password) : ICommand<Guid>;