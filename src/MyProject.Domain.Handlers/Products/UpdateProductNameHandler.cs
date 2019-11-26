using System;
using System.Threading.Tasks;
using Kledex.Commands;
using Kledex.Domain;
using MyProject.Domain.Models.Products;
using MyProject.Domain.Models.Products.Commands;

namespace MyProject.Domain.Handlers.Products
{
    public class UpdateProductNameHandler : ICommandHandlerAsync<UpdateProductName>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductNameHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(UpdateProductName command)
        {
            var product = await _repository.GetByIdAsync(command.AggregateRootId);

            if (product == null)
            {
                throw new ApplicationException($"Product not found. Id: {command.AggregateRootId}");
            }

            product.UpdateName(command.Name);

            return new CommandResponse
            {
                Events = product.Events
            };
        }
    }
}
