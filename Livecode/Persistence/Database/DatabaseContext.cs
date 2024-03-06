using System.Data.SqlClient;
namespace Livecode.Persistence.Database
{
    public class DatabaseContext(
        string ConnectionString
    ) : IDisposable
    {
        private readonly SqlConnection _connection = new(ConnectionString);

        public async Task<SqlDataReader> ExecuteReaderAsync(string query, params SqlParameter[] parameters)
        {
            await _connection.OpenAsync();
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddRange(parameters);
            return await command.ExecuteReaderAsync();
        }

        public void Dispose()
        {
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}