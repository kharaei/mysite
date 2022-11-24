using AutoMapper;
using Kharaei.Domain; 

namespace Kharaei.Api;

public class PostDto : BaseDto<PostDto, Post>
{
    public string Title { get; set; } 
    public string Image { get; set; }
    public string Text { get; set; }
    public string PublishDate { get; set; }
    public string PublishTime { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; } 
    public Category Category { get; set; }
    public User Author { get; set; }
}

public class PostSelectDto : BaseDto<PostSelectDto, Post>
{ 
    public string CategoryName { get; set; } //=> Category.Name
    public string AuthorFullName { get; set; } //=> Author.FullName
    public string FullTitle { get; set; } // => mapped from "Title (Category.Name)"

    public override void CustomMappings(IMappingExpression<Post, PostSelectDto> mappingExpression)
    {
        mappingExpression.ForMember(
                dest => dest.FullTitle,
                config => config.MapFrom(src => $"{src.Title} ({src.Category.Name})"));
    }
}