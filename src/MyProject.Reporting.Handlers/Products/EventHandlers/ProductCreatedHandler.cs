using Kledex.Events;
using MyProject.Domain.Models.Products.Events;
using MyProject.Reporting.Data;
using MyProject.Reporting.Data.Entities;
using System.Threading.Tasks;

namespace MyProject.Reporting.Handlers
{
    public class ProductCreatedHandler : IEventHandlerAsync<ProductCreated>
    {
        private readonly ReportingDbContext _dbContext;

        public ProductCreatedHandler(ReportingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task HandleAsync(ProductCreated @event)
        {
            var productEntity = new ProductEntity
            { 
                Id = @event.AggregateRootId,
                Name = @event.Name
            };

            _dbContext.Products.Add(productEntity);

            return _dbContext.SaveChangesAsync();
        }
    }
}
