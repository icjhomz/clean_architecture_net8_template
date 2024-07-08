﻿using Bookify.Domain.Users;

namespace Bookify.Infrastructure.Repository;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) 
        : base(dbContext)
    {
    }
}
