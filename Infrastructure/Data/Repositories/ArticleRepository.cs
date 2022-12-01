using Kharaei.Domain; 
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class ArticleRepository : BaseRepository<Article>, IArticleRepository
{    
    private readonly KharaeiDbContext _context;

    public ArticleRepository(KharaeiDbContext context) : base(context)
    {
        _context = context;
    }
}
