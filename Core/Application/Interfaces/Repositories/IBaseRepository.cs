using Kharaei.Domain; 

namespace Kharaei.Application;

public interface IBaseRepository<in TKey, TEntity> where TEntity : BaseEntity<TKey>
{ 
    TEntity GetEntity(TKey id);
    List<TEntity> GetEntities(); 
    //void Create(TEntity entity);
    //void Update(TEntity entity);
    //void Delete(int id);
}