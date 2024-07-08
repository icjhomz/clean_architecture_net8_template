using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace Bookify.Infrastructure.Authentication;

internal sealed class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly AuthenticationOptions _options;
    public JwtBearerOptionsSetup(IOptions<AuthenticationOptions> authenticationOptions)
    {
        _options = authenticationOptions.Value;
    }
    public void Configure(string? name, JwtBearerOptions options)
    {
        Configure(options);
    }

    public void Configure(JwtBearerOptions options)
    {
        options.Audience = _options.Audience;
        options.MetadataAddress = _options.MetadataUrl;
        options.RequireHttpsMetadata = _options.RequiredHttpsMetadata;
        options.TokenValidationParameters.ValidIssuer = _options.Issuer; 
    }
}
