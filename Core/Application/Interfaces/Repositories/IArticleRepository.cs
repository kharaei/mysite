using Kharaei.Domain;

namespace Kharaei.Application;

public interface IArticleRepository : IBaseRepository<int, Article>
{ 
    List<Article> GetEntities(string Title);
}