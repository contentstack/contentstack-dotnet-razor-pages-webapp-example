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
    public partial class ContentstackLink
    {
         public string Title { get; set; }
         public string Href { get; set; }
    }
}

