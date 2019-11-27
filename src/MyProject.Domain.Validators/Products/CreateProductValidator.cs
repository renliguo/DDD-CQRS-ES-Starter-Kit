using FluentValidation;
using Kledex;
using MyProject.Domain.Models.Products.Commands;
using MyProject.Reporting.Models.Products.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Domain.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        private readonly IDispatcher _dispatcher;

        public CreateProductValidator(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .Length(1, 100).WithMessage("Product name length must be between 1 and 100 characters.")
                .MustAsync(HaveUniqueName).WithMessage($"A product with the same name already exists.");
        }

        private async Task<bool> HaveUniqueName(string name, CancellationToken cancellationToken)
        {
            var productNameExists = await _dispatcher.GetResultAsync(new ProductNameExists { ProductName = name });
            return !productNameExists;
        }
    }
}
