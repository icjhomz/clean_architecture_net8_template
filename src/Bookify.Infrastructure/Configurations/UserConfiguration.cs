using Bogus;
using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName)
            .HasMaxLength(200)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value));

        builder.Property(user => user.LastName)
            .HasMaxLength(200)
            .HasConversion(firstName => firstName.Value, value => new LastName(value));

        builder.Property(user => user.Email)
            .HasMaxLength(400)
            .HasConversion(email => email.Value, value => new Domain.Users.Email(value)); ;

        builder.HasIndex(user => user.Email).IsUnique();

        builder.HasIndex(user => user.IdentityId).IsUnique();

        //Seed data
        var users = GetUsers(10);
        builder.HasData(users);
    }
    public static List<User> GetUsers(int count)
    {
        var userFaker = new Faker<User>()
            .CustomInstantiator(f => new User(
                Guid.NewGuid(),
                new FirstName(f.Name.FirstName()),
                new LastName(f.Name.LastName()),
                new Domain.Users.Email(f.Internet.Email()),
                f.Random.Guid().ToString()
            ));

        var users = new List<User>();
        for (int i = 0; i < count; i++)
        {
            users.Add(userFaker.Generate());
        }

        return users;
    }
}
