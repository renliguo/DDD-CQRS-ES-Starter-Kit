using System.Threading.Tasks;
using Kledex;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.Domain.Products.Commands;
using MyProject.Reporting.Products.Models;

namespace MyProject.Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IDispatcher _dispatcher;

        public CreateModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [BindProperty]
        public ProductView ProductView { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var command = new CreateProduct
            {
                Name = ProductView.ProductName
            };

            await _dispatcher.SendAsync(command);

            return RedirectToPage("/Products/List");
        }
    }
}