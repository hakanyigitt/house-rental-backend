using Entities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class HouseImageValidator : AbstractValidator<HouseImage>
    {
        public HouseImageValidator()
        {
            RuleFor(c => c.HouseId).NotEmpty();
            RuleFor(c => c.HouseId).GreaterThan(0);
        }
    }
}
