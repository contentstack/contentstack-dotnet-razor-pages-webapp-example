using System.Collections.Generic;
using Contentstack.Core.Models;
using Newtonsoft.Json;

namespace ContentstackRazorPagesExample.Models
{
    public partial class Product
    {
        public const string ContentType = "product";
        public string Uid { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        [JsonProperty(propertyName: "featured_image")]
        public List<Asset> FeaturedImage { get; set; }
        public double Price { get; set; }
    }
}