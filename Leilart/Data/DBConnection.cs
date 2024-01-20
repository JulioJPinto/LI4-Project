using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Leilart.Data;

public class DBConnection : IDBConnection
{
    private readonly IConfiguration configuration;
    private readonly IDbConnection connection;


    public DBConnection(IConfiguration configuration)
    {
        this.configuration = configuration;
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        connection = new SqlConnection(connectionString);
    }

    public IDbConnection Connection => connection;

    public T ExecuteScalar<T>(string sql, object parameters = null)
    {
        using (connection)
        {
            connection.Open();
            return connection.ExecuteScalar<T>(sql, parameters);
        }
    }

    public IEnumerable<T> Query<T>(string sql, object parameters = null)
    {
        using (connection)
        {
            connection.Open();
            return connection.Query<T>(sql, parameters);
        }
    }

    public int Execute(string sql, object parameters = null)
    {
        using (connection)
        {
            connection.Open();
            return connection.Execute(sql, parameters);
        }
    }

    public void Dispose()
    {
        if (connection.State != ConnectionState.Closed)
        {
            connection.Close();
        }
        connection.Dispose();
    }

}