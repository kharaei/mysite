using Kharaei.Domain;
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
{

    private readonly KharaeiDbContext _dbcontext;

    public BaseRepository(KharaeiDbContext context)
    {
        _dbcontext = context;
    }
    
    void IRepository<TEntity>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    List<TEntity> IRepository<TEntity>.GetEntities()
    {
            return _dbcontext.Set<TEntity>().ToList();
    }

    TEntity IRepository<TEntity>.GetEntity(int id)
    {
            return _dbcontext.Find<TEntity>(id);
    }
}