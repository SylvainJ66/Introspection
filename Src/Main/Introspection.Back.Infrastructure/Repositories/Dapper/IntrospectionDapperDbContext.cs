using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Introspection.Back.Infrastructure.Repositories.Dapper;

public class IntrospectionDapperDbContext
{
    
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    
    public IntrospectionDapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException();
        _connectionString = _configuration.GetConnectionString("SqlConnection")!;
    }
    
    public IDbConnection CreateConnection()
        => new SqliteConnection(_connectionString);
}

// todo add setup to create the database