using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livecode.Domain.DTO;

public class ListClientsDTO(
       string UserId
)
{
    public string UserId { get; set; } = UserId;
}