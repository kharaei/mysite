using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleDto//: BaseDto<ArticleDto, Article, int> 
{
    public int Id { get; set; }
    public string Title { get; set; }  
    public string PublishDateTime { get; set; } 
}
 