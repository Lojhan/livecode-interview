using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livecode.Domain.DTO;


public class CreateClientDTO(
    string Name,
    string Email,
    string UserId
)
{
    public string Name { get; set; } = Name;
    public string Email { get; set; } = Email;
    public string UserId { get; set; } = UserId;
}