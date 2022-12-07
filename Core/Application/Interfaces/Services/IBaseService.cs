using Kharaei.Domain;
using Microsoft.EntityFrameworkCore;

namespace  Kharaei.Application;

public interface IBaseService<TDto, TEntity, TKey>
               where TDto: IDto
               where TEntity: IEntity
{ 
    List<TDto> GetAll();
    //TDto GetById(TKey id);
    TEntity Add(TDto dto);
    //TEntity Update(TDto dto);
    //void DeleteEntity(int);
}