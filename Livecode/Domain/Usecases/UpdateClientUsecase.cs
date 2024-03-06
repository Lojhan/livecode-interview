


using LanguageExt;
using LanguageExt.Common;

using Livecode.Domain.DTO;
using Livecode.Domain.Entities;
using Livecode.Domain.Interfaces;

namespace Livecode.Domain.Usecases;

public class UpdateClientUsecase(
    IClientRepository clientRepository
)
{
    public async Task<Either<Error, Client>> CallAsync(UpdateClientDTO UpdateClientDTO)
    {
        return await clientRepository.UpdateClientAsync(UpdateClientDTO);
    }
}

