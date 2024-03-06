


using LanguageExt;
using LanguageExt.Common;

using Livecode.Domain.DTO;
using Livecode.Domain.Entities;
using Livecode.Domain.Interfaces;

namespace Livecode.Domain.Usecases;

public class ListClientsUsecase(
    IClientRepository clientRepository
)
{
    public async Task<Either<Error, IEnumerable<Client>>> CallAsync(ListClientsDTO listClientsDTO)
    {
        return await clientRepository.ListClientsAsync(listClientsDTO);
    }
}
