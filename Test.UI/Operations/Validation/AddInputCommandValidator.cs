using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Test.UI.Operations.Command;

namespace Test.UI.Operations.Validation
{
    public class AddInputCommandValidator : AbstractValidator<ItemAppendCommand>
    {
        public AddInputCommandValidator ()
        {
            RuleFor(r => r.Sername).NotEmpty().WithMessage("Sername").Length(0, 500);
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name").Length(0, 500);
        }

    }
}