using System;
using System.Threading.Tasks;
using Kledex.Commands;
using Kledex.Domain;
using MyProject.Domain.Models.Products;
using MyProject.Domain.Models.Products.Commands;

namespace MyProject.Domain.Handlers.Products
{
    public class UpdateProductDetailsHandler : ICommandHandlerAsync<UpdateProductDetails>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductDetailsHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(UpdateProductDetails command)
        {
            var product = await _repository.GetByIdAsync(command.AggregateRootId);

            if (product == null)
            {
                throw new ApplicationException($"Product not found. Id: {command.AggregateRootId}");
            }

            product.UpdateDetails(command.Name, command.Description, command.Price);

            return new CommandResponse
            {
                Events = product.Events
            };
        }
    }
}
