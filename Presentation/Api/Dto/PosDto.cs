using AutoMapper;
using Kharaei.Domain; 

namespace Kharaei.Api;

public class PostDto : BaseDto<PostDto, Post>
{
    public string Title { get; set; }  
    public string PublishDate { get; set; }
    public string PublishTime { get; set; } 
}

public class PostSelectDto : BaseDto<PostSelectDto, Post>
{ 
    public string Title { get; set; }  
    public string PublishDate { get; set; }
    public string PublishTime { get; set; } 
    public string CategoryName { get; set; } //=> Category.Name
    public string AuthorFullName { get; set; } //=> Author.FullName 

    public override void CustomMappings(IMappingExpression<Post, PostSelectDto> mappingExpression)
    {
        mappingExpression.ForMember(
                dest => dest.CategoryName,
                config => config.MapFrom(src => $"{src.Title} ({src.Category.Name})"));
    }
}