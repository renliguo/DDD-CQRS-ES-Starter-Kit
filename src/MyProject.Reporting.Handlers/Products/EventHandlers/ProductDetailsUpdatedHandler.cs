using System;
using System.Threading.Tasks;
using Kledex.Events;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Models.Products.Events;
using MyProject.Reporting.Data;

namespace MyProject.Reporting.Handlers
{
    public class ProductDetailsUpdatedHandler : IEventHandlerAsync<ProductDetailsUpdated>
    {
        private readonly ReportingDbContext _dbContext;

        public ProductDetailsUpdatedHandler(ReportingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HandleAsync(ProductDetailsUpdated @event)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == @event.AggregateRootId);

            if (product == null)
            {
                throw new ApplicationException($"Product not found. Id: {@event.AggregateRootId}");
            }

            product.Name = @event.Name;
            product.Description = @event.Description;
            product.Price = @event.Price;

            await _dbContext.SaveChangesAsync();
        }
    }
}
