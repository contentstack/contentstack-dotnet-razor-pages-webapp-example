using System.Threading.Tasks;
using Contentstack.Core;
using ContentstackRazorPagesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContentstackRazorPagesExample.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ContentstackClient _client;

        [BindProperty]
        public Product Product { get; set; }

        public DetailsModel(ContentstackClient client)
        {
            _client = client;
        }

        public async Task OnGetAsync(string uid)
        {
            Product = await _client.ContentType(Product.ContentType)
                .Entry(uid)
                .Fetch<Product>();

            ViewData["Title"] = Product.Title;
        }
    }
}