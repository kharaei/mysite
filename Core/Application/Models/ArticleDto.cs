using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleDto//: BaseDto<ArticleDto, Article, int> 
{
    public string Title { get; set; }  
    public string PublishDate { get; set; }
    public string PublishTime { get; set; } 
}
 