using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using LanguageExt.Common;

namespace Livecode.Domain.Errors;
public record ValidationError(List<ValidationFailure> Errors) : Error
{
    public override string Message => Errors.Select(x => x.ErrorMessage).Aggregate((x, y) => $"{x}, {y}");

    public override bool IsExceptional => true;

    public override bool IsExpected => true;

    public override bool Is<E>() => typeof(E) == typeof(ValidationError);

    public override ErrorException ToErrorException()
    {
        throw new Exception("ValidationError should not be converted to ErrorException");
    }
}

