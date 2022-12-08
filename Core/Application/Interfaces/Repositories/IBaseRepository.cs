using Kharaei.Domain;  

namespace Kharaei.Application;

public interface IBaseRepository<TEntity, TKey>
                 where TEntity : BaseEntity<TKey>
{ 
    List<TEntity> GetEntities();  
    TEntity GetEntity(TKey id);
    TEntity InsertEntity(TEntity entity);
    //void UpdateEntity(TEntity entity);
    void RemoveEntity(TEntity entity);
    void RemoveEntities(List<TEntity> entities);
}