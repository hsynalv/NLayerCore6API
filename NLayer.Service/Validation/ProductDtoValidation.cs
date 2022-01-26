using FluentValidation;
using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validation
{
    public class ProductDtoValidation : AbstractValidator<ProductDto>
    {
        public ProductDtoValidation()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("{PropertyName} is must be greater 0");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("{PropertyName} is must be greater 0");
            RuleFor(x => x.Stock).GreaterThan(0).WithMessage("{PropertyName} is must be greater 0");
        }
    }
}
