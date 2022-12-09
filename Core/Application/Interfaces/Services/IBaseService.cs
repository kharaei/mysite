using Kharaei.Domain;

namespace Kharaei.Application;

public interface IBaseService<TEntity, TSelectDto, TDto, TKey>
    where TEntity : BaseEntity<TKey>, new()
    where TDto : class, new() 
    where TSelectDto : class, new() 
    
{
    void Create(TDto dto);  
    List<TSelectDto> Read(); 
    TEntity Read(int Id);
    void Update(int Id, TDto dto);
    void Delete (int Id); 
}