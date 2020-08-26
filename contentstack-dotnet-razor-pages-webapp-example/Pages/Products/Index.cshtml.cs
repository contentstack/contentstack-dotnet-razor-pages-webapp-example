using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentstack.Core;
using Contentstack.Core.Models;
using ContentstackModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace contentstack_dotnet_razor_pages_webapp_example.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly String _contentType = "product";
        private readonly ContentstackClient _contentstackClient;
        [BindProperty]
        public ContentstackCollection<Product> contentstackCollection { get; set; }
        public bool ShowPrevious => CurrentPage > 1;
        public int CurrentPage = 1;
        public readonly int Limit = 6;

        public IndexModel(ContentstackClient contentstackClient)
        {
            _contentstackClient = contentstackClient;
        }

        public async Task OnGetAsync(int currentpage = 1)
        {
            CurrentPage = currentpage;
            contentstackCollection = await _contentstackClient.ContentType(_contentType)
                .Query()
                .IncludeCount()
                .Limit(Limit)
                .Skip((CurrentPage - 1) * Limit)
                .Find<Product>();
        }
    }
}
