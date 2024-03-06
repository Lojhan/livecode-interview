using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using LanguageExt;
using LanguageExt.Common;
using Livecode.Domain.DTO;
using Livecode.Domain.Entities;
using Livecode.Domain.Errors;
using Livecode.Domain.Usecases;

namespace Livecode.Domain.Services;


public class ClientService
(
CreateClientUsecase createClientUsecase,
ListClientsUsecase listClientsUsecase,
UpdateClientUsecase updateClientUsecase,
IValidator<CreateClientDTO> createClientValidator,
IValidator<UpdateClientDTO> updateClientValidator
)
{
    public async Task<Either<Error, Client>> CreateClientAsync(CreateClientDTO dto)
    {
        var validationResult = await createClientValidator.ValidateAsync(dto);
        if (!validationResult.IsValid) return new ValidationError(validationResult.Errors);
        return await createClientUsecase.CallAsync(dto);
    }

    public async Task<Either<Error, IEnumerable<Client>>> ListClientsAsync(ListClientsDTO dto)
    {
        return await listClientsUsecase.CallAsync(dto);
    }

    public async Task<Either<Error, Client>> UpdateClientAsync(UpdateClientDTO dto)
    {
        var validationResult = await updateClientValidator.ValidateAsync(dto);
        if (!validationResult.IsValid) return new ValidationError(validationResult.Errors);
        return await updateClientUsecase.CallAsync(dto);
    }
}
