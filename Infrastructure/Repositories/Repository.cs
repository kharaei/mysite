using Kharaei.Domain;
using Kharaei.Application; 

namespace Kharaei.Infra;

public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
{

}