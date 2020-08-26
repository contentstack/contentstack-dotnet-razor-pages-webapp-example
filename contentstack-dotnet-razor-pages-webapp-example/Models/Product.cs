using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contentstack.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;


namespace ContentstackModels.Models
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

