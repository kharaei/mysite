using AutoMapper;
using Kharaei.Domain;

namespace Kharaei.Application;

public class CustomProfile : Profile
{
    public CustomProfile()
    {
        CreateMap<ArticleCategory,  ArticleCategorySelectDto>().ReverseMap();
    }
}