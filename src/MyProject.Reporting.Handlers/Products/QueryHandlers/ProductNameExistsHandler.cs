using Kledex.Queries;
using Microsoft.EntityFrameworkCore;
using MyProject.Reporting.Data;
using MyProject.Reporting.Models.Products.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Reporting.Handlers
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
