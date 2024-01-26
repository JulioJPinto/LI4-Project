namespace BlazorLeilart.Data;

using System.Data;

public interface IDBConnection
{
    IDbConnection Connection { get; }

    T ExecuteScalar<T>(string sql, object parameters = null);

    IEnumerable<T> Query<T>(string sql, object parameters = null);

    int Execute(string sql, object parameters = null);
}
