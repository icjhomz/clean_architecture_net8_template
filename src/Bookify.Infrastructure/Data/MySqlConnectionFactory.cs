using Bookify.Application.Abstractions.Data;
using MySqlConnector;
using System.Data;
namespace Bookify.Infrastructure.Data;

internal sealed class MySqlConnectionFactory : IMySqlConnectionFactory
{
    private readonly string _connectionString;
    public MySqlConnectionFactory(string connection)
    {
        _connectionString = connection;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new MySqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
