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


public class CreateUserService
(
CreateUserUsecase createUserUsecase,
IValidator<CreateUserDTO> validator
)
{
    public async Task<Either<Error, User>> CallAsync(CreateUserDTO dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid) return new ValidationError(validationResult.Errors);
        return await createUserUsecase.CallAsync(dto);
    }
}
