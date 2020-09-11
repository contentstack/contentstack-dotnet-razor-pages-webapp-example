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
        [BindProperty(SupportsGet = true)]
        public string Uid { get; set; }

        public DetailsModel(ContentstackClient client)
        {
            _client = client;
        }

        public async Task OnGetAsync()
        {
            Product = await _client.ContentType(Product.ContentType)
                .Entry(Uid)
                .Fetch<Product>();
        }
    }
}