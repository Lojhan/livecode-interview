using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livecode.Domain.DTO;
using Livecode.Domain.Entities;

namespace Livecode.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> CreateUserAsync(CreateUserDTO dto);
}