using System.Data.SqlClient;
using Livecode.Domain.DTO;
using Livecode.Domain.Entities;
using Livecode.Domain.Interfaces;
using Livecode.Persistence.Database;
using Livecode.Persistence.Parsers;

namespace Livecode.Persistence.Repositories;

public class UserRepository(
    DatabaseContext context,
    UserParser parser
) : IUserRepository
{
    public async Task<User> CreateUserAsync(CreateUserDTO dto)
    {
        using SqlDataReader reader = await context.ExecuteReaderAsync(
            @"INSERT INTO users (name) 
            OUTPUT INSERTED.id, INSERTED.name INSERTED.createdAt
            VALUES (@Name)",
            new SqlParameter("@Name", dto.Name)
        );

        await reader.ReadAsync();
        return parser.Parse(reader);
    }
}