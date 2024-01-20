namespace Leilart.Data;


using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

public interface IDBConnection : IDisposable
{
    IDbConnection Connection { get; }

    T ExecuteScalar<T>(string sql, object parameters = null);

    IEnumerable<T> Query<T>(string sql, object parameters = null);

    int Execute(string sql, object parameters = null);
}
