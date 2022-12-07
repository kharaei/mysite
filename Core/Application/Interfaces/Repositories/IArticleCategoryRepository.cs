using Kharaei.Domain;

namespace Kharaei.Application;

public interface IArticleCategoryRepository : IBaseRepository<int, ArticleCategory>
{ 
   List<ArticleCategory> GetEntities(string Title);
}