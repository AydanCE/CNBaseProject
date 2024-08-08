using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class TourValidator : AbstractValidator<Tour>
    {
        public TourValidator()
        {
            RuleFor(t => t.TourName).MinimumLength(3).WithMessage("Data cannot be empty!");
            RuleFor(t => t.TourPrice).GreaterThan(0).WithMessage("Price must be greater than zero!").NotNull();

        }
    }
}
