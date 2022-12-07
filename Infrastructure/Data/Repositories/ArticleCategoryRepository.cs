using Kharaei.Domain; 
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class ArticleCategoryRepository: BaseRepository<int, ArticleCategory>, IArticleCategoryRepository
{  
    private readonly KharaeiDbContext _dbcontext;

    public ArticleCategoryRepository(KharaeiDbContext dbcontext) : base(dbcontext)
    {
        _dbcontext = dbcontext;
    }
    
    public List<ArticleCategory> GetEntities(string title)
    {
        return _dbcontext.Set<ArticleCategory>().Where(x => x.Title.Contains(title)).ToList();
    }
}
