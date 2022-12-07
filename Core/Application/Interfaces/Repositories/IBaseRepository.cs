using Kharaei.Domain;  

namespace Kharaei.Application;

public interface IBaseRepository<TKey, TEntity>// where TEntity : BaseEntity<TKey>
{ 
    List<TEntity> GetEntities();  
    TEntity GetEntity(TKey id);
    void InsertEntity(TEntity entity);
    //void UpdateEntity(TEntity entity);
    //void DeleteEntity(int id);
}