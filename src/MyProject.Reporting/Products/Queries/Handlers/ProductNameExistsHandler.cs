using Kledex.Queries;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Products.Commands.Validators.Queries;
using MyProject.Reporting.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Reporting.Products.Queries.Handlers
{
    public class ProductNameExistsHandler : IQueryHandlerAsync<ProductNameExists, bool>
    {
        private readonly ReportingDbContext _dbContext;

        public ProductNameExistsHandler(ReportingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HandleAsync(ProductNameExists query)
        {
            var productName = await _dbContext.Products
                .Where(x => x.Name == query.ProductName)
                .Select(x => x.Name)
                .SingleOrDefaultAsync();

            return !string.IsNullOrEmpty(productName);
        }
    }
}
