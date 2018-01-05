using System.Collections.Generic;

namespace WordpressIntegration.Web.Core.Resources
{
    public class AuthorResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> AvatarUrls { get; set; }        
    }
}