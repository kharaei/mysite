using Kharaei.Domain; 
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class ArticleCategoryRepository: BaseRepository<int, ArticleCategory>, IArticleCategoryRepository
{  
    private readonly KharaeiDbContext _context;

    public ArticleCategoryRepository(KharaeiDbContext context) : base(context)
    {
        _context = context;
    }
}
