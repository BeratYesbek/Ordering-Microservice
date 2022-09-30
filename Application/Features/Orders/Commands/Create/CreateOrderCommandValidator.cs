using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Orders.Commands.Create
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.ExternalUserId).NotEmpty();
            RuleFor(c => c.ExternalUserId).NotEqual(0);
        }
    }
}
