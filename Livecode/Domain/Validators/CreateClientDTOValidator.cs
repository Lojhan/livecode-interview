using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Livecode.Domain.DTO;

namespace Livecode.Domain.Validators;

public class CreateClientDTOValidator : AbstractValidator<CreateClientDTO>
{
    public CreateClientDTOValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
    }
}