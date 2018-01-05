
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using WordpressIntegration.Web.Core.Exceptions;
using WordpressIntegration.Web.Core.Resources;

namespace WordpressIntegration.Web.Infrastructure.Services
{
    public class WordpressService : IWordpressService
    {
        private static HttpClient _httpClient = new HttpClient();
        private string _url = "http://euromobilecenter.com/wp-json/wp/v2";
        private readonly IMapper _mapper;

        public WordpressService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<PostResource>> GetPosts()
        {
            var postResources = await GetDataFromWordpress<List<WordpressPostResource>>("posts");
            var authorResources = await GetDataFromWordpress<List<AuthorResource>>("users");
            var tagResources = await GetDataFromWordpress<List<KeyValuePairResource>>("tags");
            var categoryResources = await GetDataFromWordpress<List<KeyValuePairResource>>("categories");
            var mediaResources = await GetDataFromWordpress<List<MediaResource>>("media");
            
            var posts = new List<PostResource>();

            foreach (var postResource in postResources)
            {
                var post = _mapper.Map<PostResource>(postResource);

                post.Author = authorResources
                    .SingleOrDefault(a => a.Id == postResource.AuthorId);

                post.ImageUri = mediaResources
                    .SingleOrDefault(m => m.Id == postResource.MediaId)?.ImageUri.Rendered;

                post.Tags = tagResources
                    .Where(t => postResource.TagIds
                    .Contains(t.Id)).ToList();
                
                post.Categories = categoryResources
                    .Where(c => postResource.CategoryIds
                    .Contains(c.Id)).ToList();

                posts.Add(post);
            }

            return posts;
        }

        private async Task<T> GetDataFromWordpress<T>(string urn)
        {
            var response = await _httpClient.GetAsync($"{_url}/{urn}");
            if (!response.IsSuccessStatusCode)
                throw new WordpressException("Data can not be fetched.");

            return await DeserializeResponseContent<T>(response);
        }

        private async Task<T> DeserializeResponseContent<T>(HttpResponseMessage message)
        {
            var stringContent = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringContent);
        }
    }
}