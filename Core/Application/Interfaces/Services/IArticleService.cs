
using Kharaei.Domain;

namespace  Kharaei.Application;

public interface IArticleService
{ 
    List<ArticleSelectDto> ReadAll();    
    Article Create(ArticleDto dto);
}