using System.Threading.Tasks;
using Contentstack.Core;
using Contentstack.Core.Models;
using ContentstackRazorPagesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContentstackRazorPagesExample.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ContentstackClient _client;
        
        public bool ShowPrevious => CurrentPage > 1;
        public int CurrentPage = 1;
        public readonly int Limit = 6;

        [BindProperty]
        public ContentstackCollection<Product> Products { get; set; }

        public IndexModel(ContentstackClient client)
        {
            _client = client;
        }

        public async Task OnGetAsync(int page = 1)
        {
            ViewData["Title"] = "Home";

            CurrentPage = page;

            Products = await _client.ContentType(Product.ContentType)
                .Query()
                .IncludeCount()
                .Limit(Limit)
                .Skip((CurrentPage - 1) * Limit)
                .Find<Product>();
        }
    }
}