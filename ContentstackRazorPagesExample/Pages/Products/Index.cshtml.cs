using System;
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

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public int TotalPages => (int) Math.Ceiling(decimal.Divide(Products?.Count ?? 0, PageSize));

        public ContentstackCollection<Product> Products { get; set; }

        public IndexModel(ContentstackClient client)
        {
            _client = client;
        }

        public async Task OnGetAsync()
        {
            Products = await _client.ContentType(Product.ContentType)
                .Query()
                .IncludeCount()
                .Limit(PageSize)
                .Skip((CurrentPage - 1) * PageSize)
                .Find<Product>();
        }
    }
}