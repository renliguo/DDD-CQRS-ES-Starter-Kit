using System.Threading.Tasks;
using Kledex.Commands;

namespace MyProject.Domain.Products.Commands.Handlers
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
