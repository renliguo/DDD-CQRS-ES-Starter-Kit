using System;
using System.Threading.Tasks;
using Kledex;
using Kledex.UI.Models;
using Kledex.UI.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.Domain.Models.Products.Commands;
using MyProject.Reporting.Models;
using MyProject.Reporting.Models.Products.Queries;

namespace MyProject.Web.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IDispatcher _dispatcher;

        public EditModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [BindProperty]
        public ProductView ProductView { get; set; }

        public AggregateModel AggregateModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            ProductView = await _dispatcher.GetResultAsync(new GetProductView
            {
                ProductId = id
            });

            AggregateModel = await _dispatcher.GetResultAsync(new GetAggregateModel
            {
                AggregateRootId = id
            });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var command = new UpdateProductDetails
            {
                AggregateRootId = id,
                Name = ProductView.ProductName,
                Description = ProductView.ProductDescription,
                Price = ProductView.ProductPrice
            };

            await _dispatcher.SendAsync(command);

            return RedirectToPage(new { id });
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var command = new DeleteProduct
            {
                AggregateRootId = id
            };

            await _dispatcher.SendAsync(command);

            return RedirectToPage(new { id });
        }

        public async Task<IActionResult> OnPostPublishAsync(Guid id)
        {
            var command = new PublishProduct
            {
                AggregateRootId = id
            };

            await _dispatcher.SendAsync(command);

            return RedirectToPage(new { id });
        }

        public async Task<IActionResult> OnPostWithdrawAsync(Guid id)
        {
            var command = new WithdrawProduct
            {
                AggregateRootId = id
            };

            await _dispatcher.SendAsync(command);

            return RedirectToPage(new { id });
        }
    }
}