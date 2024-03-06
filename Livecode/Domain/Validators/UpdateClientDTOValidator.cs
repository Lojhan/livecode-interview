using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Livecode.Domain.DTO;

namespace Livecode.Domain.Validators;

public class UpdateClientDTOValidator : AbstractValidator<UpdateClientDTO>
{
    public UpdateClientDTOValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
    }
}