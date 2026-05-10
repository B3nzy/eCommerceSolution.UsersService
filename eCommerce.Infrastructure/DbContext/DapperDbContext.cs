using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _dbConnection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string? connectionString = configuration.GetConnectionString("PostgresConnection");

        // Create a new Npgsql Connection using the connection string from appsettings.json
        _dbConnection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection
    {
        get
        {
            if (_dbConnection.State == ConnectionState.Closed)
            {
                _dbConnection.Open();
            }
            return _dbConnection;
        }
    }
}
