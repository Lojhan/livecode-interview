using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livecode.Domain.DTO;
using Livecode.Domain.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Livecode.External.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(CreateUserService createUserService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(CreateUserDTO dto)
    {
        var result = await createUserService.CallAsync(dto);
        return result.Match<IActionResult>(
            Right: Ok,
            Left: BadRequest
        );
    }
}