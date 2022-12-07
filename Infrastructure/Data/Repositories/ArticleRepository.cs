using Kharaei.Domain; 
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class ArticleRepository : BaseRepository<int, Article>, IArticleRepository
{    
    private readonly KharaeiDbContext _dbcontext;

    public ArticleRepository(KharaeiDbContext dbcontext) : base(dbcontext)
    {
        _dbcontext = dbcontext;
    }
 
    public List<Article> GetEntities(string title)
    {
        return _dbcontext.Set<Article>().Where(x => x.Title.Contains(title)).ToList();
    }
}
