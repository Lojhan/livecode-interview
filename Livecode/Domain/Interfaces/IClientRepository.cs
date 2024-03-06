using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.Common;
using Livecode.Domain.DTO;
using Livecode.Domain.Entities;

namespace Livecode.Domain.Interfaces;

public interface IClientRepository
{
    Task<Either<Error, Client>> CreateClientAsync(CreateClientDTO dto);
    Task<Either<Error, Client>> UpdateClientAsync(UpdateClientDTO dto);
    Task<Either<Error, IEnumerable<Client>>> ListClientsAsync(ListClientsDTO dto);
}