using System.Data;

namespace Bookify.Application.Abstractions.Data;

public interface IMySqlConnectionFactory
{
    IDbConnection CreateConnection();
}
