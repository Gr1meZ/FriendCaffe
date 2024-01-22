using System.Data;
using FriendCaffe.Application.Configuration.Data;
using Npgsql;

namespace FriendCaffe.Infrastructure.Data.Database;

public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
{
    private readonly string _connectionString;
    private IDbConnection _connection;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetOpenConnection()
    {
        if (_connection.State == ConnectionState.Open) return this._connection;
        
        _connection = new NpgsqlConnection(_connectionString);
        _connection.Open();

        return _connection;
    }
    
    public void Dispose()
    {
        if (_connection.State == ConnectionState.Open)
        {
            _connection.Dispose();
        }
    }
}