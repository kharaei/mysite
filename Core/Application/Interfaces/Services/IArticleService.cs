
using Kharaei.Domain;

namespace  Kharaei.Application;

public interface IArticleService
{  
    void Create(ArticleDto dto);  
    List<ArticleSelectDto> Read(); 
    Article Read(int Id);
    void Update(int Id, ArticleDto dto);
    void Delete (int Id); 
}