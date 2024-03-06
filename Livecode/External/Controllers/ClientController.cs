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
public class ClientController(ClientService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ListClientsAsync(ListClientsDTO dto)
    {
        var result = await service.ListClientsAsync(dto);
        return result.Match<IActionResult>(
            Right: Ok,
            Left: BadRequest
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateClientAsync(CreateClientDTO dto)
    {
        var result = await service.CreateClientAsync(dto);
        return result.Match<IActionResult>(
            Right: Ok,
            Left: BadRequest
        );
    }

    [HttpPut]
    public async Task<IActionResult> UpdateClientAsync(UpdateClientDTO dto)
    {
        var result = await service.UpdateClientAsync(dto);
        return result.Match<IActionResult>(
            Right: Ok,
            Left: BadRequest
        );
    }
}