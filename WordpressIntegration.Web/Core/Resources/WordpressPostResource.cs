using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordpressIntegration.Web.Core.Resources
{
    public class WordpressPostResource
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Slug { get; set; }
        public WordpressHtmlContentResource Title { get; set; }
        public WordpressHtmlContentResource Content { get; set; }
        public WordpressHtmlContentResource Excerpt { get; set; }

        [JsonProperty("featured_media")]
        public int MediaId { get; set; }

        [JsonProperty("author")]
        public int AuthorId { get; set; }

        [JsonProperty("categories")]
        public List<int> CategoryIds { get; set; }

        [JsonProperty("tags")]
        public List<int> TagIds { get; set; }
    }
}