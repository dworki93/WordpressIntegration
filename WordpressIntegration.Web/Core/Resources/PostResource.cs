using System;
using System.Collections.Generic;

namespace WordpressIntegration.Web.Core.Resources
{
    public class PostResource
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string ImageUri { get; set; }
        public AuthorResource Author { get; set; }
        public List<KeyValuePairResource> Categories { get; set; }
        public List<KeyValuePairResource> Tags { get; set; }
    }
}