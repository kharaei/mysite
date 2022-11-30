using Kharaei.Domain; 
using Kharaei.Application;

namespace Kharaei.Infra;

public class PostRepository : Repository<Post>, IPostRepository
{ 

    public PostRepository(KharaeiDbContext dbContext)
        : base(dbContext)
    { 
    } 
 
}
