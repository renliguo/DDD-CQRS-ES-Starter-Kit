using System.Collections.Generic;
using System.Threading.Tasks;
using Kledex;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.Reporting.Products.Models;
using MyProject.Reporting.Products.Queries;

namespace MyProject.Web.Pages.Products
{
    public class ListModel : PageModel
    {
        private readonly IDispatcher _dispatcher;

        public ListModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public IEnumerable<ProductListView> Products { get; private set; }

        public async Task OnGetAsync()
        {
            var productList = await _dispatcher.GetResultAsync(new GetProductList());
            Products = productList.Products;
        }
    }
}