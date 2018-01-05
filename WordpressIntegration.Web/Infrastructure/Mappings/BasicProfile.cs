using AutoMapper;
using WordpressIntegration.Web.Core.Resources;

namespace WordpressIntegration.Web.Infrastructure.Mappings
{
    public class BasicProfile : Profile
    {
        public BasicProfile()
        {
            CreateMap<WordpressPostResource, PostResource>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Rendered))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content.Rendered))
                .ForMember(dest => dest.Excerpt, opt => opt.MapFrom(src => src.Excerpt.Rendered));
        }
    }
}