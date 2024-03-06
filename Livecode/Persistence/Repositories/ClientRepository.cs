using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.Common;
using Livecode.Domain.DTO;
using Livecode.Domain.Entities;
using Livecode.Domain.Interfaces;
using Livecode.Persistence.Database;
using Livecode.Persistence.Parsers;

namespace Livecode.Persistence.Repositories;


public class ClientRepository(
    DatabaseContext context,
    ClientParser parser
) : IClientRepository
{
    public async Task<Either<Error, Client>> CreateClientAsync(CreateClientDTO dto)
    {
        using SqlDataReader reader = await context
            .ExecuteReaderAsync(
                @"INSERT INTO clients (name, email, userId) 
                    OUTPUT INSERTED.id, INSERTED.name, INSERTED.email, INSERTED.userId
                    VALUES (@name, @email, @userId)",
                new SqlParameter("@name", dto.Name),
                new SqlParameter("@email", dto.Email),
                new SqlParameter("@phone", dto.UserId)
            );

        await reader.ReadAsync();
        return parser.Parse(reader);
    }

    public async Task<Either<Error, IEnumerable<Client>>> ListClientsAsync(ListClientsDTO dto)
    {
        using SqlDataReader reader = await context
            .ExecuteReaderAsync(
                @"SELECT id, name, email, userId
                    FROM clients
                    WHERE userId = @userId",
                new SqlParameter("@userId", dto.UserId)
            );

        List<Client> clients = [];
        while (await reader.ReadAsync())
        {
            clients.Add(parser.Parse(reader));
        }

        return clients;
    }

    public async Task<Either<Error, Client>> UpdateClientAsync(UpdateClientDTO dto)
    {
        using SqlDataReader reader = await context
            .ExecuteReaderAsync(
                @"UPDATE clients
                    SET name = @name, email = @email
                    OUTPUT INSERTED.id, INSERTED.name, INSERTED.email, INSERTED.userId
                    WHERE id = @id",
                new SqlParameter("@name", dto.Name),
                new SqlParameter("@email", dto.Email),
                new SqlParameter("@id", dto.Id)
            );

        await reader.ReadAsync();
        return parser.Parse(reader);
    }
}