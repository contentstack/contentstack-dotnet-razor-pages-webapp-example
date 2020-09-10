using System;
using System.Collections.Generic;
using System.Linq;
using Markdig;

namespace ContentstackRazorPagesExample.Models
{
    public static class ContentstackStringExtension
    {
        public static string ToHtml(this String str)
        {
            if (str == null) return string.Empty;
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            return Markdown.ToHtml(str, pipeline);
        }

        public static List<string> ToListHtml(this List<string> str)
        {
            return str.Select(value => value.ToHtml()).ToList();
        }
    }
}