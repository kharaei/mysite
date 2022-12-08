
using Kharaei.Domain;

namespace  Kharaei.Application;

public interface IArticleCategoryService
{   
    void Create(ArticleCategoryDto dto);  
    List<ArticleCategorySelectDto> Read(); 
    ArticleCategory Read(int Id);
    void Update(int Id, ArticleCategoryDto dto);
    void Delete (int Id); 
}