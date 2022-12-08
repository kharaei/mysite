
using Kharaei.Domain;

namespace  Kharaei.Application;

public interface IArticleCategoryService
{    
    List<ArticleCategorySelectDto> ReadAll(); 
    ArticleCategory Read(int Id);
    ArticleCategory Create(ArticleCategoryDto dto); 
    void Delete (int Id);
    //void DeleteRange (List<int> Ids);
}