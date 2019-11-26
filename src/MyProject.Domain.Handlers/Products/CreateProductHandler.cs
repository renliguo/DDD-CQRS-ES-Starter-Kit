using System.Threading.Tasks;
using Kledex.Commands;
using MyProject.Domain.Models.Products;
using MyProject.Domain.Models.Products.Commands;

namespace MyProject.Domain.Handlers.Products
{
    public class CreateProductHandler : ICommandHandlerAsync<CreateProduct>
    {
        public async Task<CommandResponse> HandleAsync(CreateProduct command)
        {
            var product = new Product(command.AggregateRootId, command.Name);

            return await Task.FromResult(new CommandResponse
            {
                Events = product.Events
            });
        }
    }
}
