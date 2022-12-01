using Kharaei.Domain;
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
{ 
    private readonly KharaeiDbContext _dbcontext;

    public BaseRepository(KharaeiDbContext context)
    {
        _dbcontext = context;
    }
      
    public List<TEntity> GetEntities()
    {
        return _dbcontext.Set<TEntity>().ToList();
    }

    public TEntity GetEntity(TKey id)
    {
        return _dbcontext.Find<TEntity>(id);
    }
}