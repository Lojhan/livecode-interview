

using System.Data.SqlClient;
using Livecode.Domain.Entities;

namespace Livecode.Persistence.Parsers;

public class ClientParser
{
    public Client Parse(SqlDataReader reader)
    {
        return new Client(
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetString(2),
            reader.GetInt32(3)
        );
    }
}