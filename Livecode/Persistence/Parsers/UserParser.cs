using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Livecode.Domain.Entities;

namespace Livecode.Persistence.Parsers;

public class UserParser
{
    public User Parse(SqlDataReader reader)
    {
        return new User(
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetDateTime(2)
        );
    }
}