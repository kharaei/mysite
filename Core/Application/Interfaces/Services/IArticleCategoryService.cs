
using Kharaei.Domain;

namespace  Kharaei.Application;

public interface IArticleCategoryService
{    
    List<ArticleCategorySelectDto> ReadAll(); 
    ArticleCategory Create(ArticleCategoryDto dto); 
}