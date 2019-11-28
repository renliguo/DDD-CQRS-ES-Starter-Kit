using Kledex.Queries;
using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Products;
using MyProject.Reporting.Data;
using MyProject.Reporting.Products.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Reporting.Products.Queries.Handlers
{
    public class GetProductListHandler : IQueryHandlerAsync<GetProductList, ProductList>
    {
        private readonly ReportingDbContext _dbContext;

        public GetProductListHandler(ReportingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductList> HandleAsync(GetProductList query)
        {
            var productListViews = await _dbContext.Products
                .Where(x => x.Status != ProductStatus.Deleted)
                .Select(x => new ProductListView
                {
                    ProductId = x.Id,
                    ProductName = x.Name,
                    ProductStatus = x.Status
                }).ToListAsync();

            return new ProductList
            {
                Products = productListViews
            };
        }
    }
}
