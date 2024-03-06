
using LanguageExt;
using LanguageExt.Common;

using Livecode.Domain.DTO;
using Livecode.Domain.Entities;
using Livecode.Domain.Interfaces;

namespace Livecode.Domain.Usecases;

public class CreateClientUsecase(
    IClientRepository clientRepository
)
{
    public async Task<Either<Error, Client>> CallAsync(CreateClientDTO createClientDTO)
    {
        return await clientRepository.CreateClientAsync(createClientDTO);
    }
}
