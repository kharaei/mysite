using Kharaei.Domain;  

namespace Kharaei.Application;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    
}