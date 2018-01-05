using System.Collections.Generic;
using System.Threading.Tasks;
using WordpressIntegration.Web.Core.Resources;

namespace WordpressIntegration.Web.Infrastructure.Services
{
    public interface IWordpressService
    {
         Task<List<PostResource>> GetPosts();
    }
}
