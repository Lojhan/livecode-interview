using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livecode.Domain.DTO;

public class UpdateClientDTO(
      string Id,
      string Name,
      string Email
)
{
    public string Id { get; set; } = Id;
    public string Name { get; set; } = Name;
    public string Email { get; set; } = Email;
}