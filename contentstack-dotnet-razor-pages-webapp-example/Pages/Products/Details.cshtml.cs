using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentstack.Core;
using Contentstack.Core.Internals;
using ContentstackModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace contentstack_dotnet_razor_pages_webapp_example.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly String _contentType = "product";
        private readonly ContentstackClient _contentstackClient;

        [BindProperty]
        public Product Product { get; set; }

        public DetailsModel(ContentstackClient contentstackClient)
        {
            _contentstackClient = contentstackClient;
        }

        public async Task OnGetAsync(string productuid)
        {
            try
            {
                Product = await _contentstackClient.ContentType(_contentType)
                            .Entry(productuid)
                            .Fetch<Product>();
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
