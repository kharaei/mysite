using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleSelectDto: BaseDto<ArticleSelectDto, Article, int>
{ 
    public string Title { get; set; }   
    public string PublishDateTime { get; set; } 
}
 
public class ArticleDto:  BaseDto<ArticleDto, Article, int>
{ 
    public string Title { get; set; }  
    public string Text { get; set; }  
    public string PublishDateTime { get; set; } 
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
}