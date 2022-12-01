using Kharaei.Domain; 

namespace Kharaei.Application;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    List<TEntity> GetEntities(); 
    TEntity GetEntity(int id);
    //void Create(TEntity entity);
    //void Update(TEntity entity);
    void Delete(int id);
}