using Kharaei.Domain; 
using Kharaei.Application;

namespace Kharaei.Infra;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{ 

    public CategoryRepository(KharaeiDbContext dbContext)
        : base(dbContext)
    { 
    } 
 
}
