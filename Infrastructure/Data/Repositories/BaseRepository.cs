using Kharaei.Domain;
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
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

    public void InsertEntity(TEntity entiry)
    {
        _dbcontext.Add(entiry);
        _dbcontext.SaveChanges();
        return;
    }
}