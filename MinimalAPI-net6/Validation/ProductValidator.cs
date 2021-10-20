using FluentValidation;
using MinimalAPI_net6.Models;

namespace MinimalApI_net6.Validation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5);
        }
    }
}
