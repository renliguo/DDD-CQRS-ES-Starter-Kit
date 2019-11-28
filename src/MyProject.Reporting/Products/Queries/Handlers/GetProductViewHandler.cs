using Kledex.Queries;
using Microsoft.EntityFrameworkCore;
using MyProject.Reporting.Data;
using MyProject.Reporting.Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Reporting.Products.Queries.Handlers
{
    public class GetProductViewHandler : IQueryHandlerAsync<GetProductView, ProductView>
    {
        private readonly ReportingDbContext _dbContext;

        public GetProductViewHandler(ReportingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ProductView> HandleAsync(GetProductView query)
        {
            return _dbContext.Products.Where(x => x.Id == query.ProductId).Select(x => new ProductView
            {
                ProductId = x.Id,
                ProductName = x.Name,
                ProductDescription = x.Description,
                ProductPrice = x.Price,
                ProductStatus = x.Status
            }).SingleOrDefaultAsync();
        }
    }
}
