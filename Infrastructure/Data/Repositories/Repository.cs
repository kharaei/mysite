using Kharaei.Domain;
using Kharaei.Application;

namespace Kharaei.Infra.Data;

public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
{
    void IRepository<TEntity>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    List<TEntity> IRepository<TEntity>.GetEntities()
    {
        throw new NotImplementedException();
    }

    TEntity IRepository<TEntity>.GetEntity(int id)
    {
        throw new NotImplementedException();
    }
}