using Kharaei.Domain;

namespace Kharaei.Application;

public class ArticleDto: BaseDto<int> , IDto
{ 
    public string Title { get; set; }  
    public string Text { get; set; }  
    public string PublishDateTime { get; set; } 
}
 