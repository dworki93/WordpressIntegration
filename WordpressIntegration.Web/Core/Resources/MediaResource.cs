using Newtonsoft.Json;

namespace WordpressIntegration.Web.Core.Resources
{
    public class MediaResource
    {
        public int Id { get; set; }
        
        [JsonProperty("guid")]
        public WordpressHtmlContentResource ImageUri { get; set; }
    }
}