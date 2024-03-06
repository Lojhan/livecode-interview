using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.Common;
using Livecode.Domain.DTO;
using Livecode.Domain.Entities;
using Livecode.Domain.Interfaces;

namespace Livecode.Domain.Usecases;

public class CreateUserUsecase(
  IUserRepository userRepository
)
{
    public async Task<Either<Error, User>> CallAsync(CreateUserDTO dto)
    {
        return await userRepository.CreateUserAsync(dto);
    }
}