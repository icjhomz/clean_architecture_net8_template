using Bookify.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Applications.IntegrationTest.Infrastructure;
public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    private readonly IServiceScope _scope;
    protected readonly ISender _sender;
    protected readonly ApplicationDbContext DbContext;
    public BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        _sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}
